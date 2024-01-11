using System;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace XML130.EasyUtils
{
    internal class EasyLoadWait
    {
        #region WaitForm

        public static void ShowWaitForm()
        {
            if (SplashScreenManager.Default != null) return;
            SplashScreenManager.ShowForm(typeof (FrmWaitForm), true, true);
        }

        public static void ShowWaitForm<T>()
        {
            if (SplashScreenManager.Default != null) return;
            SplashScreenManager.ShowForm(typeof (T));
        }

        public static void ShowWaitForm(string description)
        {
            if (SplashScreenManager.Default != null)
                if (SplashScreenManager.Default.IsSplashFormVisible)
                {
                    SplashScreenManager.Default.SetWaitFormDescription(description);
                    return;
                }
            SplashScreenManager.ShowForm(typeof (FrmWaitForm), true, true);
            if (SplashScreenManager.Default != null) SplashScreenManager.Default.SetWaitFormDescription(description);
        }

        public static void ShowWaitForm(string description, Form parentForm)
        {
            if (SplashScreenManager.Default != null)
                if (SplashScreenManager.Default.IsSplashFormVisible)
                {
                    SplashScreenManager.Default.SetWaitFormDescription(description);
                    return;
                }
            SplashScreenManager.ShowForm(parentForm, typeof (FrmWaitForm));
            if (SplashScreenManager.Default != null) SplashScreenManager.Default.SetWaitFormDescription(description);
        }

        public static void SetWaitFormDescription(string description)
        {
            if (SplashScreenManager.Default != null)
                if (SplashScreenManager.Default.IsSplashFormVisible)
                    SplashScreenManager.Default.SetWaitFormDescription(description);
        }

        public static void CloseWaitForm()
        {
            if (SplashScreenManager.Default != null)
                if (SplashScreenManager.Default.IsSplashFormVisible)
                {
                    SplashScreenManager.CloseForm();
                }
        }

        public static void ShowSplashForm()
        {
            if (SplashScreenManager.Default != null)
                return;
            SplashScreenManager.ShowForm(typeof(FrmSplash));
        }

        public static void ShowSplashForm(string description)
        {
            if (SplashScreenManager.Default != null && SplashScreenManager.Default.IsSplashFormVisible)
            {
                SplashScreenManager.Default.SendCommand((Enum)null, (object)description);
            }
            else
                SplashScreenManager.ShowForm(typeof(FrmSplash));
        }

        public static void CloseSplashForm()
        {
            if (SplashScreenManager.Default == null)
                return;
            SplashScreenManager.CloseForm();
        }

        #endregion
    }
}