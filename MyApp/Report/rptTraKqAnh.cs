using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using XML130.EasyData;
using XML130.EasyUtils;
using XML130.Libraries;

namespace XML130.Report
{
    public partial class rptTraKqAnh : DevExpress.XtraReports.UI.XtraReport
    {
        private DataRow r1;
        private DataRow r2;
        public rptTraKqAnh(DataRow row1, DataRow row2)
        {
            InitializeComponent();
            r1 = row1;
            r2 = row2;
        }

        private void rptTraKqAnh_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                if (r1 == null) return;
                {
                    lblHoTenBN.Text = r1["HoTen"].ToString();
                    lblDiaChi.Text = r1["DiaChi"].ToString();
                    lblTuoi.Text = Convert.ToDateTime(r1["NamSinh"].ToString()).ToString("yyyy");// sửa năm sinh dd/MM/yyyy

                    lblGioiTinh.Text = r1["GioiTinh"].ToString();
                    lblCCCD.Text = r1["CCCD"].ToString();
                    lblDienThoai.Text = r1["DienThoai"].ToString();
                }

                if (r2 == null) return;
                {
                    var qr = "Select * from tblMay t1, tblKQ t2 where t1.MaMay=t2.MayXn and t2.Id='" + r2["Id"] + "'";
                    DataTable dt = SQLHelper.ExecuteDataTable(qr);
                    lblBsChiDinh.Text = r2["TenBs"].ToString();
                    lblKyhieu.Text = r2["KHM"].ToString();
                    lblKyThuat.Text = r2["KyThuat"].ToString();
                    lblHeThongMay.Text = dt.Rows[0]["TenMay"].ToString();
                    lblBoKitSuDung.Text = r2["Kit"].ToString();
                    //lblKetLuan.Text = r2["KL"].ToString();
                    lblKetLuan.RtfText = new SerializableString(r2["KL"].ToString()); // Sửa theo định dạng mũ

                    lblTieuDe.Text = (@"kết quả " + r2["TenDv"]).ToUpper();
                }

                if (r2["Anh"] == DBNull.Value)
                {
                    picBieuDo.Visible = false;

                }
                else
                {
                    picBieuDo.Visible = true;
                    picBieuDo.Image = ByteToImage((byte[])r2["Anh"]);
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
                    xrPictureBox.Image = ByteToImage((byte[]) dataTable.Rows[0]["Ky"]);
                    xrLabel3.Visible = false;
                }

                //if (EasyUser.Ky == null)
                //{
                //    xrLabel3.Visible = true;
                //    xrLabel3.Text = EasyUser.FullName;
                //    xrPictureBox.Visible = false;

                //}
                //else
                //{
                //    xrPictureBox.Visible = true;
                //    xrPictureBox.Image = ByteToImage(EasyUser.Ky);
                //    xrLabel3.Visible = false;
                //}
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
    }
}
