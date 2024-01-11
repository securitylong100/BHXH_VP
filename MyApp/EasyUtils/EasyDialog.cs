using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace XML130.EasyUtils
{
    public class EasyDialog
    {
        public static DialogResult ShowYesNoDialog(string caption)
        {
            return XtraMessageBox.Show(caption, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ShowSuccessfulDialog(string action)
        {
            return XtraMessageBox.Show(action, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowUnsuccessfulDialog(string action)
        {
            return XtraMessageBox.Show(action, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowErrorDialog(string caption)
        {
            return XtraMessageBox.Show(caption, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowWarningDialog(string caption)
        {
            return XtraMessageBox.Show(caption, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowInfoDialog(string caption)
        {
            return XtraMessageBox.Show(caption, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowYesNoCancelDialog(string caption)
        {
            return XtraMessageBox.Show(caption, "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public static DialogResult ShowErrorDialog_NoTranslate(string text)
        {
            if (text.Contains("Cannot delete or update a parent row: a foreign key constraint fails") || text.Contains("includes related records") || text.Contains("violation of FOREIGN KEY constraint") || text.Contains("DELETE statement conflicted with the REFERENCE constraint"))
                text = "Không thể xóa dữ liệu quan hệ";
            else if (text.Contains("Unable to open database"))
                text = "Không thể kết nối CSDL";
            else if (text.Contains("cannot open or write to the file"))
                text = "Tập tin đang được sử dụng bởi chương trình khác";
            else if (text.Contains("These columns don't currently have unique values"))
                text = "Dữ liệu trùng";
            return XtraMessageBox.Show(text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static void OpenDialog<T>() where T : Form
        {
            EasyLoadWait.ShowWaitForm();
            T instance = Activator.CreateInstance<T>();
            instance.ShowInTaskbar = false;
            instance.MinimizeBox = false;
            EasyLoadWait.CloseWaitForm();
            int num = (int)instance.ShowDialog();
            instance.Dispose();
        }
    }
}