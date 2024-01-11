using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using XML130.EasyEnum;
using XML130.EasyHelper;
using XML130.EasyUtils;

namespace XML130.InterfaceInheritance
{
    public partial class FrmBase : DevExpress.XtraEditors.XtraForm
    {
        public bool AllowClose = true;
        protected EasyGridStyleHelper EasyGridStyleHelper;
        public bool IsChange { get; set; }
        public ECommand ECommand { get; set; }
        public string ItemToSearch { get; set; }
        public int RowIndex;
        public int TopRowIndex;
        protected FrmBase F;
        public Guid Value;
        public FrmBase()
        {
            InitializeComponent();

            var table = DateTime.Now.GetDateOfWeek();
            repositoryItemTime.NullText = @"-- Chọn kỳ --";
            repositoryItemTime.DisplayMember = "name";
            repositoryItemTime.ValueMember = "id";
            repositoryItemTime.DataSource = table;
            repositoryItemTime.BestFitMode = BestFitMode.BestFitResizePopup;
            repositoryItemTime.ImmediatePopup = true;
            repositoryItemTime.TextEditStyle = TextEditStyles.Standard;
            repositoryItemTime.View.FocusRectStyle = DrawFocusRectStyle.None;
        }

        #region Time

        protected virtual void LoadTime()
        {
            var dt = repositoryItemTime.DataSource as DataTable;
            if (dt != null && barEditItemTime.EditValue != null)
            {
                var lst =
                    dt.Rows.OfType<DataRow>()
                        .Where(x => x.Field<int>("id") == Int32.Parse(barEditItemTime.EditValue.ToString()))
                        .ToList();
                var en = lst.CopyToDataTable();
                var from = en.Rows[0]["from"].ToString();
                var to = en.Rows[0]["to"].ToString();
                barEditItemFrom.EditValue = DateTime.ParseExact(from, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                barEditItemTo.EditValue = DateTime.ParseExact(to, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }

        private void barEditItemTime_EditValueChanged(object sender, EventArgs e)
        {
            LoadTime();
        }

        #endregion

        #region Alert

        protected void ShowAlertString(string caption, string text, IconAlert icon)
        {
            SetAlertString(caption, text, icon);
        }

        public void SetAlertString(string caption, string text, IconAlert icon)
        {
            string imageName = string.Empty;
            if (icon == IconAlert.Done)
                imageName = "apply_32x32.png";
            else if (icon == IconAlert.Warning)
                imageName = "borules_32x32.png";
            alertControl.Show(this, caption, text, imageCollection.Images[imageName]);
        }

        private void alertControl_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            e.AlertForm.OpacityLevel = 1;
        }

        #endregion

        #region Event click

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnReload();
           
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnAdd();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnEdit();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnDelete();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnSave();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnPrint();
        }

        private void btnPrintOther_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnPrintOther();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnExport();
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnImport();
        }

        private void btnProperties_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnProperties();
        }
        private void FrmBase_Load(object sender, EventArgs e)
        {
            OnInit();
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnSearch();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnClose();
        }

        #endregion

        #region Method

        protected virtual void OnInit()
        {
        }

        protected virtual void OnReload()
        {
            
        }

        protected virtual void OnAdd()
        {
            
        }

        protected virtual void OnEdit()
        {
            
        }

        protected virtual void OnDelete() { }

        protected virtual void OnSave() { }

        protected virtual void OnPrint()
        {
        }

        protected virtual void OnExport()
        {
            
        }

        protected virtual void OnImport()
        {
        }

        protected virtual void OnPrintOther()
        {
        }

        protected virtual void OnProperties()
        {
        }

        protected virtual void OnSearch()
        {

        }

        protected virtual void OnClose()
        {
            //Close();
        }

        private IEnumerable<Component> EnumerateComponents() => ((IEnumerable<FieldInfo>)this.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).Where<FieldInfo>((System.Func<FieldInfo, bool>)(field => typeof(Component).IsAssignableFrom(field.FieldType))).Select(field =>
        {
            var data = new
            {
                field = field,
                component = (Component)field.GetValue((object)this)
            };
            return data;
        }).Where(param0 => param0.component != null).Select(param0 => param0.component);

        private BindingSource FindBindingSource()
        {
            Component component = EnumerateComponents().FirstOrDefault<Component>((System.Func<Component, bool>)(c => c is BindingSource));
            return component == null ? (BindingSource)null : component as BindingSource;
        }

        public bool IsDataChange()
        {
            Component component = EnumerateComponents().FirstOrDefault<Component>((System.Func<Component, bool>)(c => c is BindingSource));
            if (component == null || !((component as BindingSource).DataSource is DataSet dataSource))
                return false;
            dataSource.GetChanges();
            return dataSource.HasChanges();
        }

        public List<GridControl> FindGridControls()
        {
            LayoutControl layoutControl = FindLayoutControl();
            return layoutControl == null ? Controls.OfType<GridControl>().Select<GridControl, GridControl>((System.Func<GridControl, GridControl>)(c => c)).ToList<GridControl>() : layoutControl.Controls.OfType<GridControl>().Select<GridControl, GridControl>((System.Func<GridControl, GridControl>)(c => c)).ToList<GridControl>();
        }
        public LayoutControl FindLayoutControl() => Controls.OfType<LayoutControl>().Select<LayoutControl, LayoutControl>((System.Func<LayoutControl, LayoutControl>)(c => c)).FirstOrDefault<LayoutControl>();
        protected virtual bool OnCancelClosing()
        {
            BindingSource bindingSource = FindBindingSource();
            if (bindingSource != null)
            {
                try
                {
                    bindingSource.EndEdit();
                }
                catch
                {
                    bindingSource.CancelEdit();
                }
            }
            if (!AllowClose)
                return true;
            if (!IsDataChange())
                return false;
            switch (EasyDialog.ShowYesNoCancelDialog("Bạn có muốn lưu những thay đổi?"))
            {
                case DialogResult.Cancel:
                    return true;
                case DialogResult.No:
                    return false;
                default:
                    OnSave();
                    return false;
            }
        }

        #endregion

        private void FrmBase_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = OnCancelClosing();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                if (IsChange)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    Close();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}