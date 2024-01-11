using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using XML130.EasyData;
using XML130.EasyUtils;
using XML130.Libraries;

namespace XML130.Report
{
    public partial class rptTraKetQua : DevExpress.XtraReports.UI.XtraReport
    {
        private DataRow r1;
        private DataRow r2;
        public rptTraKetQua(DataRow row1, DataRow row2)
        {
            InitializeComponent();
            r1 = row1;
            r2 = row2;
        }

        private int stt1, stt;

        //private void xrTableCell3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        //{
        //    stt++;
        //    xrTableCell3.Text = stt.ToString();
        //}

        private void rptTraKetQua_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                if (r1 == null) return;
                {
                    lblHoTenBN.Text = r1["HoTen"].ToString();
                    lblDiaChi.Text = r1["DiaChi"].ToString();
                    lblTuoi.Text = Convert.ToDateTime(r1["NamSinh"].ToString()).ToString("yyyy");// sửa lại theo năm sinh dd/MM/yyyy
                    bcMBn.Text = r1["MaBn"].ToString();
                    lblGioiTinh.Text = r1["GioiTinh"].ToString();
                    lblCCCD.Text = r1["CCCD"].ToString();
                    lblDienThoai.Text = r1["DienThoai"].ToString();
                    lblChanDoan.Text = r1["ChanDoan"].ToString();// thêm chẩn đoán
                }

                if (r2 == null) return;
                {
                    lblBacSiCD.Text = r2["TenBs"].ToString();
                    lblNVLayMau.Text = r2["TenNguoiLayMau"].ToString();
                    lblNVNhanMau.Text = r2["TenNguoiNhanMau"].ToString();
                    lblTGNhanMau.Text = Convert.ToDateTime(r2["NgayLayMau"].ToString()).ToString("dd/MM/yyyy");
                    lblTGTraKetQua.Text = Convert.ToDateTime(r2["NgayTraKq"].ToString()).ToString("dd/MM/yyyy");
                }

                DataTable dataTable = SQLHelper.ExecuteDataTable(string.Format("SELECT * FROM tblQuanTri WHERE Tk = '{0}'", EasyUser.UserName));

                if (dataTable.Rows[0]["Ky"] == DBNull.Value)
                {
                    xrLabel3.Visible = true;
                    xrLabel3.Text = EasyUser.FullName;
                    xrPictureBox.Visible = false;

                }
                else
                {
                    xrPictureBox.Visible = true;
                    xrPictureBox.Image = ByteToImage((byte[])dataTable.Rows[0]["Ky"]);
                    xrLabel3.Visible = false;
                }
            }
            catch (Exception ex)
            {
                EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + ex.Message + ")");
            }

        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        //private void label11_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        //{
        //    stt1++;
        //    label11.Text = DinhDangMa.Lm(stt1) + @". ";
        //    stt = 0;
        //}
    }
}
