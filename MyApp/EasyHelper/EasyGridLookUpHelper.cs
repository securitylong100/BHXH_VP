using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Images;
using DevExpress.Utils;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using XML130.CustomGridLookUpEdit;
using XML130.EasyUtils;

namespace XML130.EasyHelper
{
    public class EasyGridLookUpHelper
    {
        public EasyGridLookUpHelper(XtraForm form, CustomGridLookUpEdit.CustomGridLookUpEdit view,
            CustomGridView customGridView, string nullText, string valueMember, string displayMember, bool btnAdd,
            bool btnClear)
        {
            _form = form;
            _view = view;
            _id = valueMember;
            _customGridView = customGridView;
            _customGridView.ColumnPanelRowHeight = 35;
            _customGridView.OptionsView.ShowAutoFilterRow = true;
            _customGridView.OptionsCustomization.AllowFilter = false;
            _customGridView.OptionsCustomization.AllowSort = false;
            foreach (GridColumn column in customGridView.Columns)
            {
                column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                column.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                column.AppearanceHeader.Font = new Font("Tahoma", 8.00F, FontStyle.Bold, GraphicsUnit.Point, 0);
            }
            customGridView.FocusRectStyle = DrawFocusRectStyle.None;
            view.Properties.PopupFormMinSize = new Size(360, 150);
            view.Properties.AllowNullInput = DefaultBoolean.True;
            view.Properties.TextEditStyle = TextEditStyles.Standard;
            view.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            view.Properties.NullText = nullText;
            view.Properties.ImmediatePopup = true;
            view.Properties.ValueMember = valueMember;
            view.Properties.DisplayMember = displayMember;
            view.Popup += _view_Popup;
            view.CloseUp += _view_CloseUp;
            customGridView.CustomDrawRowIndicator += _customGridView_CustomDrawRowIndicator;
            var serializableAppearanceObject1 = new SerializableAppearanceObject();
            var serializableAppearanceObject2 = new SerializableAppearanceObject();

            if (btnAdd)
                view.Properties.Buttons.AddRange(new[]
                {
                    new EditorButton(ButtonPredefines.Glyph, "btnAdd", -1, true, true, false, ImageLocation.MiddleCenter,
                        ImageResourceCache.Default.GetImage("office2013/actions/add_16x16.png"),
                        new KeyShortcut(Keys.None), serializableAppearanceObject1, "", null, null, true)
                });
            if (btnClear)
                view.Properties.Buttons.AddRange(new[]
                {
                    new EditorButton(ButtonPredefines.Glyph, "btnClear", -1, true, true, false,
                        ImageLocation.MiddleCenter,
                        ImageResourceCache.Default.GetImage("office2013/actions/clear_16x16.png"),
                        new KeyShortcut(Keys.None), serializableAppearanceObject2, "", null, null, true)
                });
        }

        #region "Khai báo thuộc tính"

        private readonly CustomGridLookUpEdit.CustomGridLookUpEdit _view;
        private readonly CustomGridView _customGridView;
        private readonly XtraForm _form;
        private readonly string _id;

        #endregion

        #region "Event"

        private void _view_Popup(object sender, EventArgs e)
        {
            var form = (_view as IPopupControl).PopupWindow as PopupGridLookUpEditForm;
            if (form != null) form.KeyDown += _view_KeyDown;
        }

        private void _view_CloseUp(object sender, CloseUpEventArgs e)
        {
            var form =
                (_view as IPopupControl).PopupWindow as PopupGridLookUpEditForm;
            if (form != null) form.KeyDown -= _view_KeyDown;
        }

        private void _view_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (_customGridView.RowCount <= 0) return;
                    if (_view.Text == null) return;
                    var idNo = _view.Text.ToUpper();
                    for (var i = 0; i < _customGridView.RowCount; i++)
                    {
                        var val = _customGridView.GetRowCellValue(i, _id).ToString();
                        var val2 = _customGridView.GetFocusedRowCellValue(_id);
                        // trường hợp nhập đúng mã đã có
                        if (val.Equals(idNo))
                        {
                            _customGridView.FocusedRowHandle = i;
                            break;
                        }
                        // trường hợp nhập và mã nhập đã có nhưng chưa phải mã muốn chọn
                        if (val.Equals(idNo) && val2 != null)
                        {
                            _view.EditValue = val2;
                            break;
                        }

                        // trường hợp tự chọn dòng sau khi nhập mã
                        if (val2 != null)
                        {
                            _view.EditValue = val2;
                            break;
                        }
                        if (i == _customGridView.RowCount - 1 && !val.Equals(idNo))
                        {
                            _customGridView.FocusedRowHandle = 0;
                            break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");
            }
        }

        private void _customGridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!_customGridView.IsGroupRow(e.RowHandle))
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
                var with = Convert.ToInt32(size.Width) + 20;
                _form.BeginInvoke(new MethodInvoker(delegate { cal(with, _customGridView); }));
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", e.RowHandle*-1);
                e.Info.Appearance.Font = new Font("Tahoma", 8.00F, FontStyle.Bold, GraphicsUnit.Point, 0);
                var size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                var width = Convert.ToInt32(size.Width) + 20;
                _form.BeginInvoke(new MethodInvoker(delegate { cal(width, _customGridView); }));
            }
        }

        private void cal(int width, CustomGridView view)
        {
            view.IndicatorWidth = view.IndicatorWidth < width ? width : view.IndicatorWidth;
        }

        #endregion
    }
}