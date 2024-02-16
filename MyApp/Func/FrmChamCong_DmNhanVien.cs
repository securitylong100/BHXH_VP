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
using XML130.EasyEnum;
using XML130.EasyHelper;
using XML130.EasyUtils;
using XML130.InterfaceInheritance;
using XML130.Libraries;

namespace XML130.Func
{
    public partial class FrmChamCong_DmNhanVien : FrmBase
    {
        public FrmChamCong_DmNhanVien()
        {
            InitializeComponent();

            EasyGridStyleHelper = new EasyGridStyleHelper(this, customGridControl, customGridView, false, true, false, false,
                false, false, true, true);
            barSearch.Visible = false;
        }

        protected override void OnInit()
        {
            try
            {
                DataTable dataTable = SQLHelper.ExecuteDataTable("SELECT * FROM tblNhanVien ");
                customGridControl.DataSource = dataTable;
                if (dataTable.Rows.Count > 0)
                {
                    var colGroup = customGridView.Columns["TrangThaiText"];
                    colGroup.GroupIndex = 0;
                    customGridView.ExpandAllGroups();
                }

                EasyCommon.BestFitColumnsGridView(customGridView);
            }
            catch (Exception exception)
            {
                EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");
            }
        }

        protected override void OnReload()
        {
            OnInit();
        }

        protected override void OnEdit()
        {
            if (customGridView.FocusedRowHandle < 0) return;
            TopRowIndex = customGridView.TopRowIndex;
            RowIndex = customGridView.FocusedRowHandle;
            var id = customGridView.GetRowCellValue(customGridView.FocusedRowHandle, colMaNv).ToString();
            var name = customGridView.GetRowCellValue(customGridView.FocusedRowHandle, colTenNv).ToString();

            EasyLoadWait.ShowWaitForm();
            DataTable dataTable = SQLHelper.ExecuteDataTable(string.Format("SELECT * FROM tblNhanVien WHERE MaNv = '{0}'", id));
            F = new FrmChamCong_DmNhanVienDtl(dataTable, ECommand.EUpdate);
            F.Text = EasyMessageGlobal.EditTitle + name;
            F.ShowDialog();
            EasyLoadWait.CloseWaitForm();

            if (F.IsChange) OnInit();
            customGridView.FocusedRowHandle = RowIndex;
            customGridView.TopRowIndex = TopRowIndex;
        }

        protected override void OnAdd()
        {
            DataTable dt = null;
            F = new FrmChamCong_DmNhanVienDtl(dt, ECommand.EAdd);
            F.Text = EasyMessageGlobal.AddTitle;
            F.ShowDialog();
            if (F.IsChange) OnInit();
        }

        protected override void OnDelete()
        {
            try
            {
                if (customGridView.FocusedRowHandle < 0) return;
                TopRowIndex = customGridView.TopRowIndex;
                RowIndex = customGridView.FocusedRowHandle;
                var id = customGridView.GetRowCellValue(customGridView.FocusedRowHandle, colMaNv).ToString();
                if (EasyDialog.ShowYesNoDialog("Bạn có chắc chắn muốn (Xoá) mục đang chọn?") == DialogResult.Yes)
                {
                    EasyLoadWait.ShowWaitForm();

                    SQLHelper.ExecuteNonQuery(string.Format("DELETE tblNhanVien WHERE MaNv = '{0}'", id));

                    OnInit();
                    EasyLoadWait.CloseWaitForm();
                    ShowAlertString("Thông báo", "Xử lý thành công!", IconAlert.Done);
                }

                customGridView.FocusedRowHandle = RowIndex;
                customGridView.TopRowIndex = TopRowIndex;
            }
            catch (SqlException sqlEx)
            {
                switch (sqlEx.Number)
                {
                    case 547:
                        ShowAlertString("Thông báo",
                            "Không thể xoá bán ghi này!",
                            IconAlert.Warning);
                        break;
                    default:
                        throw;
                }
            }
            catch (Exception exception)
            {
                EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");
            }
        }

        private void customGridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (customGridView.IsGroupRow(customGridView.FocusedRowHandle))
                return;
            if (e.Button == MouseButtons.Left)
            {
                OnEdit();
            }
        }
    }
}