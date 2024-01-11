using DevExpress.XtraEditors;
using XML130.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML130.EasyUtils;

namespace XML130
{
    public partial class FrmThietLapKetNoi : DevExpress.XtraEditors.XtraForm
    {
        public FrmThietLapKetNoi()
        {
            InitializeComponent();

            string connectionString1 = AppConfig.GetConnectionString(HeThong.AppConfigConnectionStringName);
            string connectionString2 = connectionString1;
            if (HeThong.MaHoaChuoiKetNoi)
                connectionString2 = EasyEncoding.Descrypt(connectionString1, "ng0ctu@n");
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(connectionString2);
            txtMayChu.Text = connectionStringBuilder.DataSource;
            txtTenDangNhap.Text = connectionStringBuilder.UserID;
            txtMatKhau.Text = connectionStringBuilder.Password;
            txtCSDL.Text = connectionStringBuilder.InitialCatalog;
            cbbXacThuc.SelectedIndex = 1;
        }

        private void FrmThietLapKetNoi_Load(object sender, EventArgs e)
        {
            Text = EasyMessageGlobal.ThietLapKetNoiTitle;
        }

        private void btnDong_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void cbbXacThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbXacThuc.SelectedIndex == 0)
            {
                txtTenDangNhap.Enabled = false;
                txtMatKhau.Enabled = false;
            }
            else
            {
                if (cbbXacThuc.SelectedIndex != 1)
                    return;
                txtTenDangNhap.Enabled = true;
                txtMatKhau.Enabled = true;
            }
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            if (!SqlConnector.Ketnoi(txtMayChu.Text, txtTenDangNhap.Text, txtMatKhau.Text, txtCSDL.Text, cbbXacThuc.SelectedIndex))
                return;
            int num = (int)EasyDialog.ShowSuccessfulDialog("Kết nối thành công");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (SqlConnector.Ketnoi(txtMayChu.Text, txtTenDangNhap.Text, txtMatKhau.Text, txtCSDL.Text, cbbXacThuc.SelectedIndex))
            {
                int num = (int)EasyDialog.ShowSuccessfulDialog("Kết nối thành công, chương trình sẽ khởi động lại");
                string conn = SqlConnector.ChuoiKetNoi;
                if (HeThong.MaHoaChuoiKetNoi)
                    conn = EasyEncoding.Encrypt(SqlConnector.ChuoiKetNoi, "ng0ctu@n");
                AppConfig.SetConnectionString(conn, HeThong.AppConfigConnectionStringName);
                string executablePath = Application.ExecutablePath;
                SingleInstance.Stop();
                Application.ExitThread();
                Process.Start(executablePath, "reset");
                DialogResult = DialogResult.OK;
            }
            else
            {
                int num1 = (int)XtraMessageBox.Show("Không thể lưu kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}