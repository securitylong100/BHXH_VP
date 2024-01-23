﻿using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using XML130.EasyUtils;
using XML130.Libraries;

namespace XML130.XML
{
    public partial class FrmQuanLyXml : XtraForm
    {
        private const string MA_TINH = "26";
        private const string LOAI_HO_SO = "130";
        private const string USER_NAME = "26001_BV";
        private const string PASSWORD = "Dkvp26001@";

        private string _maCSKCB;
        private DataSet _dsXmlFile;
        private DataTable _dtErrors;
        private string _base64HoSoXml;
        private readonly XmlWriterSettings _xmlWriterSettings = new XmlWriterSettings()
        {
            Indent = true,
            Encoding = new UTF8Encoding(),
            ConformanceLevel = ConformanceLevel.Auto
        };

        public FrmQuanLyXml()
        {
            InitializeComponent();
        }
        #region Protected methods
        protected virtual void OnInit()
        {
            try
            {
                _dtErrors = SQLHelper.ExecuteDataTable("SELECT * FROM XMLERROR");
                ClientHelper.Instance.Login(USER_NAME, PASSWORD, WriteLog);
            }
            catch (Exception exception)
            {
                EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");
            }
        }
        protected virtual void OnSendAPI()
        {
            if (string.IsNullOrWhiteSpace(_base64HoSoXml))
            {
                WriteLog("Chưa có file XML để gửi!\nVui lòng xuất file XML trước!", false);
                return;
            }
            try
            {
                ClientHelper.Instance.SendBase64Xml(
                    new ClientHelper.SendXmlRequest
                    {
                        maTinh = MA_TINH,
                        maCSKCB = _maCSKCB,
                        username = USER_NAME,
                        loaiHoSo = LOAI_HO_SO,
                        fileHSBase64 = _base64HoSoXml
                    }, WriteLog);
            }
            catch (Exception ex)
            {
                WriteLog(string.Format("Gửi API thất bại!\n{0}", ex.Message), false);
            }
        }
        protected virtual void OnSaveToDB()
        {
            if (_dsXmlFile != null && _dsXmlFile.Tables.Count > 0)
            {
                string maLK = _dsXmlFile.Tables["XML_GIAMDINHHS"].Rows[0]["MA_LK"].ToString();
                EasyLoadWait.ShowWaitForm(string.Format("Đang cập nhật dữ liệu lượt khám {0}", maLK), this);
                try
                {
                    foreach (DataTable dtXmlType in _dsXmlFile.Tables)
                    {
                        if (!XmlHelper.ImportXmlType2Db(dtXmlType.TableName, dtXmlType, WriteLog))
                        {
                            if (XmlHelper.UpdateXmlType2Db(dtXmlType.TableName, dtXmlType, WriteLog))
                            {
                                string message = $"Cập nhật dữ liệu lượt khám {maLK} tại bảng {dtXmlType.TableName} thất bại!";
                                WriteLog(message, false);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");
                }
                finally
                {
                    EasyLoadWait.CloseWaitForm();
                }
            }
        }
        protected virtual void OnExportXml()
        {
            _base64HoSoXml = string.Empty;
            if (_dsXmlFile != null && _dsXmlFile.Tables.Count > 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog()
                {
                    Filter = "XML Document (*.xml)|*.xml|All file (*.*)|*.*"
                };
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    _maCSKCB = _dsXmlFile.Tables["XML_GIAMDINHHS"].Rows[0]["MACSKCB"].ToString();
                    string maLK = _dsXmlFile.Tables["XML_GIAMDINHHS"].Rows[0]["MA_LK"].ToString();
                    string ngayLap = _dsXmlFile.Tables["XML_GIAMDINHHS"].Rows[0]["NGAYLAP"].ToString();
                    string soLuongHoSo = _dsXmlFile.Tables["XML_GIAMDINHHS"].Rows[0]["SOLUONGHOSO"].ToString();
                    EasyLoadWait.ShowWaitForm(string.Format("Đang xuất dữ liệu lượt khám {0} ra file xml", maLK), this);
                    try
                    {
                        #region XUẤT DỮ LIỆU RA XML
                        StringBuilder sbXmlHoSo = new StringBuilder();
                        using (XmlWriter writerHoSoXml = XmlWriter.Create(sbXmlHoSo, _xmlWriterSettings))
                        {
                            writerHoSoXml.WriteStartDocument();
                            writerHoSoXml.WriteStartElement("GIAMDINHHS");

                            writerHoSoXml.WriteStartElement("THONGTINDONVI");
                            writerHoSoXml.WriteElementString("MACSKCB", _maCSKCB);
                            writerHoSoXml.WriteEndElement();

                            writerHoSoXml.WriteStartElement("THONGTINHOSO");
                            if (DateTime.TryParse(ngayLap, out DateTime dtValue))
                            {
                                ngayLap = dtValue.ToString("yyyyMMdd");
                            }
                            writerHoSoXml.WriteElementString("NGAYLAP", ngayLap);
                            writerHoSoXml.WriteElementString("SOLUONGHOSO", soLuongHoSo);

                            writerHoSoXml.WriteStartElement("DANHSACHHOSO");
                            writerHoSoXml.WriteStartElement("HOSO");

                            foreach (DataTable dtXmlType in _dsXmlFile.Tables)
                            {
                                if (dtXmlType.TableName != "XML_GIAMDINHHS")
                                {
                                    writerHoSoXml.WriteStartElement("FILEHOSO");
                                    writerHoSoXml.WriteElementString("LOAIHOSO", dtXmlType.TableName);
                                    string xmlBase64 = XmlHelper.WriteXmlType2Xml(dtXmlType.TableName, dtXmlType);
                                    writerHoSoXml.WriteElementString("NOIDUNGFILE", xmlBase64);
                                    writerHoSoXml.WriteEndElement();
                                }
                            }

                            writerHoSoXml.WriteEndElement();
                            writerHoSoXml.WriteEndElement();

                            writerHoSoXml.WriteEndElement();

                            writerHoSoXml.WriteEndElement();
                            writerHoSoXml.WriteEndDocument();
                            writerHoSoXml.Flush();
                        }
                        File.WriteAllText(saveFile.FileName, sbXmlHoSo.ToString());
                        _base64HoSoXml = Convert.ToBase64String(Encoding.UTF8.GetBytes(sbXmlHoSo.ToString()));
                        WriteLog(string.Format("Mã lượt khám: {0}\nĐường dẫn file: {1}", maLK, saveFile.FileName), true);
                        #endregion
                    }
                    catch (Exception exception)
                    {
                        EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");
                    }
                    finally
                    {
                        EasyLoadWait.CloseWaitForm();
                    }
                }
            }
        }
        protected virtual void OnOpenXmlFile()
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                FileName = "Chọn file xml",
                Title = "Tải dữ liệu Xml",
                Filter = "XML Document (*.xml)|*.xml|All file (*.*)|*.*"
            };
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                EasyLoadWait.ShowWaitForm("Đang import", this);
                try
                {
                    _dsXmlFile = XmlHelper.LoadXmlFile(openFile.FileName);
                    if (_dsXmlFile == null)
                    {
                        EasyDialog.ShowErrorDialog($"Tải dữ liệu file {openFile.FileName} thất bại!");
                    }
                }
                catch (Exception exception)
                {
                    EasyDialog.ShowErrorDialog($"Phát sinh lỗi. ({exception.Message})");
                }
                finally
                {
                    EasyLoadWait.CloseWaitForm();
                }
            }
        }
        protected virtual void OnImportXmlFolder()
        {
            OpenFileDialog openFolder = new OpenFileDialog()
            {
                CheckFileExists = false,
                CheckPathExists = false,
                FileName = "Chọn thư mục",
                Title = "Chọn thư mục chứa file xml cần import",
            };
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                EasyLoadWait.ShowWaitForm("Đang import", this);
                try
                {
                    string folderPath = Path.GetDirectoryName(openFolder.FileName);
                    string[] xmlFiles = Directory.GetFiles(folderPath, "*.xml", SearchOption.AllDirectories);
                    foreach (string xmlFile in xmlFiles)
                    {
                        DataSet dsXmlFile = XmlHelper.LoadXmlFile(xmlFile);
                        foreach (DataTable dtXmlType in dsXmlFile.Tables)
                        {
                            if (!XmlHelper.ImportXmlType2Db(dtXmlType.TableName, dtXmlType, WriteLog))
                            {
                                EasyDialog.ShowErrorDialog($"Lưu dữ liệu {dtXmlType.TableName} thất bại!");
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    EasyDialog.ShowErrorDialog($"Phát sinh lỗi. ({exception.Message})");
                }
                finally
                {
                    EasyLoadWait.CloseWaitForm();
                }
            }
        }
        #endregion
        #region Private methods
        private void WriteLog(string message, bool isOk)
        {
            if (isOk)
            {
                EasyDialog.ShowSuccessfulDialog(message);
            }
            else
            {
                EasyDialog.ShowUnsuccessfulDialog(message);
            }
            Console.WriteLine(message);
        }
        private List<ClsError> ValidateXml1(DataTable dtXml1)
        {
            List<ClsError> lstError = new List<ClsError>();
            if (_dtErrors != null && _dtErrors.Rows.Count > 0
                && dtXml1 != null && dtXml1.Rows.Count > 0)
            {
                foreach (DataRow dr in dtXml1.Rows)
                {
                    foreach (DataRow drError in _dtErrors.Rows)
                    {
                        ClsError error = new ClsError()
                        {
                            Item = drError["TEN_COT"].ToString(),
                            MaLoiCha = drError["MA_LOI_CHA"].ToString(),
                            MaLoiCon = drError["MA_LOI_CON"].ToString(),
                            NoiDungLoi = drError["NOI_DUNG_LOI"].ToString(),
                        };
                        if (error.MaLoiCha.Length == 3 && error.MaLoiCha.StartsWith("1"))
                        {
                            string value = dr[error.Item].ToString();
                            if (string.IsNullOrWhiteSpace(value))
                            {
                                lstError.Add(error);
                            }
                            switch (error.MaLoiCon)
                            {
                                case "105002":
                                    {
                                        if (!int.TryParse(value, out int kq) || kq < 1 || kq > 3) lstError.Add(error);
                                        break;
                                    }
                                case "108002":
                                    {
                                        string sql = string.Format("SELECT [TEN_QUOCTICH] FROM tblDmQD130_QuocTich WHERE [MA_QUOCTICH]='{0}' ", value);
                                        string quocTich = SQLHelper.ExecuteScalar<string>(sql);
                                        if (string.IsNullOrWhiteSpace(quocTich)) lstError.Add(error);
                                        break;
                                    }
                                case "110002":
                                    {
                                        if (value != "00000")
                                        {
                                            StringBuilder sb = new StringBuilder();
                                            sb.AppendLine("SELECT TEN_NGHE_NGHIEP FROM tblDmQD130_NgheNghiep ");
                                            sb.AppendFormat("WHERE [MA_NGHE_NGHIEP]='{0}' ", value);
                                            sb.AppendFormat("OR [MA_NGHE_NGHIEP_C1]='{0}' ", value);
                                            sb.AppendFormat("OR [MA_NGHE_NGHIEP_C2]='{0}' ", value);
                                            sb.AppendFormat("OR [MA_NGHE_NGHIEP_C3]='{0}' ", value);
                                            sb.AppendFormat("OR [MA_NGHE_NGHIEP_C4]='{0}' ", value);
                                            sb.AppendFormat("OR [MA_NGHE_NGHIEP_C5]='{0}' ", value);
                                            string ngheNghiep = SQLHelper.ExecuteScalar<string>(sb.ToString());
                                            if (string.IsNullOrWhiteSpace(ngheNghiep)) lstError.Add(error);
                                        }
                                        break;
                                    }
                                case "140002":
                                    {
                                        if (!int.TryParse(value, out int kq) || kq < 1 || kq > 7) lstError.Add(error);
                                        break;
                                    }
                                case "141002":
                                    {
                                        if (!int.TryParse(value, out int kq) || kq < 1 || kq > 5) lstError.Add(error);
                                        break;
                                    }
                                case "159002":
                                    {
                                        if (!double.TryParse(value, out double kq)) lstError.Add(error);
                                        break;
                                    }
                                default:
                                    break;
                            }
                        }

                    }
                }
            }
            return lstError;
        }
        #endregion
        #region Events
        private void FrmQuanLyXml_Load(object sender, EventArgs e)
        {
            OnInit();
        }
        private void txtMaLK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }
        private void pnlButtons_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (e.Button is WindowsUIButton btn)
            {
                switch (btn.Tag?.ToString())
                {
                    case "cmdImportFolder": OnImportXmlFolder(); break;
                    case "cmdOpenXmlFile": OnOpenXmlFile(); break;
                    case "cmdCheckXml": OnSaveToDB(); break;
                    case "cmdExportXml": OnExportXml(); break;
                    case "cmdSendApi": OnSendAPI(); break;
                    default: break;
                }
            }
        }
        private void cboXmlTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private class ClsError
        {
            public string Item { get; set; }
            public string MaLoiCha { get; set; }
            public string MaLoiCon { get; set; }
            public string NoiDungLoi { get; set; }
        }
    }

    public class XmlHelper
    {
        /// <summary>
        /// Đọc file XML giám định hồ sơ vào Dataset với các table tương ứng XML 1, XML 2,...
        /// </summary>
        /// <param name="xmlFile">Đường dẫn file</param>
        /// <returns></returns>
        public static DataSet LoadXmlFile(string xmlFile)
        {
            if (!File.Exists(xmlFile)) return null;
            DataSet dsXmlOpenned = new DataSet();
            DataSet dsXmlFile = new DataSet();
            dsXmlFile.ReadXml(xmlFile);
            #region LẤY THÔNG TIN HỒ SƠ
            DataTable dtGiamDinhHoSo = new DataTable("XML_GIAMDINHHS");
            dtGiamDinhHoSo.Columns.Add("ID");
            dtGiamDinhHoSo.Columns.Add("KEY");
            dtGiamDinhHoSo.Columns.Add("MA_LK");
            dtGiamDinhHoSo.Columns.Add("MACSKCB");
            dtGiamDinhHoSo.Columns.Add("NGAYLAP");
            dtGiamDinhHoSo.Columns.Add("SOLUONGHOSO");
            DataRow drGiamDinhHoSo = dtGiamDinhHoSo.NewRow();
            if (dsXmlFile.Tables.Contains("THONGTINDONVI"))
            {
                drGiamDinhHoSo["MACSKCB"] = dsXmlFile.Tables["THONGTINDONVI"].Rows[0]["MACSKCB"].ToString();
            }
            if (dsXmlFile.Tables.Contains("THONGTINHOSO"))
            {
                drGiamDinhHoSo["NGAYLAP"] = dsXmlFile.Tables["THONGTINHOSO"].Rows[0]["NGAYLAP"].ToString();
                drGiamDinhHoSo["SOLUONGHOSO"] = dsXmlFile.Tables["THONGTINHOSO"].Rows[0]["SOLUONGHOSO"].ToString();
            }
            dtGiamDinhHoSo.Rows.Add(drGiamDinhHoSo);
            dsXmlOpenned.Tables.Add(dtGiamDinhHoSo);
            #endregion
            #region ĐỌC FILE HỒ SƠ
            if (dsXmlFile.Tables.Contains("FILEHOSO") && dsXmlFile.Tables["FILEHOSO"].Rows.Count > 0)
            {
                foreach (DataRow drFileHoSo in dsXmlFile.Tables["FILEHOSO"].Rows)
                {
                    string xmlType = drFileHoSo["LOAIHOSO"].ToString();
                    string xmlContent = drFileHoSo["NOIDUNGFILE"].ToString();

                    using (Stream stream = EasyEncoding.GenerateStreamFromString(EasyEncoding.Base64Decode(xmlContent)))
                    {
                        DataSet dsXmlType = new DataSet();
                        dsXmlType.ReadXml(stream);
                        if (dsXmlType.Tables.Count > 0)
                        {
                            foreach (DataTable dtXmlType in dsXmlType.Tables)
                            {
                                if (dtXmlType.Columns.Contains("MA_LK") && dtXmlType.Rows.Count > 0)
                                {
                                    if (dtGiamDinhHoSo.Rows[0].IsNull("MA_LK")
                                        && !dtXmlType.Rows[0].IsNull("MA_LK"))
                                    {
                                        dtGiamDinhHoSo.Rows[0]["MA_LK"] = dtXmlType.Rows[0]["MA_LK"];
                                    }
                                    DataTable dt = dtXmlType.DefaultView.ToTable(xmlType);
                                    dsXmlOpenned.Tables.Add(dt);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            return dsXmlOpenned;
        }

        /// <summary>
        /// Cập nhật dữ liệu bảng tương ứng file XML trong DB
        /// </summary>
        /// <param name="dtXmlType">Dữ liệu đầu vào với TableName là XmlType</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static bool UpdateXmlType2Db(string xmlTypeName, DataTable dtXmlType, Action<string, bool> callback = null)
        {
            DataTable dtInfo = SQLHelper.GetTableInfo(xmlTypeName);
            if (dtInfo != null && dtInfo.Rows.Count > 0)
            {
                if (dtXmlType.Rows.Count > 0)
                {
                    using (SqlConnection conn = new SqlConnection(SQLHelper.Connectionstring))
                    {
                        conn.Open();
                        using (SqlTransaction trans = conn.BeginTransaction())
                        {
                            foreach (DataRow dr in dtXmlType.Rows)
                            {
                                #region XÂY DỰNG QUERY UPDATE
                                string stt = string.Empty;
                                string maLK = dr["MA_LK"].ToString();
                                StringBuilder sbWhere = new StringBuilder();
                                StringBuilder sbUpdate = new StringBuilder();
                                sbUpdate.AppendFormat("UPDATE [{0}] SET [MA_LK]='{1}' ", xmlTypeName, maLK);
                                sbWhere.AppendFormat("WHERE [MA_LK]='{0}' ", maLK);
                                if (dtXmlType.Columns.Contains("STT"))
                                {
                                    stt = dr["STT"].ToString();
                                    sbWhere.AppendFormat("AND [STT]='{0}' ", stt);
                                }
                                sbWhere.Append("AND ( 1=2 ");
                                #region KIỂM TRA TÍNH HỢP LỆ CỦA DỮ LIỆU
                                foreach (DataRow drInfo in dtInfo.Rows)
                                {
                                    string colName = drInfo["ColumnName"].ToString();
                                    if (colName != "MA_LK" && colName != "STT" && dtXmlType.Columns.Contains(colName))
                                    {
                                        string value = dr[colName].ToString().Replace("'", "''");
                                        bool isNullable = drInfo["AllowDBNull"].ToString().ToUpper() == "TRUE";
                                        if (!string.IsNullOrWhiteSpace(value))
                                        {
                                            sbWhere.AppendFormat("OR [{0}] IS NULL ", colName);
                                            SqlDbType sqlType = (SqlDbType)(int)drInfo["ProviderType"];
                                            switch (sqlType)
                                            {
                                                case SqlDbType.DateTime:
                                                case SqlDbType.DateTime2:
                                                case SqlDbType.SmallDateTime:
                                                case SqlDbType.DateTimeOffset:
                                                    {
                                                        if (DateTime.TryParse(value, out DateTime dtValue))
                                                        {
                                                            value = EasyDateTimeClass.ConvertDateTime(dtValue,
                                                                CultureInfo.CurrentCulture.DateTimeFormat.SortableDateTimePattern);
                                                        }
                                                        sbUpdate.AppendFormat(",[{0}]=CONVERT(DATETIME,'{1}') ", colName, value);
                                                        sbWhere.AppendFormat("OR [{0}]!=CONVERT(DATETIME,'{1}' ", colName, value);
                                                        break;
                                                    }
                                                case SqlDbType.Date:
                                                    {
                                                        if (DateTime.TryParse(value, out DateTime dtValue))
                                                        {
                                                            value = dtValue.ToString("yyyyMMdd");
                                                        }
                                                        sbUpdate.AppendFormat(",[{0}]=CONVERT(DATE,'{1}') ", colName, value);
                                                        sbWhere.AppendFormat("OR FORMAT([{0}],'yyyyMMdd')!='{1}' ", colName, value);
                                                        break;
                                                    }
                                                case SqlDbType.NVarChar:
                                                    sbUpdate.AppendFormat(",[{0}]=N'{1}' ", colName, value);
                                                    sbWhere.AppendFormat("OR [{0}]!=N'{1}' ", colName, value);
                                                    break;
                                                default:
                                                    sbUpdate.AppendFormat(",[{0}]='{1}' ", colName, value);
                                                    sbWhere.AppendFormat("OR [{0}]!='{1}' ", colName, value);
                                                    break;
                                            }
                                        }
                                        else if (isNullable)
                                        {
                                            sbUpdate.AppendFormat(",[{0}]=NULL ", colName);
                                            sbWhere.AppendFormat("OR [{0}] IS NOT NULL ", colName);
                                        }
                                        else
                                        {
                                            StringBuilder sb = new StringBuilder();
                                            sb.AppendFormat("Loại hồ sơ: {0}\nLượt khám: {1}\n", xmlTypeName, maLK);
                                            if (!string.IsNullOrWhiteSpace("STT")) sb.AppendFormat("Số thứ tự: {0}\n", stt);
                                            sb.AppendFormat("Cột {0} không được để trống!\n", colName);
                                            sb.AppendLine("Cập nhật dữ liệu vào CSDL thất bại!");
                                            callback?.Invoke(sb.ToString(), false);
                                            return false;
                                        }
                                    }
                                }
                                #endregion
                                sbWhere.AppendLine(");");
                                sbUpdate.Append(sbWhere);
                                #endregion
                                #region THỰC THI QUERY UPDATE
                                using (SqlCommand command = new SqlCommand(sbUpdate.ToString(), conn, trans))
                                {
                                    StringBuilder sb = new StringBuilder();
                                    sb.AppendFormat("Loại hồ sơ: {0}\nLượt khám: {1}\n", xmlTypeName, maLK);
                                    if (!string.IsNullOrWhiteSpace("STT")) sb.AppendFormat("Số thứ tự: {0}\n", stt);
                                    try
                                    {
                                        int result = command.ExecuteNonQuery();
                                        if (result > 0)
                                        {
                                            sb.AppendLine("Cập nhật thành công!");
                                            callback?.Invoke(sb.ToString(), true);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        sb.AppendLine(ex.Message);
                                        callback?.Invoke(sb.ToString(), false);
                                    }
                                    return false;
                                }
                                #endregion
                            }
                            trans.Commit();
                            callback?.Invoke(string.Format("Loại hồ sơ: {0}\nCập nhật dữ liệu vào CSDL hoàn tất!", xmlTypeName), true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Ghi dữ liệu từ file XML vào bảng tương ứng trong DB
        /// </summary>
        /// <param name="dtXmlType">Dữ liệu đầu vào với TableName là XmlType</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static bool ImportXmlType2Db(string xmlTypeName, DataTable dtXmlType, Action<string, bool> callback = null)
        {
            bool isOk = true;
            try
            {
                DataTable dtInfo = SQLHelper.GetTableInfo(xmlTypeName);
                if (dtInfo != null && dtInfo.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtXmlType.Rows)
                    {
                        bool isFirstRowError = true;
                        string stt = string.Empty;
                        string maLK = dr["MA_LK"].ToString();
                        #region XÂY DỰNG QUERY INSERT
                        StringBuilder sbValues = new StringBuilder();
                        StringBuilder sbColumns = new StringBuilder();
                        sbColumns.Append("MA_LK");
                        sbValues.AppendFormat("'{0}'", maLK);
                        foreach (DataRow drInfo in dtInfo.Rows)
                        {
                            string colName = drInfo["ColumnName"].ToString();
                            if (colName != "MA_LK" && dtXmlType.Columns.Contains(colName))
                            {
                                string value = dr[colName].ToString().Replace("'", "''");
                                bool isNullable = drInfo["AllowDBNull"].ToString().ToUpper() == "TRUE";
                                if (!string.IsNullOrWhiteSpace(value))
                                {
                                    sbColumns.AppendFormat(",{0}", colName);
                                    SqlDbType sqlType = (SqlDbType)(int)drInfo["ProviderType"];
                                    switch (sqlType)
                                    {
                                        case SqlDbType.DateTime:
                                        case SqlDbType.DateTime2:
                                        case SqlDbType.SmallDateTime:
                                        case SqlDbType.DateTimeOffset:
                                            {
                                                if (DateTime.TryParse(value, out DateTime dtValue))
                                                {
                                                    value = EasyDateTimeClass.ConvertDateTime(dtValue,
                                                        CultureInfo.CurrentCulture.DateTimeFormat.SortableDateTimePattern);
                                                }
                                                sbValues.AppendFormat(",CONVERT(DATETIME,'{0}')", value);
                                                break;
                                            }
                                        case SqlDbType.Date:
                                            {
                                                if (DateTime.TryParse(value, out DateTime dtValue))
                                                {
                                                    value = dtValue.ToString("yyyyMMdd");
                                                }
                                                sbValues.AppendFormat(",CONVERT(DATE,'{0}')", value);
                                                break;
                                            }
                                        case SqlDbType.NVarChar:
                                            sbValues.AppendFormat(",N'{0}'", value);
                                            break;
                                        default:
                                            sbValues.AppendFormat(",'{0}'", value);
                                            break;
                                    }
                                    if (colName == "STT")
                                    {
                                        stt = value;
                                    }
                                }
                                else if (!isNullable)
                                {
                                    isOk = false;
                                    if (isFirstRowError)
                                    {
                                        isFirstRowError = false;
                                        callback?.Invoke(string.Format("Loại hồ sơ: {0}\nLượt khám: {1}", xmlTypeName, maLK), false);
                                    }
                                    callback?.Invoke(string.Format("Cột {0} không được để trống!", colName), false);
                                }
                            }
                        }
                        #endregion
                        #region THỰC THI QUERY INSERT
                        if (isOk)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendFormat("INSERT INTO {0} ({1}) SELECT {2} ", xmlTypeName, sbColumns, sbValues);
                            sb.AppendFormat("WHERE NOT EXISTS ( SELECT 1 FROM {0} WHERE MA_LK='{1}' ", xmlTypeName, maLK);
                            if (!string.IsNullOrWhiteSpace(stt))
                            {
                                sb.AppendFormat("AND STT='{0}' ", stt);
                            }
                            sb.Append(");");
                            int result = SQLHelper.ExecuteNonQuery(sb.ToString());
                            if (result < 1)
                            {
                                StringBuilder sbMessage = new StringBuilder();
                                sbMessage.AppendFormat("Loại hồ sơ: {0}\n", xmlTypeName);
                                sbMessage.AppendFormat("Lượt khám: {0}\n", maLK);
                                sbMessage.AppendFormat("Số thứ tự: {0}\n", stt);
                                sbMessage.AppendLine("Thêm dữ liệu vào CSDL thất bại!");
                                callback?.Invoke(sb.ToString(), false);
                            }
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                callback?.Invoke(string.Format("Loại hồ sơ: {0}\n{1}", xmlTypeName, ex.Message), false);
            }
            return isOk;
        }

        /// <summary>
        /// Ghi dữ liệu XML 1, XML 2,... ra file xml và trả về chuỗi base64
        /// </summary>
        /// <param name="dtXmlType">Dữ liệu đầu vào với TableName là XmlType</param>
        /// <param name="xmlTypePath">Đường dẫn file xml được xuất</param>
        /// <param name="writerSettings">Cấu hình XmlWriter</param>
        /// <returns>File XML được mã hóa base64</returns>
        public static string WriteXmlType2Xml(string xmlTypeName, DataTable dtXmlType, string xmlTypePath = null, XmlWriterSettings writerSettings = null)
        {
            StringBuilder sbFileHoSoXml = new StringBuilder();
            using (XmlWriter writerXml = XmlWriter.Create(sbFileHoSoXml, writerSettings))
            {
                writerXml.WriteStartDocument();
                switch (xmlTypeName)
                {
                    case "XML1":
                        {
                            foreach (DataRow drXmlType in dtXmlType.Rows)
                            {
                                writerXml.WriteStartElement("TONG_HOP");
                                foreach (DataColumn col in dtXmlType.Columns)
                                {
                                    string value = drXmlType[col].ToString();
                                    writerXml.WriteElementString(col.ColumnName, value);
                                }
                                writerXml.WriteEndElement();
                            }
                            break;
                        }
                    case "XML2":
                        {
                            writerXml.WriteStartElement("CHITIEU_CHITIET_THUOC");
                            writerXml.WriteStartElement("DSACH_CHI_TIET_THUOC");
                            foreach (DataRow drXmlType in dtXmlType.Rows)
                            {
                                writerXml.WriteStartElement("CHI_TIET_THUOC");
                                foreach (DataColumn col in dtXmlType.Columns)
                                {
                                    string value = drXmlType[col].ToString();
                                    writerXml.WriteElementString(col.ColumnName, value);
                                }
                                writerXml.WriteEndElement();
                            }
                            writerXml.WriteEndElement();
                            writerXml.WriteEndElement();
                            break;
                        }
                    case "XML3":
                        {
                            writerXml.WriteStartElement("CHITIEU_CHITIET_DVKT_VTYT");
                            writerXml.WriteStartElement("DSACH_CHI_TIET_DVKT");
                            foreach (DataRow drXmlType in dtXmlType.Rows)
                            {
                                writerXml.WriteStartElement("CHI_TIET_DVKT");
                                foreach (DataColumn col in dtXmlType.Columns)
                                {
                                    string value = drXmlType[col].ToString();
                                    writerXml.WriteElementString(col.ColumnName, value);
                                }
                                writerXml.WriteEndElement();
                            }
                            writerXml.WriteEndElement();
                            writerXml.WriteEndElement();
                            break;
                        }
                    case "XML4":
                        {
                            writerXml.WriteStartElement("CHITIEU_CHITIET_DICHVUCANLAMSANG");
                            writerXml.WriteStartElement("DSACH_CHI_TIET_CLS");
                            foreach (DataRow drXmlType in dtXmlType.Rows)
                            {
                                writerXml.WriteStartElement("CHI_TIET_CLS");
                                foreach (DataColumn col in dtXmlType.Columns)
                                {
                                    string value = drXmlType[col].ToString();
                                    writerXml.WriteElementString(col.ColumnName, value);
                                }
                                writerXml.WriteEndElement();
                            }
                            writerXml.WriteEndElement();
                            writerXml.WriteEndElement();
                            break;
                        }
                    case "XML5":
                        {
                            writerXml.WriteStartElement("CHITIEU_CHITIET_DIENBIENLAMSANG");
                            writerXml.WriteStartElement("DSACH_CHI_TIET_DIEN_BIEN_BENH");
                            foreach (DataRow drXmlType in dtXmlType.Rows)
                            {
                                writerXml.WriteStartElement("CHI_TIET_DIEN_BIEN_BENH");
                                foreach (DataColumn col in dtXmlType.Columns)
                                {
                                    string value = drXmlType[col].ToString();
                                    writerXml.WriteElementString(col.ColumnName, value);
                                }
                                writerXml.WriteEndElement();
                            }
                            writerXml.WriteEndElement();
                            writerXml.WriteEndElement();
                            break;
                        }
                    case "XML6":
                        {
                            writerXml.WriteStartElement("CHI_TIEU_HO_SO_BENH_AN_CHAM_SOC_VA_DIEU_TRI_HIV_AIDS");
                            writerXml.WriteStartElement("DSACH_HO_SO_BENH_AN_CHAM_SOC_VA_DIEU_TRI_HIV_AIDS");
                            foreach (DataRow drXmlType in dtXmlType.Rows)
                            {
                                writerXml.WriteStartElement("CHI_TIET_DIEN_BIEN_BENH");
                                foreach (DataColumn col in dtXmlType.Columns)
                                {
                                    string value = drXmlType[col].ToString();
                                    writerXml.WriteElementString(col.ColumnName, value);
                                }
                                writerXml.WriteEndElement();
                            }
                            writerXml.WriteEndElement();
                            writerXml.WriteEndElement();
                            break;
                        }
                    case "XML7":
                        {
                            foreach (DataRow drXmlType in dtXmlType.Rows)
                            {
                                writerXml.WriteStartElement("CHI_TIEU_DU_LIEU_GIAY_RA_VIEN");
                                foreach (DataColumn col in dtXmlType.Columns)
                                {
                                    string value = drXmlType[col].ToString();
                                    writerXml.WriteElementString(col.ColumnName, value);
                                }
                                writerXml.WriteEndElement();
                            }
                            break;
                        }
                    case "XML8":
                        {
                            foreach (DataRow drXmlType in dtXmlType.Rows)
                            {
                                writerXml.WriteStartElement("CHI_TIEU_DU_LIEU_TOM_TAT_HO_SO_BENH_AN");
                                foreach (DataColumn col in dtXmlType.Columns)
                                {
                                    string value = drXmlType[col].ToString();
                                    writerXml.WriteElementString(col.ColumnName, value);
                                }
                                writerXml.WriteEndElement();
                            }
                            break;
                        }
                    case "XML9":
                        {
                            writerXml.WriteStartElement("CHI_TIEU_DU_LIEU_GIAY_CHUNG_SINH");
                            writerXml.WriteStartElement("DSACH_GIAYCHUNGSINH");
                            foreach (DataRow drXmlType in dtXmlType.Rows)
                            {
                                writerXml.WriteStartElement("DU_LIEU_GIAY_CHUNG_SINH");
                                foreach (DataColumn col in dtXmlType.Columns)
                                {
                                    string value = drXmlType[col].ToString();
                                    writerXml.WriteElementString(col.ColumnName, value);
                                }
                                writerXml.WriteEndElement();
                            }
                            writerXml.WriteEndElement();
                            writerXml.WriteEndElement();
                            break;
                        }
                    case "XML10":
                        {
                            foreach (DataRow drXmlType in dtXmlType.Rows)
                            {
                                writerXml.WriteStartElement("CHI_TIEU_DU_LIEU_GIAY_NGHI_DUONG_THAI");
                                foreach (DataColumn col in dtXmlType.Columns)
                                {
                                    string value = drXmlType[col].ToString();
                                    writerXml.WriteElementString(col.ColumnName, value);
                                }
                                writerXml.WriteEndElement();
                            }
                            break;
                        }
                    case "XML11":
                        {
                            foreach (DataRow drXmlType in dtXmlType.Rows)
                            {
                                writerXml.WriteStartElement("CHI_TIEU_DU_LIEU_GIAY_CHUNG_NHAN_NGHI_VIEC_HUONG_BAO_HIEM_XA_HOI");
                                foreach (DataColumn col in dtXmlType.Columns)
                                {
                                    string value = drXmlType[col].ToString();
                                    writerXml.WriteElementString(col.ColumnName, value);
                                }
                                writerXml.WriteEndElement();
                            }
                            break;
                        }
                    default:
                        break;
                }
                writerXml.WriteEndDocument();
                writerXml.Flush();
            }
            if (!string.IsNullOrWhiteSpace(xmlTypePath))
            {
                File.WriteAllText(xmlTypePath, sbFileHoSoXml.ToString());
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(sbFileHoSoXml.ToString()));
        }
    }
    public class ClientHelper
    {
        private const string HEADER_TOKENID = "tokenId";
        private const string HEADER_ACCESS_TOKEN = "accessToken";
        private const string HEADER_PASSWORDHASH = "passwordHash";
        private readonly HttpClient _client = new HttpClient();
        private static readonly Lazy<ClientHelper> _instance = new Lazy<ClientHelper>();

        public static ClientHelper Instance => _instance.Value;

        /// <summary>
        /// Đăng nhập API để lấy token và lưu vào default header của httpclient
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string username, string password, Action<string, bool> callback = null)
        {
            password = EasyEncoding.SHA1MD5.MD5Hasn(password).ToUpper();
            string jsonContent = JsonConvert.SerializeObject(new { username, password });
            StringContent content = new StringContent(jsonContent, encoding: Encoding.UTF8, mediaType: "application/json");
            Task<HttpResponseMessage> responseTask = Task.Run(async () =>
                await _client.PostAsync("https://daotaoegw.baohiemxahoi.gov.vn/api/token/take", content).ConfigureAwait(false)
            );
            while (!responseTask.IsCompleted) { }
            HttpResponseMessage responseMsg = responseTask.Result;
            if (responseMsg.IsSuccessStatusCode)
            {
                Task<string> contentTask = Task.Run(async () => await responseMsg.Content.ReadAsStringAsync());
                while (!contentTask.IsCompleted) { }
                LoginResponse response = JsonConvert.DeserializeObject<LoginResponse>(contentTask.Result);
                if (response.maKetQua == "200")
                {
                    _client.DefaultRequestHeaders.Add(HEADER_ACCESS_TOKEN, response.APIKey.access_token);
                    _client.DefaultRequestHeaders.Add(HEADER_TOKENID, response.APIKey.id_token);
                    _client.DefaultRequestHeaders.Add(HEADER_PASSWORDHASH, password);
                    callback?.Invoke(string.Format("Username: {0} đăng nhập thành công", username), true);
                    return true;
                }
            }
            callback?.Invoke(string.Format("Username: {0} đăng nhập thất bại", username), false);
            return false;
        }

        /// <summary>
        /// Gửi file Xml đã được mã hóa Base64
        /// </summary>
        /// <param name="request"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public bool SendBase64Xml(SendXmlRequest request, Action<string, bool> callback = null)
        {
            if (!_client.DefaultRequestHeaders.Contains(HEADER_ACCESS_TOKEN))
            {
                callback?.Invoke("Chưa đăng nhập", false);
                return false;
            }
            string jsonString = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> responseTask = Task.Run(
                async () => await _client.PostAsync("https://daotaoegw.baohiemxahoi.gov.vn/api/qd130/guiHoSoXmlQD130", content).ConfigureAwait(false)
            );
            while (!responseTask.IsCompleted) { }
            HttpResponseMessage responseMsg = responseTask.Result;
            if (responseMsg.IsSuccessStatusCode)
            {
                Task<string> contentTask = Task.Run(async () => await responseMsg.Content.ReadAsStringAsync());
                while (!contentTask.IsCompleted) { }
                SendXmlResponse response = JsonConvert.DeserializeObject<SendXmlResponse>(contentTask.Result);
                bool isOk = response.maKetQua == "200";
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("Kết quả: {0}\n", response.maKetQua);
                sb.AppendFormat("Mã giao dịch: {0}\n", response.maGiaoDich);
                sb.AppendFormat("Thông điệp: {0}\n", response.thongDiep);
                sb.AppendFormat("Thời gian tiếp nhận: {0}\n", response.thoiGianTiepNhan);
                callback?.Invoke(sb.ToString(), isOk);
                return isOk;
            }
            return false;
        }

        public class LoginResponse
        {
            public string maKetQua { get; set; }
            public LoginResult APIKey { get; set; }
        }

        public class LoginResult
        {
            public string access_token { get; set; }
            public string id_token { get; set; }
            public string token_type { get; set; }
            public string username { get; set; }
            public DateTime expires_in { get; set; }
        }

        public class SendXmlRequest
        {
            public string username { get; set; }
            public string loaiHoSo { get; set; } = "130";
            public string maTinh { get; set; } = "26";
            public string maCSKCB { get; set; } = "26001";
            public string fileHSBase64 { get; set; }
        }

        public class SendXmlResponse
        {
            public string maKetQua { get; set; }
            public string maGiaoDich { get; set; }
            public string thoiGianTiepNhan { get; set; }
            public string thongDiep { get; set; }
        }
    }
}