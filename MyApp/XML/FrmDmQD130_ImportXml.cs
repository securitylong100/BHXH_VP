using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using XML130.EasyUtils;
using XML130.Libraries;

namespace XML130.XML
{
    public partial class FrmDmQD130_ImportXml : XtraForm
    {
        private DataTable _dtData = null;
        private string _tableName = string.Empty;
        private readonly XmlWriterSettings _xmlWriterSettings = new XmlWriterSettings() { Encoding = Encoding.UTF8, Indent = true };

        public FrmDmQD130_ImportXml()
        {
            InitializeComponent();
        }

        #region Protected methods
        protected virtual void OnInit()
        {
            try
            {
                gc_data.DataSource = null;
                gv_data.Columns.Clear();
                gv_data.RefreshData();

                lvLogs.Items.Clear();
                _tableName = "XML_GIAMDINHHS";
                if (!string.IsNullOrWhiteSpace(txtXmlType.Text))
                {
                    _tableName = string.Format("XML{0}", txtXmlType.Text);
                }
                EasyLoadWait.ShowWaitForm(string.Format("Tải dữ liệu bảng {0}", _tableName), this);
                string sql = string.Format("SELECT * FROM {0} WHERE '{1}'='' OR MA_LK='{1}'", _tableName, txtMaLK.Text);
                _dtData = SQLHelper.ExecuteDataTable(sql);
                if (_dtData == null)
                {
                    WriteLog(string.Format("- Bảng {0} không tồn tại.", _tableName), false);
                }
                else
                {
                    WriteLog(string.Format("- Tổng cộng: {0} dòng dữ liệu", _dtData.Rows.Count), true);
                }
                gc_data.DataSource = _dtData;
                gv_data.BestFitColumns();
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
        protected virtual void OnSaveToDB()
        {
            if (!string.IsNullOrWhiteSpace(_tableName) && _dtData != null)
            {
                lvLogs.Items.Clear();
                EasyLoadWait.ShowWaitForm(string.Format("Đang cập nhật dữ liệu bảng {0}", _tableName), this);
                try
                {
                    UpdateXmlTable(_tableName, _dtData);
                }
                catch (Exception exception)
                {
                    EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");
                }
                finally
                {
                    EasyLoadWait.CloseWaitForm();
                    OnInit();
                }
            }
        }
        protected virtual void OnImportXml()
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
                lvLogs.Items.Clear();
                EasyLoadWait.ShowWaitForm("Đang import", this);
                try
                {
                    string folderPath = Path.GetDirectoryName(openFolder.FileName);
                    string[] xmlFiles = Directory.GetFiles(folderPath, "*.xml", SearchOption.AllDirectories);
                    foreach (string xmlFile in xmlFiles)
                    {
                        #region LẤY THÔNG TIN HỒ SƠ
                        string MA_LK = string.Empty;
                        string MACSKCB = string.Empty;
                        string NGAYLAP = string.Empty;
                        string SOLUONGHOSO = string.Empty;
                        DataSet dsGIAMDINHHS = new DataSet();
                        dsGIAMDINHHS.ReadXml(xmlFile);
                        if (dsGIAMDINHHS.Tables.Contains("THONGTINDONVI"))
                        {
                            MACSKCB = dsGIAMDINHHS.Tables["THONGTINDONVI"].Rows[0]["MACSKCB"].ToString();
                        }
                        if (dsGIAMDINHHS.Tables.Contains("THONGTINHOSO"))
                        {
                            NGAYLAP = dsGIAMDINHHS.Tables["THONGTINHOSO"].Rows[0]["NGAYLAP"].ToString();
                            SOLUONGHOSO = dsGIAMDINHHS.Tables["THONGTINHOSO"].Rows[0]["SOLUONGHOSO"].ToString();
                        }
                        #endregion
                        #region ĐỌC FILE HỒ SƠ
                        if (dsGIAMDINHHS.Tables.Contains("FILEHOSO") && dsGIAMDINHHS.Tables["FILEHOSO"].Rows.Count > 0)
                        {
                            bool isError = false;
                            foreach (DataRow drFILEHOSO in dsGIAMDINHHS.Tables["FILEHOSO"].Rows)
                            {
                                string xmlType = drFILEHOSO["LOAIHOSO"].ToString();
                                string xmlContent = drFILEHOSO["NOIDUNGFILE"].ToString();
                                MA_LK = ImportXmlTableAndGetMA_LK(xmlType, xmlContent, WriteLog);
                                if (string.IsNullOrWhiteSpace(MA_LK))
                                {
                                    WriteLog(string.Format("- Đường dẫn file: {0}", xmlFile), false);
                                    WriteLog("Thêm thông tin giám định hồ sơ thất bại!", false);
                                    isError = true;
                                    break;
                                }
                            }
                            if (isError) continue;
                            #region CẬP NHẬT HỒ SƠ GIÁM ĐỊNH
                            StringBuilder sb = new StringBuilder();
                            sb.Append("INSERT INTO XML_GIAMDINHHS ([MA_LK],[MACSKCB],[NGAYLAP],[SOLUONGHOSO]) ");
                            sb.AppendFormat("SELECT '{0}','{1}',CONVERT(DATE,'{2}'),'{3}' ", MA_LK, MACSKCB, NGAYLAP, SOLUONGHOSO);
                            sb.AppendFormat("WHERE NOT EXISTS ( SELECT 1 FROM XML_GIAMDINHHS WHERE MA_LK='{0}'); ", MA_LK);
                            int result = SQLHelper.ExecuteNonQuery(sb.ToString());
                            if (result > 0)
                            {
                                WriteLog(string.Format("- Đường dẫn file: {0}", xmlFile), true);
                                WriteLog(string.Format("Mã liên kết: {0}", MA_LK), true);
                                WriteLog("Thêm thông tin giám định hồ sơ hoàn tất!", true);
                            }
                            else
                            {
                                WriteLog(string.Format("- Đường dẫn file: {0}", xmlFile), false);
                                WriteLog(string.Format("Mã liên kết: {0}", MA_LK), false);
                                WriteLog("Thêm thông tin giám định hồ sơ thất bại!", false);
                            }
                            #endregion
                        }
                        #endregion
                    }
                }
                catch (Exception exception)
                {
                    EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");
                }
                finally
                {
                    EasyLoadWait.CloseWaitForm();
                    OnInit();
                }
            }
        }
        protected virtual void OnExportXml()
        {
            if (string.IsNullOrWhiteSpace(txtMaLK.Text))
            {
                WriteLog("- Không thể xuất xml với mã liên kết trống!", false);
                return;
            }
            SaveFileDialog saveFile = new SaveFileDialog()
            {
                FileName = txtMaLK.Text,
                Filter = "XML Document (*.xml)|*.xml|All file (*.*)|*.*"
            };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string sql = string.Format("SELECT * FROM XML_GIAMDINHHS WHERE MA_LK='{0}'", txtMaLK.Text);
                DataTable dtGiamDinhHoSo = SQLHelper.ExecuteDataTable(sql);
                if (dtGiamDinhHoSo != null)
                {
                    foreach (DataRow drHoSo in dtGiamDinhHoSo.Rows)
                    {
                        StringBuilder sbHoSoXml = new StringBuilder();
                        using (XmlWriter writerHoSoXml = XmlWriter.Create(sbHoSoXml, _xmlWriterSettings))
                        {
                            writerHoSoXml.WriteStartDocument();
                            writerHoSoXml.WriteStartElement("GIAMDINHHS");

                            writerHoSoXml.WriteStartElement("THONGTINDONVI");
                            writerHoSoXml.WriteElementString("MACSKCB", drHoSo["MACSKCB"].ToString());
                            writerHoSoXml.WriteEndElement();

                            writerHoSoXml.WriteStartElement("THONGTINHOSO");
                            string NGAYLAP = drHoSo["NGAYLAP"].ToString();
                            if (DateTime.TryParse(NGAYLAP, out DateTime dtValue))
                            {
                                NGAYLAP = dtValue.ToString("yyyyMMdd");
                            }
                            writerHoSoXml.WriteElementString("NGAYLAP", NGAYLAP);
                            writerHoSoXml.WriteElementString("SOLUONGHOSO", drHoSo["SOLUONGHOSO"].ToString());

                            writerHoSoXml.WriteStartElement("DANHSACHHOSO");
                            writerHoSoXml.WriteStartElement("HOSO");
                            writerHoSoXml.WriteStartElement("FILEHOSO");

                            for (int i = 1; i < 12; i++)
                            {
                                string xmlType = string.Format("XML{0}", i);
                                writerHoSoXml.WriteElementString("LOAIHOSO", xmlType);
                                StringBuilder sbFileHoSoXml = new StringBuilder();
                                using (XmlWriter writerXml = XmlWriter.Create(sbFileHoSoXml, _xmlWriterSettings))
                                {
                                    string rowElement = string.Empty;
                                    writerXml.WriteStartDocument();
                                    switch (i)
                                    {
                                        case 1:
                                            {
                                                rowElement = "TONG_HOP";
                                                WriteDbTableToXml(writerXml, rowElement, xmlType, txtMaLK.Text);
                                                break;
                                            }
                                        case 2:
                                            {
                                                writerXml.WriteStartElement("CHITIEU_CHITIET_THUOC");
                                                writerXml.WriteStartElement("DSACH_CHI_TIET_THUOC");
                                                rowElement = "CHI_TIET_THUOC";
                                                WriteDbTableToXml(writerXml, rowElement, xmlType, txtMaLK.Text);
                                                writerXml.WriteEndElement();
                                                writerXml.WriteEndElement();
                                                break;
                                            }
                                        case 3:
                                            {
                                                writerXml.WriteStartElement("CHITIEU_CHITIET_DVKT_VTYT");
                                                writerXml.WriteStartElement("DSACH_CHI_TIET_DVKT");
                                                rowElement = "CHI_TIET_DVKT";
                                                WriteDbTableToXml(writerXml, rowElement, xmlType, txtMaLK.Text);
                                                writerXml.WriteEndElement();
                                                writerXml.WriteEndElement();
                                                break;
                                            }
                                        case 4:
                                            {
                                                writerXml.WriteStartElement("CHITIEU_CHITIET_DICHVUCANLAMSANG");
                                                writerXml.WriteStartElement("DSACH_CHI_TIET_CLS");
                                                rowElement = "CHI_TIET_CLS";
                                                WriteDbTableToXml(writerXml, rowElement, xmlType, txtMaLK.Text);
                                                writerXml.WriteEndElement();
                                                writerXml.WriteEndElement();
                                                break;
                                            }
                                        case 5:
                                            {
                                                writerXml.WriteStartElement("CHITIEU_CHITIET_DIENBIENLAMSANG");
                                                writerXml.WriteStartElement("DSACH_CHI_TIET_DIEN_BIEN_BENH");
                                                rowElement = "CHI_TIET_DIEN_BIEN_BENH";
                                                WriteDbTableToXml(writerXml, rowElement, xmlType, txtMaLK.Text);
                                                writerXml.WriteEndElement();
                                                writerXml.WriteEndElement();
                                                break;
                                            }
                                        case 6:
                                            {
                                                writerXml.WriteStartElement("CHI_TIEU_HO_SO_BENH_AN_CHAM_SOC_VA_DIEU_TRI_HIV_AIDS");
                                                writerXml.WriteStartElement("DSACH_HO_SO_BENH_AN_CHAM_SOC_VA_DIEU_TRI_HIV_AIDS");
                                                rowElement = "CHI_TIET_DIEN_BIEN_BENH";
                                                WriteDbTableToXml(writerXml, rowElement, xmlType, txtMaLK.Text);
                                                writerXml.WriteEndElement();
                                                writerXml.WriteEndElement();
                                                break;
                                            }
                                        case 7:
                                            {
                                                rowElement = "CHI_TIEU_DU_LIEU_GIAY_RA_VIEN";
                                                WriteDbTableToXml(writerXml, rowElement, xmlType, txtMaLK.Text);
                                                break;
                                            }
                                        case 8:
                                            {
                                                rowElement = "CHI_TIEU_DU_LIEU_TOM_TAT_HO_SO_BENH_AN";
                                                WriteDbTableToXml(writerXml, rowElement, xmlType, txtMaLK.Text);
                                                break;
                                            }
                                        case 9:
                                            {
                                                writerXml.WriteStartElement("CHI_TIEU_DU_LIEU_GIAY_CHUNG_SINH");
                                                writerXml.WriteStartElement("DSACH_GIAYCHUNGSINH");
                                                rowElement = "DU_LIEU_GIAY_CHUNG_SINH";
                                                WriteDbTableToXml(writerXml, rowElement, xmlType, txtMaLK.Text);
                                                writerXml.WriteEndElement();
                                                writerXml.WriteEndElement();
                                                break;
                                            }
                                        case 10:
                                            {
                                                rowElement = "CHI_TIEU_DU_LIEU_GIAY_NGHI_DUONG_THAI";
                                                WriteDbTableToXml(writerXml, rowElement, xmlType, txtMaLK.Text);
                                                break;
                                            }
                                        case 11:
                                            {
                                                rowElement = "CHI_TIEU_DU_LIEU_GIAY_CHUNG_NHAN_NGHI_VIEC_HUONG_BAO_HIEM_XA_HOI";
                                                WriteDbTableToXml(writerXml, rowElement, xmlType, txtMaLK.Text);
                                                break;
                                            }
                                        default:
                                            break;
                                    }
                                    //writerXml.WriteEndDocument();
                                    writerXml.Flush();
                                }
                                string xmlBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(sbFileHoSoXml.ToString()));
                                writerHoSoXml.WriteElementString("NOIDUNGFILE", xmlBase64);
                            }

                            writerHoSoXml.WriteEndElement();
                            writerHoSoXml.WriteEndElement();
                            writerHoSoXml.WriteEndElement();

                            writerHoSoXml.WriteEndElement();

                            writerHoSoXml.WriteEndElement();
                            writerHoSoXml.WriteEndDocument();
                            writerHoSoXml.Flush();
                        }
                        File.WriteAllText(saveFile.FileName, sbHoSoXml.ToString());
                    }
                }
            }
        }
        #endregion
        #region Private methods
        private void WriteLog(string message, bool isError)
        {
            lvLogs.Items.Add(new ListViewItem(new string[] { string.Format("{0:HH:mm:ss}", DateTime.Now), message })
            { ForeColor = isError ? Color.Red : Color.Blue });
        }
        private static void WriteDbTableToXml(XmlWriter writer, string rowElement, string xmlType, string MA_LK)
        {
            DataTable dtInfo = SQLHelper.GetTableInfo(xmlType);
            if (dtInfo != null)
            {
                string sql = string.Format("SELECT * FROM {0} WHERE MA_LK='{1}'", xmlType, MA_LK);
                DataTable dtData = SQLHelper.ExecuteDataTable(sql);
                if (dtData != null)
                {
                    foreach (DataRow dr in dtData.Rows)
                    {
                        writer.WriteStartElement(rowElement);
                        foreach (DataRow drInfo in dtInfo.Rows)
                        {
                            string colName = drInfo["ColumnName"].ToString();
                            if (dtData.Columns.Contains(colName))
                            {
                                string value = dr[colName].ToString();
                                if (!string.IsNullOrWhiteSpace(value))
                                {
                                    SqlDbType sqlType = (SqlDbType)(int)drInfo["ProviderType"];
                                    switch (sqlType)
                                    {
                                        case SqlDbType.DateTime:
                                        case SqlDbType.DateTime2:
                                        case SqlDbType.SmallDateTime:
                                        case SqlDbType.DateTimeOffset:
                                        case SqlDbType.Date:
                                            {
                                                if (DateTime.TryParse(value, out DateTime dtValue))
                                                {
                                                    value = dtValue.ToString("yyyyMMdd");
                                                }
                                                writer.WriteElementString(colName, value);
                                                break;
                                            }
                                        case SqlDbType.NVarChar:
                                            {
                                                writer.WriteStartElement(colName);
                                                writer.WriteCData(value);
                                                writer.WriteEndElement();
                                                break;
                                            }
                                        default:
                                            writer.WriteElementString(colName, value);
                                            break;
                                    }
                                }
                                else
                                {
                                    writer.WriteStartElement(colName);
                                    writer.WriteCData(value);
                                    writer.WriteEndElement();
                                }
                            }
                        }
                        writer.WriteEndElement();
                    }
                }
            }
        }
        private static bool UpdateXmlTable(string xmlType, DataTable dtData, Action<string, bool> callback = null)
        {
            DataTable dtInfo = SQLHelper.GetTableInfo(xmlType);
            if (dtInfo != null && dtInfo.Rows.Count > 0)
            {
                if (dtData.Rows.Count > 0)
                {
                    using (SqlConnection conn = new SqlConnection(SQLHelper.Connectionstring))
                    {
                        conn.Open();
                        using (SqlTransaction trans = conn.BeginTransaction())
                        {
                            foreach (DataRow dr in dtData.Rows)
                            {
                                #region XÂY DỰNG QUERY UPDATE
                                string STT = string.Empty;
                                string MA_LK = dr["MA_LK"].ToString();
                                StringBuilder sbWhere = new StringBuilder();
                                StringBuilder sbUpdate = new StringBuilder();
                                sbUpdate.AppendFormat("UPDATE [{0}] SET [MA_LK]='{1}' ", xmlType, MA_LK);
                                sbWhere.AppendFormat("WHERE [MA_LK]='{0}' ", MA_LK);
                                if (dtData.Columns.Contains("STT"))
                                {
                                    STT = dr["STT"].ToString();
                                    sbWhere.AppendFormat("AND [STT]='{0}' ", STT);
                                }
                                sbWhere.Append("AND ( 1=2 ");
                                #region KIỂM TRA TÍNH HỢP LỆ CỦA DỮ LIỆU
                                foreach (DataRow drInfo in dtInfo.Rows)
                                {
                                    string colName = drInfo["ColumnName"].ToString();
                                    if (colName != "MA_LK" && colName != "STT" && dtData.Columns.Contains(colName))
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
                                            callback?.Invoke(string.Format("- Loại hồ sơ: {0}", xmlType), false);
                                            callback?.Invoke(string.Format("Mã liên kết: {0}", MA_LK), false);
                                            callback?.Invoke("Cập nhật dữ liệu vào CSDL thất bại!", false);
                                            if (!string.IsNullOrWhiteSpace("STT"))
                                            {
                                                callback?.Invoke(string.Format("Số thứ tự: {0}", STT), false);
                                            }
                                            callback?.Invoke(string.Format("Cột {0} không được để trống!", colName), false);
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
                                    try
                                    {
                                        int result = command.ExecuteNonQuery();
                                        if (result > 0)
                                        {
                                            callback?.Invoke(string.Format("- Loại hồ sơ: {0}", xmlType), true);
                                            callback?.Invoke(string.Format("Mã liên kết: {0}", MA_LK), true);
                                            if (!string.IsNullOrWhiteSpace("STT"))
                                            {
                                                callback?.Invoke(string.Format("Số thứ tự: {0}", STT), true);
                                            }
                                            callback?.Invoke("Cập nhật thành công!", true);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        callback?.Invoke(string.Format("- Loại hồ sơ: {0}", xmlType), false);
                                        callback?.Invoke(string.Format("Mã liên kết: {0}", MA_LK), false);
                                        if (!string.IsNullOrWhiteSpace("STT"))
                                        {
                                            callback?.Invoke(string.Format("Số thứ tự: {0}", STT), false);
                                        }
                                        callback?.Invoke(ex.Message, false);
                                        return false;
                                    }
                                }
                                #endregion
                            }
                            trans.Commit();
                            callback?.Invoke(string.Format("- Loại hồ sơ: {0}", xmlType), true);
                            callback?.Invoke("Cập nhật dữ liệu vào CSDL hoàn tất!", true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private static string ImportXmlTableAndGetMA_LK(string xmlType, string xmlContent, Action<string, bool> callback = null)
        {
            bool isOk = true;
            string MA_LK = string.Empty;
            try
            {
                DataTable dtInfo = SQLHelper.GetTableInfo(xmlType);
                if (dtInfo != null && dtInfo.Rows.Count > 0)
                {
                    using (Stream stream = EasyEncoding.GenerateStreamFromString(EasyEncoding.Base64Decode(xmlContent)))
                    {
                        DataSet ds = new DataSet();
                        ds.ReadXml(stream);
                        if (ds.Tables.Count > 0)
                        {
                            foreach (DataTable dt in ds.Tables)
                            {
                                if (dt.Columns.Contains("MA_LK") && dt.Rows.Count > 0)
                                {
                                    string STT = string.Empty;
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        #region XÂY DỰNG QUERY INSERT
                                        StringBuilder sbValues = new StringBuilder();
                                        StringBuilder sbColumns = new StringBuilder();
                                        sbColumns.Append("MA_LK");
                                        MA_LK = dr["MA_LK"].ToString();
                                        sbValues.AppendFormat("'{0}'", MA_LK);
                                        bool isFirstRowError = true;
                                        #region KIỂM TRA TÍNH HỢP LỆ CỦA DỮ LIỆU
                                        foreach (DataRow drInfo in dtInfo.Rows)
                                        {
                                            string colName = drInfo["ColumnName"].ToString();
                                            if (colName != "MA_LK" && dt.Columns.Contains(colName))
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
                                                        STT = value;
                                                    }
                                                }
                                                else if (!isNullable)
                                                {
                                                    isOk = false;
                                                    if (isFirstRowError)
                                                    {
                                                        isFirstRowError = false;
                                                        callback?.Invoke(string.Format("- Loại hồ sơ: {0}", xmlType), false);
                                                        callback?.Invoke(string.Format("Mã liên kết: {0}", MA_LK), false);
                                                        //WriteErrorLog(string.Format("- Loại hồ sơ: {0}", xmlType));
                                                        //WriteErrorLog(string.Format("Mã liên kết: {0}", MA_LK));
                                                    }
                                                    callback?.Invoke(string.Format("Cột {0} không được để trống!", colName), false);
                                                    //WriteErrorLog(string.Format("Cột {0} không được để trống!", colName));
                                                }
                                            }
                                        }
                                        #endregion
                                        #endregion
                                        #region THỰC THI QUERY INSERT
                                        if (isOk)
                                        {
                                            StringBuilder sb = new StringBuilder();
                                            sb.AppendFormat("INSERT INTO {0} ({1}) SELECT {2} ", xmlType, sbColumns, sbValues);
                                            sb.AppendFormat("WHERE NOT EXISTS ( SELECT 1 FROM {0} WHERE MA_LK='{1}' ", xmlType, MA_LK);
                                            if (!string.IsNullOrWhiteSpace(STT))
                                            {
                                                sb.AppendFormat("AND STT='{0}' ", STT);
                                            }
                                            sb.Append(");");
                                            int result = SQLHelper.ExecuteNonQuery(sb.ToString());
                                            if (result < 1)
                                            {
                                                callback?.Invoke(string.Format("- Loại hồ sơ: {0}", xmlType), false);
                                                callback?.Invoke(string.Format("Mã liên kết: {0}", MA_LK), false);
                                                callback?.Invoke(string.Format("Số thứ tự: {0}", STT), false);
                                                callback?.Invoke("Thêm dữ liệu vào CSDL thất bại!", false);
                                            }
                                        }
                                        #endregion
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                callback?.Invoke(string.Format("- Loại hồ sơ: {0}", xmlType), false);
                callback?.Invoke(ex.Message, false);
            }
            return isOk ? MA_LK : string.Empty;
        }
        #endregion
        #region Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            OnInit();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            OnImportXml();
        }
        private void btnLoadDB_Click(object sender, EventArgs e)
        {
            OnInit();
        }
        private void btnCheckDB_Click(object sender, EventArgs e)
        {

        }
        private void btnSaveDB_Click(object sender, EventArgs e)
        {
            OnSaveToDB();
        }
        private void btnExportAPI_Click(object sender, EventArgs e)
        {
            OnExportXml();
        }
        private void btnSendAPI_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}