using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using XML130.EasyUtils;
using XML130.Libraries;

namespace XML130.XML
{
    public partial class FrmDmQD130_ImportXml : XtraForm
    {
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
                string table = "_GIAMDINHHS";
                if (!string.IsNullOrWhiteSpace(txtXmlType.Text))
                {
                    table = txtXmlType.Text;
                }
                string sql = string.Format("SELECT * FROM XML{0} WHERE '{1}'='' OR MA_LK='{1}'", table, txtMaLK.Text);
                DataTable dataTable = SQLHelper.ExecuteDataTable(sql);
                gc_data.DataSource = dataTable;
                gv_data.BestFitColumns();
            }
            catch (Exception exception)
            {
                EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");
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
                                if (!InsertTable(xmlType, xmlContent, out MA_LK))
                                {
                                    AddErrorLog("Thêm thông tin giám định hồ sơ thất bại!");
                                    AddErrorLog(string.Format("Đường dẫn file: {0}", xmlFile));
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
                                AddLog("Thêm thông tin giám định hồ sơ hoàn tất!");
                                AddLog(string.Format("Mã liên kết: {0}", MA_LK));
                                AddLog(string.Format("Đường dẫn file: {0}", xmlFile));
                            }
                            else
                            {
                                AddErrorLog("Thêm thông tin giám định hồ sơ thất bại!");
                                AddErrorLog(string.Format("Mã liên kết: {0}", MA_LK));
                                AddErrorLog(string.Format("Đường dẫn file: {0}", xmlFile));
                            }
                            #endregion
                        }
                        #endregion
                    }
                }
                finally
                {
                    EasyLoadWait.CloseWaitForm();
                }
            }
        }
        protected virtual void OnExportXml()
        {
        }
        #endregion
        #region Private methods
        private void AddLog(string message)
        {
            lvLogs.Items.Add(new ListViewItem(new string[] { string.Format("{0:HH:mm:ss}", DateTime.Now), message })
            { ForeColor = Color.Blue });
        }
        private void AddErrorLog(string message)
        {
            lvLogs.Items.Add(new ListViewItem(new string[] { string.Format("{0:HH:mm:ss}", DateTime.Now), message })
            { ForeColor = Color.Red });
        }
        private bool InsertTable(string xmlType, string xmlContent, out string MA_LK)
        {
            bool isOk = true;
            MA_LK = string.Empty;
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
                                                        sbValues.AppendFormat(",CONVERT(DATETIME,'{0}')", value);
                                                        break;
                                                    case SqlDbType.Date:
                                                        sbValues.AppendFormat(",CONVERT(DATE,'{0}')", value);
                                                        break;
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
                                                    AddErrorLog(string.Format("Mã liên kết: {0}", MA_LK));
                                                    AddErrorLog(string.Format("Loại hồ sơ: {0}", xmlType));
                                                }
                                                AddErrorLog(string.Format("Cột {0} không được để trống!", colName));
                                            }
                                        }
                                    }
                                    #endregion
                                    if (isOk)
                                    {
                                        #region THỰC THI QUERY INSERT
                                        StringBuilder sb = new StringBuilder();
                                        sb.AppendFormat("INSERT INTO {0} ({1}) SELECT {2} ", xmlType, sbColumns, sbValues);
                                        sb.AppendFormat("WHERE NOT EXISTS ( SELECT 1 FROM {0} WHERE MA_LK='{1}' ", xmlType, MA_LK);
                                        if (!string.IsNullOrWhiteSpace(STT))
                                        {
                                            sb.AppendFormat("AND STT='{0}' ", STT);
                                        }
                                        sb.Append(");");
                                        int result = SQLHelper.ExecuteNonQuery(sb.ToString());
                                        if (result < 0)
                                        {
                                            AddErrorLog("Thêm dữ liệu vào CSDL thất bại!");
                                            AddErrorLog(string.Format("Mã liên kết: {0}", MA_LK));
                                            AddErrorLog(string.Format("Loại hồ sơ: {0}", xmlType));
                                            AddErrorLog(string.Format("Số thứ tự: {0}", STT));
                                        }
                                        #endregion
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return isOk;
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

        }
        private void btnExportAPI_Click(object sender, EventArgs e)
        {

        }
        private void btnSendAPI_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}