using System;
using Dapper;
using XML130.EasyData;
using XML130.EasyEnum;
using XML130.EasyUtils;
using XML130.InterfaceInheritance;
using XML130.Libraries;

namespace XML130
{
    public partial class FrmChangePassword : FrmBase
    {
        public FrmChangePassword()
        {
            InitializeComponent();
            barSearch.Visible = false;
        }

        protected override void OnInit()
        {
            txtTk.Text = EasyUser.UserName;
        }

        private bool CheckValidate()
        {
            if (txtOldPassword.Text.Equals(""))
            {
                txtOldPassword.ErrorText = "Nhập mật khẩu hiện tại";
                return false;
            }
            if (EasyCommon.ToMd5(txtOldPassword.Text) != EasyUser.Password)
            {
                txtOldPassword.ErrorText = "Sai mật khẩu";
                return false;
            }

            if (txtNewPassword.Text.Equals(""))
            {
                txtNewPassword.ErrorText = "Nhập mật khẩu mới";
                return false;
            }

            if (txtConfirm.Text.Equals(""))
            {
                txtConfirm.ErrorText = "Xác nhận lại mật khẩu mới";
                return false;
            }

            if (!txtNewPassword.Text.Equals(txtConfirm.Text))
            {
                txtNewPassword.ErrorText = "Mật khẩu xác nhận không giống nhau";
                txtConfirm.ErrorText = "Mật khẩu xác nhận không giống nhau";
                return false;
            }
            return true;
        }

        protected override void OnSave()
        {
            if (CheckValidate())
            {
                try
                {
                    var query = "UPDATE tblQuanTri SET Mk = '" + EasyCommon.ToMd5(txtNewPassword.Text) + "' WHERE Tk='" + EasyUser.UserName + "'";
                    SQLHelper.ExecuteNonQuery(query);
                    ShowAlertString("Thông báo", "Xử lý thành công!", IconAlert.Done);
                }
                catch (Exception exception)
                {
                    EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");

                }
            }
        }
    }
}