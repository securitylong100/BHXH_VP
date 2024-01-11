using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace XML130.EasyHelper
{
    public class EasyBandGridStyleHelper
    {
        #region "Khai báo thuộc tính"

        private readonly XtraForm _form;
        private readonly BandedGridView _bandedGridView;

        #endregion

        #region "Phương thức với GridViewBand"

        private void bandedGrid_CustomDrawBandHeader(object sender, BandHeaderCustomDrawEventArgs e)
        {
            e.Appearance.Font = new Font("Tahoma", 8.00F, FontStyle.Bold, GraphicsUnit.Point, 0);
            e.Appearance.Options.UseFont = true;
            e.Appearance.Options.UseTextOptions = true;
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            e.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
        }

        private void bandedGrid_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!_bandedGridView.IsGroupRow(e.RowHandle))
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
                _form.BeginInvoke(new MethodInvoker(delegate { calBand(with, _bandedGridView); }));
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", e.RowHandle*-1);
                e.Info.Appearance.Font = new Font("Tahoma", 8.00F, FontStyle.Bold, GraphicsUnit.Point, 0);
                var size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                var width = Convert.ToInt32(size.Width) + 15;
                _form.BeginInvoke(new MethodInvoker(delegate { calBand(width, _bandedGridView); }));
            }
        }

        private void calBand(int width, BandedGridView view)
        {
            view.IndicatorWidth = view.IndicatorWidth < width ? width : view.IndicatorWidth;
        }

        #endregion

        #region "Helper GridViewBand"

        public EasyBandGridStyleHelper(XtraForm form, GridControl gridControl, BandedGridView bandedGrid,
            bool showFooter, bool showFilterRow, bool columnAutoWidth,
            bool allowUseEmbeddedNavigator, bool showColumnHeader)
        {
            _form = form;
            _bandedGridView = bandedGrid;
            _bandedGridView.CustomDrawBandHeader += bandedGrid_CustomDrawBandHeader;
            _bandedGridView.CustomDrawRowIndicator += bandedGrid_CustomDrawRowIndicator;
            _bandedGridView.FocusRectStyle = DrawFocusRectStyle.None;

            gridControl.UseEmbeddedNavigator = allowUseEmbeddedNavigator;
            gridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridControl.EmbeddedNavigator.TextStringFormat = @"Dòng {0} / {1}";

            _bandedGridView.OptionsView.ShowFooter = showFooter;
            _bandedGridView.OptionsView.ShowAutoFilterRow = showFilterRow;
            _bandedGridView.OptionsCustomization.AllowFilter = false;
            _bandedGridView.OptionsCustomization.AllowSort = false;

            _bandedGridView.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            _bandedGridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _bandedGridView.OptionsView.ShowGroupPanel = false;
            _bandedGridView.OptionsView.ColumnAutoWidth = columnAutoWidth;
            _bandedGridView.OptionsView.ShowColumnHeaders = showColumnHeader;
            _bandedGridView.Appearance.FooterPanel.Font = new Font("Tahoma", 8.00F, FontStyle.Bold, GraphicsUnit.Point,
                0);
        }

        #endregion


    }
}