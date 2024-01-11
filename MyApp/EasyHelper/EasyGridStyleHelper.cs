using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace XML130.EasyHelper
{
    public class EasyGridStyleHelper
    {
        #region "Khai báo thuộc tính"

        private readonly GridView _view;
        private readonly XtraForm _form;

        #endregion

        #region "Phương thức với GridView"

        private void view_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!_view.IsGroupRow(e.RowHandle))
            {
                if (!e.Info.IsRowIndicator) return;
                if (e.RowHandle < 0)
                {
                    e.Info.ImageIndex = 0;
                    e.Info.DisplayText = string.Empty;
                }
                else
                {
                    e.Info.ImageIndex = -1;
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    e.Info.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                }
                var size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                var with = Convert.ToInt32(size.Width) + 15;
                _form.BeginInvoke(new MethodInvoker(delegate { cal(with, _view); }));
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", e.RowHandle*-1);
                e.Info.Appearance.Font = new Font("Tahoma", 8.00F, FontStyle.Bold, GraphicsUnit.Point, 0);
                var size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                var width = Convert.ToInt32(size.Width) + 15;
                _form.BeginInvoke(new MethodInvoker(delegate { cal(width, _view); }));
            }
        }

        private void cal(int width, GridView view)
        {
            view.IndicatorWidth = view.IndicatorWidth < width ? width : view.IndicatorWidth;
        }

        private void view_MouseWheel(object sender, MouseEventArgs e)
        {
            var gridView = sender as GridView;
            if (gridView != null && gridView.IsEditing)
            {
                (sender as GridView).CloseEditor();
                (sender as GridView).UpdateCurrentRow();
            }
        }

        #endregion

        #region "Helper GridView"

        public EasyGridStyleHelper(XtraForm form, GridControl gridControl, GridView view,
            bool showFooter, bool showFilterRow, bool showGroupPanel,
            bool columnAutoWidth, bool showSelection, bool allowEdit,
            bool allowUseEmbeddedNavigator, bool allowBoldHeader)
        {
            _form = form;
            _view = view;
            _view.CustomDrawRowIndicator += view_CustomDrawRowIndicator;
            _view.MouseWheel += view_MouseWheel;
            _view.FocusRectStyle = DrawFocusRectStyle.None;

            gridControl.UseEmbeddedNavigator = allowUseEmbeddedNavigator;
            gridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridControl.EmbeddedNavigator.TextStringFormat = @"Dòng {0} / {1}";

            _view.ColumnPanelRowHeight = 35;
            _view.OptionsView.ShowFooter = showFooter;
            _view.OptionsView.ShowAutoFilterRow = showFilterRow;
            _view.OptionsCustomization.AllowFilter = false;
            _view.OptionsCustomization.AllowSort = false;

            _view.OptionsSelection.MultiSelect = showSelection;
            _view.OptionsSelection.MultiSelectMode = showSelection
                ? GridMultiSelectMode.CheckBoxRowSelect
                : GridMultiSelectMode.RowSelect;
            _view.OptionsSelection.CheckBoxSelectorColumnWidth = 35;

            _view.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _view.OptionsView.ShowGroupPanel = showGroupPanel;
            _view.OptionsView.ColumnAutoWidth = columnAutoWidth;

            _view.OptionsFind.AllowFindPanel = false;

            _view.Appearance.FooterPanel.Font = new Font("Tahoma", 8.00F, FontStyle.Bold, GraphicsUnit.Point, 0);
            if (allowBoldHeader)
            {
                foreach (GridColumn col in _view.Columns)
                {
                    col.AppearanceHeader.Font = new Font("Times New Roman", 10.50F, FontStyle.Bold, GraphicsUnit.Point, 0);//"Tahoma", 8.00F
                    col.AppearanceHeader.Options.UseFont = true;
                    col.AppearanceHeader.Options.UseTextOptions = true;
                    col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                    if (allowEdit)
                    {
                        col.OptionsColumn.AllowEdit = true;
                        col.OptionsColumn.AllowFocus = true;
                    }
                    else
                    {
                        col.OptionsColumn.AllowEdit = false;
                        col.OptionsColumn.AllowFocus = false;
                    }
                }
            }
        }

        public EasyGridStyleHelper(XtraForm form, GridControl gridControl, GridView view,
            bool showFooter, bool showFilterRow, bool showGroupPanel,
            bool columnAutoWidth, bool showSelection,
            bool allowUseEmbeddedNavigator, bool allowBoldHeader)
        {
            _form = form;
            _view = view;
            _view.CustomDrawRowIndicator += view_CustomDrawRowIndicator;
            _view.MouseWheel += view_MouseWheel;
            _view.FocusRectStyle = DrawFocusRectStyle.None;

            gridControl.UseEmbeddedNavigator = allowUseEmbeddedNavigator;
            gridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridControl.EmbeddedNavigator.TextStringFormat = @"Dòng {0} / {1}";

            _view.ColumnPanelRowHeight = 35;
            _view.OptionsView.ShowFooter = showFooter;
            _view.OptionsView.ShowAutoFilterRow = showFilterRow;
            _view.OptionsCustomization.AllowFilter = false;
            _view.OptionsCustomization.AllowSort = false;

            _view.OptionsSelection.MultiSelect = showSelection;
            _view.OptionsSelection.MultiSelectMode = showSelection
                ? GridMultiSelectMode.CheckBoxRowSelect
                : GridMultiSelectMode.RowSelect;
            _view.OptionsSelection.CheckBoxSelectorColumnWidth = 35;

            _view.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _view.OptionsView.ShowGroupPanel = showGroupPanel;
            _view.OptionsView.ColumnAutoWidth = columnAutoWidth;

            _view.Appearance.FooterPanel.Font = new Font("Tahoma", 8.00F, FontStyle.Bold, GraphicsUnit.Point, 0);
            if (allowBoldHeader)
            {
                foreach (GridColumn col in _view.Columns)
                {
                    col.AppearanceHeader.Font = new Font("Tahoma", 8.00F, FontStyle.Bold, GraphicsUnit.Point, 0);
                    col.AppearanceHeader.Options.UseFont = true;
                    col.AppearanceHeader.Options.UseTextOptions = true;
                    col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                }
            }
        }

        #endregion
    }
}