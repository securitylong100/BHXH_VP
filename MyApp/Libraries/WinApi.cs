using System;
using System.Runtime.InteropServices;

namespace XML130.Libraries
{
    public static class WinApi
    {
        public const int HWND_BROADCAST = 65535;
        public const int SW_SHOWNORMAL = 1;

        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

        public static int RegisterWindowMessage(string format, params object[] args) => WinApi.RegisterWindowMessage(string.Format(format, args));

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void ShowToFront(IntPtr window)
        {
            WinApi.ShowWindow(window, 1);
            WinApi.SetForegroundWindow(window);
        }
    }
}
