using System;
using System.Data;
using System.Drawing;
using System.IO;
using XML130.EasyUtils;

namespace XML130.Report
{
    public partial class rptChiDinh : DevExpress.XtraReports.UI.XtraReport
    {


        private DataRow r1;
        private DataRow r2;
        public rptChiDinh(DataRow row1, DataRow row2)
        {
            InitializeComponent();
            r1 = row1;
            r2 = row2;
        }

        private void rptPhieuChiDinh_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                if (r1 == null) return;
                {
                    lblHoTenBN.Text = r1["HoTen"].ToString();
                    lblDiaChi.Text = r1["DiaChi"].ToString();
                    //bcBarcode.Text = r1["Barcode"].ToString();
                    lblTuoi.Text = Convert.ToDateTime(r1["NamSinh"].ToString()).ToString("dd/MM/yyyy");
                    bcMBn.Text = r1["MaBn"].ToString();
                    lblGioiTinh.Text = r1["GioiTinh"].ToString();
                    lblCCCD.Text = r1["CCCD"].ToString();
                    lblDienThoai.Text = r1["DienThoai"].ToString();

                    //lblSoPhieu.Text = r2["SoPhieu"].ToString();

                    //var qr = "Select * from tblDmSoXetNghiem where MaSoXn='" + r2["MaSoXn"] + "'";
                    //DataTable dt = SQLHelper.ExecuteDataTable(qr);

                    //lblTieuDe.Text = (@"PHIẾU CHỈ ĐỊNH XÉT NGHIỆM " + dt.Rows[0]["TenSoXn"]).ToUpper();
                }
                if (r2 == null) return;
                {
                    if (r2["ImgCk"] == "" || r2["ImgCk"].Equals("") || r2["ImgCk"] == null || r2["ImgCk"] == DBNull.Value)
                    {
                        label11.Visible = true;
                        xrPictureBox1.Visible = false;
                    }
                    else
                    {
                        xrPictureBox1.Visible = true;
                        xrPictureBox1.Image = ByteToImage((byte[])r2["ImgCk"]);
                        label11.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + ex.Message + ")");
            }
        }

        private int stt;
        private void lblSTT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            stt++;
            lblSTT.Text = stt.ToString();
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
    }
}
