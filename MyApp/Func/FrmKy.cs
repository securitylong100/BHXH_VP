using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML130.EasyData;
using XML130.EasyEnum;
using XML130.EasyUtils;
using XML130.InterfaceInheritance;
using XML130.Libraries;

namespace XML130.Func
{
    public partial class FrmKy : FrmBase
    {
        public FrmKy()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            barSearch.Visible = false;
            BindingEntityToControl();
        }

        protected override void OnInit()
        {
            Text = @"Cập nhật chữ ký";
        }

        private void BindingEntityToControl()
        {
            DataTable dataTable = SQLHelper.ExecuteDataTable("SELECT * FROM tblQuanTri a WHERE a.Id=" + EasyData.EasyUser.Id + "" );
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["Ky"] != DBNull.Value)
                {
                    EasyUser.Ky = (byte[])dataTable.Rows[0]["Ky"];

                    pictureEdit.EditValue = (byte[])dataTable.Rows[0]["Ky"];
                }
                
            }
        }

        protected override void OnSave()
        {
            
                try
                {
                    
                    SQLHelper.ExecuteNonQuery("SP_UpdateKy"
                        , new SqlParameter() { ParameterName = "@Id", Value = EasyData.EasyUser.Id }
                        , new SqlParameter() { ParameterName = "@Ky", Value = pictureEdit.EditValue }
                    );
                    IsChange = true;
                    ShowAlertString("Thông báo", "Xử lý thành công!", IconAlert.Done);
                    // thoát form
                    this.Dispose();
            }
                catch (Exception ex)
                {
                    EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + ex.Message + ")");
                }
            
        }
    }
}