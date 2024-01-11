using DevExpress.XtraEditors;
using XML130.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML130.EasyData;
using XML130.EasyEnum;
using XML130.EasyHelper;
using XML130.EasyUtils;
using XML130.InterfaceInheritance;

namespace XML130.Func
{
    public partial class FrmNCCDtl : FrmBase
    {
        private const string MsgNotValidate = "Không hợp lệ";
        DataTable _dt;
        private ECommand _command;

        public FrmNCCDtl(DataTable dt, ECommand command)
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            //new EasyGridLookUpHelper(this, cbbSoXn, customGridLookUpEditSoXn,
            //    "-- Sổ xét nghiệm --",
            //    "MaSoXn", "TenSoXn", false, true);

            barSearch.Visible = false;
            _dt = dt;
            _command = command;
            BindingEntityToControl();
        }


        private void BindingEntityToControl()
        {
            if (_dt == null)
            {
                EasyCommon.SetWatermark(txtMaNCC, "Có thể nhập hoặc không (hệ thống sẽ tự động sinh mã)");
                txtMaNCC.Text = string.Empty;
                txtTenCoSo.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtSDT.Text = string.Empty;
                txtTenNguoiGiaoHang.Text = string.Empty;
                txtMaSoThue.Text = string.Empty;
                txtGhiChu.Text = string.Empty;
                
                return;
            }
            if (_dt.Rows.Count > 0 && _dt != null)
            {
                txtMaNCC.Properties.ReadOnly = true;
                txtMaNCC.Text = _dt.Rows[0]["MaNCC"].ToString();
                txtTenCoSo.Text = _dt.Rows[0]["TenCoSo"].ToString();
                txtDiaChi.Text = _dt.Rows[0]["DiaChi"].ToString();
                txtSDT.Text = _dt.Rows[0]["SDT"].ToString();
                txtTenNguoiGiaoHang.Text = _dt.Rows[0]["TenNguoiGiaoHang"].ToString();
                txtMaSoThue.Text = _dt.Rows[0]["MaSoThue"].ToString();
                txtGhiChu.Text = _dt.Rows[0]["GhiChu"].ToString();

                //cbbSoXn.EditValue = _dt.Rows[0]["MaSoXn"].ToString();
                //txtDonVi.Text = _dt.Rows[0]["DonVi"].ToString();
                //txtGiaTriThamChieuNam.EditValue = _dt.Rows[0]["GiaTriThamChieuNam"];
                //txtGTMinNam.Text = _dt.Rows[0]["GTMinNam"].ToString();
                //txtGTMaxNam.Text = _dt.Rows[0]["GTMaxNam"].ToString();
                //txtGiaTriThamChieuNu.EditValue = _dt.Rows[0]["GiaTriThamChieuNu"];
                //txtGTMinNu.Text = _dt.Rows[0]["GTMinNu"].ToString();
                //txtGTMaxNu.Text = _dt.Rows[0]["GTMaxNu"].ToString();
            }
        }

        protected override void OnInit()
        {
            DataTable dataTable = SQLHelper.ExecuteDataTable(string.Format("SELECT * FROM tblDmNCC"));
            //cbbSoXn.Properties.DataSource = dataTable;
        }

        // rằng buộc tính năng text
        private bool CheckValidate()
        {
            if (txtTenCoSo.Text.Equals(""))
            {
                txtTenCoSo.ErrorText = MsgNotValidate;
                return false;
            }
            //if (cbbSoXn.EditValue == null)
            //{
            //    cbbSoXn.ErrorText = MsgNotValidate;
            //    return false;
            //}
            if (txtDiaChi.EditValue == null)
            {
                txtDiaChi.ErrorText = MsgNotValidate;
                return false;
            }

            if (txtSDT.EditValue == null)
            {
                txtSDT.ErrorText = MsgNotValidate;
                return false;
            }


            return true;
        }

        // Tuấn 02/11/2023: khởi tạo tính năng SAVE
        protected override void OnSave()
        {
            if (CheckValidate())
            {
                try
                {
                    if (_command == ECommand.EAdd)
                    {
                        var ma = "";
                        if (txtMaNCC.Text.Equals(""))
                        {
                            ma = DinhDangMa.LayMaTuDong("MaNCC", "tblDmNCC", "NCC/{0:d4}");
                        }
                        else
                        {
                            ma = txtMaNCC.Text;
                        }
                        var query =
                            "INSERT INTO tblDmNCC(MaNCC, TenCoSo, DiaChi, SDT, TenNguoiGiaoHang, MaSoThue, GhiChu) "; // dấu ; dùng để xuống dòng --> query +="
                        query += "VALUES ('" + ma + "', N'" + txtTenCoSo.Text + "', N'" + txtDiaChi.EditValue + "', N'" + txtSDT.Text + "', N'" + txtTenNguoiGiaoHang.Text + "', N'" + txtMaSoThue.Text + "',  N'" + txtGhiChu.Text + "' )";
                        SQLHelper.ExecuteNonQuery(query);
                        _command = ECommand.EUpdate;
                    }
                    else
                    {
                        // tuấn 02/11/2023: 
                        var query = "UPDATE tblDmNCC SET TenCoSo = N'" + txtTenCoSo.Text + "', DiaChi=N'" + txtDiaChi.EditValue + "', SDT=N'" + txtSDT.Text + "', TenNguoiGiaoHang=N'" + txtTenNguoiGiaoHang.EditValue + "', MaSoThue='" + txtMaSoThue.Text + "',  GhiChu='" + txtGhiChu.Text + "' ";
                        query += " WHERE MaNCC='" + txtMaNCC.Text + "'";
                        SQLHelper.ExecuteNonQuery(query);
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
