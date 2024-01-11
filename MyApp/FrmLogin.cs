using System;
using System.Data;
using System.Windows.Forms;
using Dapper;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using XML130.EasyData;
using XML130.EasyUtils;
using XML130.Libraries;

namespace XML130
{
    public partial class FrmLogin : XtraForm
    {
        private const string MsgNotValidate = "Không hợp lệ";

        public FrmLogin()
        {
            InitializeComponent();
            AcceptButton = btnLogin;
        }

        #region "Registry"

        private void SaveRegistry()
        {
            if (chkRemember.Checked)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "Chk", "1");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "ID", txtUserName.Text);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "PSS", txtPassword.Text);
            }
            else if (chkRemember.Checked == false)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "Chk", "0");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "ID", "");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "PSS", "");
            }
        }

        private void LoadRegistry()
        {
            txtUserName.Text = (string) Registry.GetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "ID", null);
            txtPassword.Text =
                (string) Registry.GetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "PSS", null);
            if ((string) Registry.GetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "Chk", null) == "1")
            {
                chkRemember.Checked = true;
            }
            if ((string) Registry.GetValue(@"HKEY_CURRENT_USER\Software\SaveUserAndPassword", "Chk", null) == "0")
            {
                chkRemember.Checked = false;
            }
        }

        #endregion

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            Text = EasyMessageGlobal.LoginTitle;
            LoadRegistry();
            txtUserName.Focus();
        }

        private bool CheckLogin(string user, string pass)
        {
            if (user == null) throw new ArgumentNullException("user");
            if (pass == null) throw new ArgumentNullException("pass");

            DataTable dataTable = SQLHelper.ExecuteDataTable(string.Format("SELECT * FROM tblQuanTri WHERE Tk = '{0}'", user));
            string passEncode = EasyCommon.ToMd5(txtPassword.Text);
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["Mk"].ToString() == passEncode)
                {
                    EasyUser.Id = dataTable.Rows[0]["Id"].ToString();
                    EasyUser.UserName = dataTable.Rows[0]["Tk"].ToString();
                    EasyUser.Password = dataTable.Rows[0]["Mk"].ToString();
                    EasyUser.FullName = dataTable.Rows[0]["HoTen"].ToString();
                    //if (dataTable.Rows[0]["Ky"] != DBNull.Value)
                    //{
                    //    EasyUser.Ky = (byte[])dataTable.Rows[0]["Ky"];
                    //}
                    
                    SaveRegistry();
                    return true;
                }
                txtPassword.ErrorText = MsgNotValidate;
                return false;
            }
            
            return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckLogin(txtUserName.Text, txtPassword.Text)) DialogResult = DialogResult.OK;
        }
    }
}