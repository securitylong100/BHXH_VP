using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace XML130.Libraries
{
    public static class SingleInstance
    {
        public static readonly int WM_SHOWFIRSTINSTANCE = WinApi.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", (object)SingleInstance.AssemblyGuid);
        private static Mutex mutex;

        public static string AssemblyGuid
        {
            get
            {
                object[] customAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(GuidAttribute), false);
                return customAttributes.Length == 0 ? string.Empty : ((GuidAttribute)customAttributes[0]).Value;
            }
        }

        public static bool Start()
        {
            bool createdNew = false;
            SingleInstance.mutex = new Mutex(true, string.Format("Local\\{0}", (object)SingleInstance.AssemblyGuid), out createdNew);
            return createdNew;
        }

        public static void ShowFirstInstance() => WinApi.PostMessage((IntPtr)(int)ushort.MaxValue, SingleInstance.WM_SHOWFIRSTINSTANCE, IntPtr.Zero, IntPtr.Zero);

        public static void Stop()
        {
            try
            {
                SingleInstance.mutex.ReleaseMutex();
            }
            catch
            {
            }
        }
    }
}
