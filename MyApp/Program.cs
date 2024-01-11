using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraSplashScreen;
using XML130.EasyUtils;
using XML130.Libraries;

namespace XML130
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var culture = (CultureInfo)(new CultureInfo("vi")).Clone();
            culture.NumberFormat.NumberDecimalSeparator = ".";
            culture.NumberFormat.NumberGroupSeparator = ",";
            culture.NumberFormat.CurrencyDecimalSeparator = ".";
            culture.NumberFormat.CurrencyGroupSeparator = ",";
            culture.TextInfo.ListSeparator = ",";
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            // Run only
            if (!SingleInstance.Start() && args.Length == 0)
            {
                SingleInstance.ShowFirstInstance();
                return;
            }

            Application.ThreadException += Application_ThreadException;
            EasyLoadWait.ShowSplashForm("Đang nạp giao diện ...");

            UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();

            //EasyLoadWait.ShowSplashForm();
            HeThong.AppConfigConnectionStringName = "Properties.Settings.ConnString";
            if (HeThong.KetNoi() == false)
            {
                SingleInstance.Stop();
                return;
            }
            // must have after connect
            Properties.Settings.Default["ConnString"] = SqlConnector.ChuoiKetNoi;

            EasyLoadWait.ShowSplashForm("Đang khởi tạo hệ thống ...");
            EasyLoadWait.ShowSplashForm("Nạp định dạng ...");
            //HeThong.NapDinhDang();
            EasyLoadWait.ShowSplashForm("Quá trình hoàn tất.");
            EasyLoadWait.CloseWaitForm();

            Application.Run(new FrmMain());
            SingleInstance.Stop();
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs ex)
        {
            string err = ex.Exception.Message;
            if (err.Contains("error has occurred when receiving results from the server")
                || ex.Exception.Message.Contains("Could not open a connection"))
                EasyDialog.ShowErrorDialog("Không kết nối được cơ sở dữ liệu");

            else
                EasyDialog.ShowErrorDialog_NoTranslate("Lỗi chưa xử lý.\n" + err);


            string msg = string.Format("{0:dd/MM/yyyy HH:mm:ss}\t{1}", DateTime.Now, err);
            File.AppendAllText(Application.StartupPath + "\\log.txt", msg);
        }
    }
}
