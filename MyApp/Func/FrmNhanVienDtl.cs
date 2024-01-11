using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using XML130.EasyData;
using XML130.EasyEnum;
using XML130.EasyUtils;
using XML130.InterfaceInheritance;
using XML130.Libraries;

namespace XML130.Func
{
    public partial class FrmNhanVienDtl : FrmBase
    {
        private const string MsgNotValidate = "Không hợp lệ";
        DataTable _dt;
        private ECommand _command;
        public FrmNhanVienDtl(DataTable dt, ECommand command)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            barSearch.Visible = false;
            _dt = dt;
            _command = command;
            BindingEntityToControl();
        }

        // hàm gọi lên lưới
        private void BindingEntityToControl()
        {
            if (_dt == null)
            {
                EasyCommon.SetWatermark(txtMa, "Có thể nhập hoặc không (hệ thống sẽ tự động sinh mã)");
                txtMa.Text = string.Empty;
                txtTen.Text = string.Empty;
                txtSdt.Text = string.Empty;
                pictureEdit.EditValue = null;
                chkBs.Checked = false;
                txtTenDonVi.Text = string.Empty;// tên đơn vị
                return;
            }
            if (_dt.Rows.Count > 0 && _dt != null)
            {
                txtMa.Properties.ReadOnly = true;
                txtMa.Text = _dt.Rows[0]["MaNv"].ToString();
                txtTen.Text = _dt.Rows[0]["TenNv"].ToString();
                txtSdt.Text = _dt.Rows[0]["DienThoai"].ToString();
                pictureEdit.EditValue = _dt.Rows[0]["ImgCk"];
                chkBs.Checked = _dt.Rows[0]["TrangThai"].ToString() == "1" ||
                                _dt.Rows[0]["TrangThai"].ToString() == "True";//True
                txtTenDonVi.Text = _dt.Rows[0]["TenDonVi"].ToString();// tên đơn vị
            }
        }

        private bool CheckValidate()
        {
            if (txtTen.Text.Equals(""))
            {
                txtTen.ErrorText = MsgNotValidate;
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
                    int check;
                    if (chkBs.Checked)
                    {
                        check = 1;
                    }
                    else
                    {
                        check = 0;
                    }

                    string ma;
                    if (txtMa.Text.Equals(""))
                    {
                        ma = DinhDangMa.LayMaTuDong("MaNv", "tblNhanVien", "NV/{0:d4}");
                    }
                    else
                    {
                        ma = txtMa.Text;
                    }

                    if ( this.pictureEdit.EditValue == null || this.pictureEdit.EditValue == DBNull.Value)
                    {
                        SQLHelper.ExecuteNonQuery("SP_UpdateNhanVienNo"
                             , new SqlParameter() { ParameterName = "@MaNV", Value = ma }
                             , new SqlParameter() { ParameterName = "@TenNV", Value = txtTen.Text }
                             , new SqlParameter() { ParameterName = "@DienThoai", Value = txtSdt.Text }
                             , new SqlParameter() { ParameterName = "@TrangThai", Value = check }
                             , new SqlParameter() { ParameterName = "@TenDonVi", Value = txtTenDonVi.Text }// bổ sung trường tên đơn vị
                             );
                    }    

                    else
                    {
                        SQLHelper.ExecuteNonQuery("SP_UpdateNhanVien"
                            , new SqlParameter() { ParameterName = "@MaNV", Value = ma }
                            , new SqlParameter() { ParameterName = "@TenNV", Value = txtTen.Text }
                            , new SqlParameter() { ParameterName = "@DienThoai", Value = txtSdt.Text }
                            , new SqlParameter() { ParameterName = "@TrangThai", Value = check }
                            , new SqlParameter() { ParameterName = "@Hinh", Value = pictureEdit.EditValue }// Nếu pic=null --> pm không cho add/update
                            , new SqlParameter() { ParameterName = "@TenDonVi", Value = txtTenDonVi.Text }// bổ sung trường tên đơn vị
                            );
                    }    

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
}