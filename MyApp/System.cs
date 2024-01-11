using XML130.Libraries;
using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using XML130.EasyUtils;

namespace XML130
{
    public class HeThong
    {
        public static string AppConfigConnectionStringName;

        public static bool KetNoi()
        {
            bool flag;
            for (flag = SqlConnector.Ketnoi(); !flag; flag = SqlConnector.Ketnoi())
            {
                EasyLoadWait.CloseSplashForm();
                if (EasyDialog.ShowYesNoDialog("Không thể kết nối cơ sở dữ liệu!\nBạn có muốn thiết lập lại kết nối?") != DialogResult.Yes)
                {
                    return false;
                }
                else
                {
                    EasyLoadWait.ShowSplashForm("Vui lòng đợi...");
                } 
            }
            //if (flag && Param.GetValue<bool>("Lần chạy đầu tiên", "Hệ thống", (object)true, false))
            //{
            //    EasyLoadWait.CloseSplashForm();
            //    if (new FrmThietLapBanDau().ShowDialog() == DialogResult.Cancel)
            //    {
            //        SingleInstance.Stop();
            //        return false;
            //    }
            //}
            return flag;
        }

        public static bool MaHoaChuoiKetNoi { get; set; }

        public static string MaHoaMD5(string data) => Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(data)));

        public static bool Exits(string tenBang, string cotMa, string ma) => SQLHelper.ExecuteScalar(string.Format("select * from {0} where {1} = N'{2}'", (object)tenBang, (object)cotMa, (object)ma)) != null;

        public static void NapDinhDang()
        {
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            cultureInfo.DateTimeFormat.ShortDatePattern = Param.GetValue<string>("Định dạng ngày", "Đinh dạng dữ liệu", (object)cultureInfo.DateTimeFormat.ShortDatePattern);
            cultureInfo.NumberFormat.CurrencyDecimalDigits = Param.GetValue<int>("Số lẻ thập phân", "Đinh dạng dữ liệu", (object)cultureInfo.NumberFormat.CurrencyDecimalDigits);
            cultureInfo.NumberFormat.CurrencyDecimalSeparator = Param.GetValue<string>("Dấu cách thập phân", "Đinh dạng dữ liệu", (object)cultureInfo.NumberFormat.CurrencyDecimalSeparator);
            cultureInfo.NumberFormat.CurrencyGroupSeparator = Param.GetValue<string>("Dấu cách hàng nghìn", "Đinh dạng dữ liệu", (object)cultureInfo.NumberFormat.CurrencyGroupSeparator);
            cultureInfo.NumberFormat.CurrencySymbol = Param.GetValue<string>("Ký hiệu tiền", "Đinh dạng dữ liệu", (object)string.Empty);
            cultureInfo.NumberFormat.CurrencyNegativePattern = Param.GetValue<int>("Định dạng tiền âm", "Đinh dạng dữ liệu", (object)15);


            Thread.CurrentThread.CurrentCulture = cultureInfo;
        }
    }
}
