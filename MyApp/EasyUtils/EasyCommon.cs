using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Export;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;

namespace XML130.EasyUtils
{
    internal class EasyCommon
    {
        public static void BestFitColumnsGridView(GridView view)
        {
            if (view.RowCount > 0)
            {
                view.OptionsView.BestFitMaxRowCount = -1;
                view.BestFitColumns();
            }
        }

        public static bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string Unicode(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;

            string result = "";
            string[] words = s.Split(' ');

            foreach (string word in words)
            {
                if (word.Trim() != "")
                {
                    if (word.Length > 1)
                        result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";
                    else
                        result += word.ToUpper() + " ";
                }
            }
            return result.Trim();
        }

        public static string FormatString(string xau)
        {
            StringBuilder kq = new StringBuilder();
            xau = xau.Trim();
            for (int i = 0; i < xau.Length; i++)
            {
                kq.Append(xau[i]);
                if (xau[i] == ' ')
                {
                    while (xau[i] == ' ')
                    {
                        i++;
                    }
                    kq.Append(xau[i]);
                }
            }
            return kq.ToString();
        }

        public static DataTable DataTable(DbContext context, string sqlQuery)
        {
            var dt = new DataTable();
            var dbFactory = DbProviderFactories.GetFactory(context.Database.Connection);

            using (var cmd = dbFactory.CreateCommand())
            {
                if (cmd != null)
                {
                    cmd.Connection = context.Database.Connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sqlQuery;
                    cmd.CommandTimeout = 120;
                    using (var adapter = dbFactory.CreateDataAdapter())
                    {
                        if (adapter != null)
                        {
                            adapter.SelectCommand = cmd;
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
        }

        public static void SetWatermark(TextEdit textEdit, string watermark)
        {
            textEdit.Properties.NullValuePromptShowForEmptyValue = true;
            textEdit.Properties.NullValuePrompt = watermark;
        }

        public static void ClearWatermark(TextEdit textEdit)
        {
            if (textEdit.Properties.NullValuePromptShowForEmptyValue)
                textEdit.Properties.NullValuePrompt = string.Empty;
        }

        public static void ShowHideColumn(GridView view, string colName, bool visible)
        {
            foreach (GridColumn col in view.Columns)
            {
                if (col.Name == colName)
                {
                    col.Visible = visible;
                    break;
                }
            }
        }

        public static bool ExportToExcel(string fileName, GridView gridView, BandedGridView bandedGridView, bool size, ExportType exportType,
            bool printHeader)
        {
            try
            {
                var dialog = new SaveFileDialog()
                {
                    Title = @"Xuất ra file excel",
                    FileName = fileName,
                    Filter = @"Microsoft Excel|*.xlsx"
                };


                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var options = new XlsxExportOptions();
                    if (gridView != null)
                    {
                        gridView.ColumnPanelRowHeight = 40;
                        gridView.OptionsPrint.AutoWidth = size;
                        gridView.OptionsPrint.ShowPrintExportProgress = true;
                        gridView.OptionsPrint.PrintHeader = printHeader;
                        gridView.OptionsPrint.AllowCancelPrintExport = false;
                        gridView.AppearancePrint.HeaderPanel.Font = new Font("Tahoma", 8, FontStyle.Bold);
                        gridView.AppearancePrint.FooterPanel.Font = new Font("Tahoma", 8, FontStyle.Bold);
                        gridView.ExportToXlsx(dialog.FileName, options);
                    }
                    if (bandedGridView != null)
                    {
                        bandedGridView.ColumnPanelRowHeight = 40;
                        bandedGridView.OptionsPrint.AutoWidth = size;
                        bandedGridView.OptionsPrint.ShowPrintExportProgress = true;
                        bandedGridView.OptionsPrint.PrintHeader = printHeader;
                        bandedGridView.OptionsPrint.AllowCancelPrintExport = false;
                        bandedGridView.AppearancePrint.HeaderPanel.Font = new Font("Tahoma", 8, FontStyle.Bold);
                        bandedGridView.AppearancePrint.FooterPanel.Font = new Font("Tahoma", 8, FontStyle.Bold);
                        bandedGridView.ExportToXlsx(dialog.FileName, options);
                    }
                    options.TextExportMode = TextExportMode.Value;
                    options.ExportMode = XlsxExportMode.SingleFile;
                    options.SheetName = @"Sheet1";
                    
                    ExportSettings.DefaultExportType = exportType;
                    
                    XtraMessageBox.Show("Kết xuất thành công.", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, DefaultBoolean.True);
                    if (File.Exists(dialog.FileName))
                    {
                        if (
                            XtraMessageBox.Show("Bạn muốn mở tài liệu này không?", "Thông Báo",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question) == DialogResult.OK)
                            Process.Start(dialog.FileName);
                    }
                }
            }
            catch (Exception exception)
            {
                EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");
            }
            return false;
        }

        public static DataTable GetExcelTable(string fileName, string sheetName, string sql)
        {
            sheetName = sheetName.Replace(".", "#");
            if (sql == string.Empty)
                sql = string.Format("select * from [{0}$]", sheetName);

            var strConn = string.Empty;
            if (fileName.Contains(".xlsx"))
            {
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                          + fileName + ";Extended Properties=\"Excel 12.0;HDR=YES\";";
            }
            else if (fileName.Contains(".xls"))
            {
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                          "Data Source=" + fileName + ";Extended Properties=Excel 8.0;";
            }
            var dt = new DataTable();
            try
            {
                var oleCmd = new OleDbDataAdapter(sql, strConn);
                oleCmd.Fill(dt);
            }
            catch (Exception exception)
            {
                EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");
                return null;
            }
            return dt;
        }

        public static string Encrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            var md5 = new MD5CryptoServiceProvider();
            byte[] valueArray = Encoding.ASCII.GetBytes(value);
            valueArray = md5.ComputeHash(valueArray);
            var sb = new StringBuilder();
            for (int i = 0; i < valueArray.Length; i++)
                sb.Append(i.ToString("x2").ToLower());
            return sb.ToString();
        }

        public static string ToMd5(string str)
        {
            string result = "";
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            for (int i = 0; i < buffer.Length; i++)
            {
                result += buffer[i].ToString("x2");
            }
            return result;
        }

        public static Int32 GetAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (a - b) / 10000;
        }
    }
}