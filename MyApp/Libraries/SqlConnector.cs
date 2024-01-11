using DevExpress.XtraEditors;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using XML130.EasyUtils;

namespace XML130.Libraries
{
    public class SqlConnector
    {
        public static string ChuoiKetNoi { get; set; }
        public static string DBName { get; set; }
        public static bool Ketnoi()
        {
            string connectionString1 = AppConfig.GetConnectionString(HeThong.AppConfigConnectionStringName);
            SqlConnection sqlConnection = (SqlConnection)null;
            try
            {
                string connectionString2 = connectionString1;
                if (HeThong.MaHoaChuoiKetNoi)
                    connectionString2 = EasyEncoding.Descrypt(connectionString1, "ng0ctu@n");
                sqlConnection = new SqlConnection(connectionString2);
                sqlConnection.Open();
                ChuoiKetNoi = connectionString2;
                SQLHelper.Connectionstring = connectionString2;
                Settings.Default.ConnectionString = connectionString2;
                DBName = new SqlConnectionStringBuilder(connectionString2).InitialCatalog;
            }
            catch (Exception ex)
            {
                FrmThietLapKetNoi control = new FrmThietLapKetNoi();
                EasyLoadWait.CloseSplashForm();
                if (control.ShowDialog() == DialogResult.OK)
                    return true;
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                sqlConnection?.Close();
            }
            return true;
        }

        public static bool Ketnoi(
          string maychu,
          string tendangnhap,
          string matkhau,
          string csdl,
          int cheDo)
        {
            string connectionString = string.Empty;
            switch (cheDo)
            {
                case 0:
                    connectionString = string.Format("Server={0};Database={1};Trusted_Connection=True;", (object)maychu, (object)csdl);
                    break;
                case 1:
                    connectionString = string.Format("Server={0};Database={1};User Id={2};Password={3};", (object)maychu, (object)csdl, (object)tendangnhap, (object)matkhau);
                    break;
            }
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlConnector.ChuoiKetNoi = connectionString;
                SQLHelper.Connectionstring = connectionString;
            }
            catch (Exception ex)
            {
                int num = (int)EasyDialog.ShowErrorDialog(ex.Message);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public static void SaoLuu()
        {
            string dbName = SqlConnector.DBName;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Backup file (*.bak)|*.bak|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(saveFileDialog.FileName))
                return;
            EasyLoadWait.ShowWaitForm();
            try
            {
                SQLHelper.ExecuteNonQuery("BACKUP DATABASE [" + dbName + "] TO DISK = '" + saveFileDialog.FileName + "' WITH INIT , NOUNLOAD , name = 'BKdb' , NOSKIP , STATS = 10 , Description = 'BKdb' , NOFORMAT ");
                EasyLoadWait.CloseWaitForm();
                int num = (int)EasyDialog.ShowSuccessfulDialog("Sao lưu thành công!");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                EasyLoadWait.CloseWaitForm();
                int num = (int)EasyDialog.ShowWarningDialog("Sao lưu không thành công");
            }
        }

        public static void PhucHoi()
        {
            string dbName = SqlConnector.DBName;
            if (XtraMessageBox.Show("Bạn có chắc muốn phục hồi lại dữ liệu cũ không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Backup file (*.bak)|*.bak|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            if (string.IsNullOrEmpty(openFileDialog.FileName))
                return;
            try
            {
                SQLHelper.ExecuteNonQuery("USE MASTER ALTER DATABASE [" + dbName + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE " + "RESTORE DATABASE [" + dbName + "] FROM  DISK = N'" + openFileDialog.FileName + "' WITH  FILE = 1,  NOUNLOAD, REPLACE, STATS = 10" + " ALTER DATABASE [" + dbName + "] SET MULTI_USER");
                int num = (int)EasyDialog.ShowSuccessfulDialog("Phục hồi thành công. Chương trình sẽ khởi động lại.");
                Application.ExitThread();
                Process.Start(Application.ExecutablePath);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                int num = (int)EasyDialog.ShowWarningDialog("Không thể phục hồi");
            }
        }
    }
}
