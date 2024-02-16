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
using XML130.EasyData;
using DevExpress.Export;

namespace XML130.Func
{
    public partial class FrmChamCong_DLCC_LichSuChamCong : FrmBase
    {

        private string _query;
        public FrmChamCong_DLCC_LichSuChamCong()
        {
            InitializeComponent();

            EasyGridStyleHelper = new EasyGridStyleHelper(this, customGridControl, customGridView, false, true, false, false,
                false, false, true, true);
            barSearch.Visible = false;
        }

        protected override void OnInit()
        {
            //try
            //{
            //    DataTable dataTable = SQLHelper.ExecuteDataTable("SELECT * FROM CheckInOut ");
            //    customGridControl.DataSource = dataTable;
            //    if (dataTable.Rows.Count > 0)
            //    {
            //        //var colGroup = customGridView.Columns["TrangThaiText"];
            //        //colGroup.GroupIndex = 0;
            //        customGridView.ExpandAllGroups();
            //    }

            //    EasyCommon.BestFitColumnsGridView(customGridView);
            //}
            //catch (Exception exception)
            //{
            //    EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");
            //}

            barEditItemTime.EditValue = EasyValue.ValueTime;
            OnSearch();
        }

        protected override void OnSearch()
        {
            try
            {
                //CASE a.GioiTinh WHEN 1 THEN N'Nam' WHEN 2 THEN N'Nữ' ELSE N'Không xác định' END AS GioiTinh
                _query = "SELECT *,CASE b.GioiTinh WHEN 1 THEN N'Nam' WHEN 2 THEN N'Nữ' ELSE N'Không xác định' END AS GioiTinh2, IIF (DATENAME(WEEKDAY,a.TimeDate)='Monday','T2',IIF (DATENAME(WEEKDAY,a.TimeDate)='Tuesday','T3',IIF (DATENAME(WEEKDAY,a.TimeDate)='Wednesday','T4',IIF(DATENAME(WEEKDAY, a.TimeDate) = 'Thursday', 'T5', IIF(DATENAME(WEEKDAY, a.TimeDate) = 'Friday', 'T6', IIF(DATENAME(WEEKDAY, a.TimeDate) = 'Saturday', 'T7', 'CN')))))) AS Thu  FROM [WiseEyeMix3].dbo.CheckInOut a , tblNhanVien b WHERE a.UserEnrollNumber=b.UserEnrollNumber AND";
                if (barEditItemFrom.EditValue != null && barEditItemTo.EditValue != null)
                {
                    _query += " a.TimeDate BETWEEN '" +
                              Convert.ToDateTime(barEditItemFrom.EditValue).ToString("MM/dd/yyyy") + "' AND '" +
                              Convert.ToDateTime(barEditItemTo.EditValue).ToString("MM/dd/yyyy") + "' ";
                }
                _query += "ORDER BY  B.Stt,a.TimeStr"; //a.UserEnrollNumber
                var dataTable = SQLHelper.ExecuteDataTable(_query);
                customGridControl.DataSource = dataTable;

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
            
        }

        protected override void OnAdd()
        {
            
        }

        protected override void OnDelete()
        {
            
        }

        private void customGridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EasyCommon.ExportToExcel(Text, customGridView, null, AutoSize, ExportType.WYSIWYG, true);
        }
    }
}