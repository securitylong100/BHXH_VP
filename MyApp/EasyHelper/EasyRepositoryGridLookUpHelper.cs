using System;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using XML130.CustomGridLookUpEdit;

namespace XML130.EasyHelper
{
    public class EasyRepositoryGridLookUpHelper
    {
        public static void EasyGridLookUpHelperRp(XtraForm form, RepositoryItemCustomGridLookUpEdit view,
            CustomGridView customGridView, GridColumn column, string nullText, string valueMember, string displayMember,
            Int32 a, Int32 b)
        {
            customGridView.ColumnPanelRowHeight = 35;
            customGridView.OptionsView.ShowAutoFilterRow = true;
            customGridView.OptionsCustomization.AllowFilter = false;
            customGridView.OptionsCustomization.AllowSort = false;
            var size = new Size(a, b);
            view.PopupFormMinSize = size;
            view.AllowNullInput = DefaultBoolean.True;
            view.TextEditStyle = TextEditStyles.Standard;
            view.NullText = nullText;
            view.PopupFilterMode = PopupFilterMode.Contains;
            view.BestFitMode = BestFitMode.BestFitResizePopup;
            view.ImmediatePopup = true;
            view.ValueMember = valueMember;
            view.DisplayMember = displayMember;
            column.ColumnEdit = view;
            column.AppearanceHeader.Font = new Font("Tahoma", 8.00F, FontStyle.Bold, GraphicsUnit.Point, 0);
            column.AppearanceHeader.Options.UseFont = true;
            column.AppearanceHeader.Options.UseTextOptions = true;
            column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            column.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
        }
    }
}