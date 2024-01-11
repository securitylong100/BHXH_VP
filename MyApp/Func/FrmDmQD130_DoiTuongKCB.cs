using XML130.Libraries;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.Export;
using XML130.EasyEnum;
using XML130.EasyHelper;
using XML130.EasyUtils;
using XML130.InterfaceInheritance;

namespace XML130.Func
{
    public partial class FrmDmQD130_DoiTuongKCB : FrmBase
    {
        public FrmDmQD130_DoiTuongKCB()
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
                DataTable dataTable = SQLHelper.ExecuteDataTable(string.Format("SELECT * FROM tblDmQD130_DoiTuongKCB"));
                customGridControl.DataSource = dataTable;

                EasyCommon.BestFitColumnsGridView(customGridView);
            }
            catch (Exception exception)
            {
                EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");
            }
        }

        // hàm làm tươi
        protected override void OnReload()
        {
            OnInit();
        }


        protected override void OnExport()
        {
            EasyCommon.ExportToExcel(Text, customGridView, null, AutoSize, ExportType.WYSIWYG, true);
        }

    }
}
