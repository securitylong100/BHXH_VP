using System.Runtime.InteropServices;

namespace XML130.EasyUtils
{
    internal class EasyInternetConnection
    {
        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int description, int reservedValue);

        public static bool IsConnectedToInternet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }
    }
}