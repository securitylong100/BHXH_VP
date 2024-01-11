namespace XML130.InterfaceInheritance
{
    partial class FrmBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBase));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar = new DevExpress.XtraBars.Bar();
            this.barSearch = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btnExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnImport = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintOther = new DevExpress.XtraBars.BarButtonItem();
            this.btnProperties = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItemTime = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTime = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barEditItemFrom = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemFrom = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barEditItemTo = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTo = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.btnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.alertControl = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFrom.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTo.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.AllowQuickCustomization = false;
            this.barManager.AllowShowToolbarsPopup = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar,
            this.barSearch});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnSave,
            this.btnReload,
            this.btnExport,
            this.btnImport,
            this.btnPrint,
            this.btnPrintOther,
            this.btnProperties,
            this.barEditItemTime,
            this.barEditItemFrom,
            this.barEditItemTo,
            this.btnSearch,
            this.btnClose});
            this.barManager.MaxItemId = 22;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTime,
            this.repositoryItemFrom,
            this.repositoryItemTo});
            // 
            // bar
            // 
            this.bar.BarName = "Tools";
            this.bar.DockCol = 0;
            this.bar.DockRow = 0;
            this.bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar.OptionsBar.AllowQuickCustomization = false;
            this.bar.OptionsBar.DisableCustomization = true;
            this.bar.OptionsBar.DrawDragBorder = false;
            this.bar.OptionsBar.UseWholeRow = true;
            this.bar.Text = "Tools";
            // 
            // barSearch
            // 
            this.barSearch.BarName = "Custom 3";
            this.barSearch.DockCol = 0;
            this.barSearch.DockRow = 1;
            this.barSearch.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barSearch.OptionsBar.AllowQuickCustomization = false;
            this.barSearch.OptionsBar.DisableCustomization = true;
            this.barSearch.OptionsBar.DrawDragBorder = false;
            this.barSearch.OptionsBar.UseWholeRow = true;
            this.barSearch.Text = "Custom 3";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(298, 50);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 268);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(298, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 50);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 218);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(298, 50);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 218);
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Thêm";
            this.btnAdd.Id = 0;
            this.btnAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAdd.ImageOptions.SvgImage")));
            this.btnAdd.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Sửa";
            this.btnEdit.Id = 1;
            this.btnEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEdit.ImageOptions.SvgImage")));
            this.btnEdit.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Id = 2;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Id = 3;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Nạp lại";
            this.btnReload.Id = 4;
            this.btnReload.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnReload.ImageOptions.SvgImage")));
            this.btnReload.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnReload.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnReload.Name = "btnReload";
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // btnExport
            // 
            this.btnExport.Caption = "Xuất ra Excel";
            this.btnExport.Id = 5;
            this.btnExport.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExport_ItemClick);
            // 
            // btnImport
            // 
            this.btnImport.Caption = "Nhập từ Excel";
            this.btnImport.Id = 6;
            this.btnImport.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnImport.Name = "btnImport";
            this.btnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImport_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In phiếu";
            this.btnPrint.Id = 8;
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnPrintOther
            // 
            this.btnPrintOther.Caption = "In khác";
            this.btnPrintOther.Id = 9;
            this.btnPrintOther.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintOther.ImageOptions.SvgImage")));
            this.btnPrintOther.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnPrintOther.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.btnPrintOther.Name = "btnPrintOther";
            this.btnPrintOther.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrintOther_ItemClick);
            // 
            // btnProperties
            // 
            this.btnProperties.Caption = "Thông tin khởi tạo";
            this.btnProperties.Id = 10;
            this.btnProperties.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnProperties.ImageOptions.SvgImage")));
            this.btnProperties.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnProperties.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F7);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProperties_ItemClick);
            // 
            // barEditItemTime
            // 
            this.barEditItemTime.Caption = "Chọn kỳ";
            this.barEditItemTime.Edit = this.repositoryItemTime;
            this.barEditItemTime.EditWidth = 170;
            this.barEditItemTime.Id = 17;
            this.barEditItemTime.Name = "barEditItemTime";
            this.barEditItemTime.EditValueChanged += new System.EventHandler(this.barEditItemTime_EditValueChanged);
            // 
            // repositoryItemTime
            // 
            this.repositoryItemTime.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.repositoryItemTime.Appearance.Options.UseFont = true;
            this.repositoryItemTime.AutoHeight = false;
            this.repositoryItemTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTime.Name = "repositoryItemTime";
            this.repositoryItemTime.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repositoryItemTime.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.None;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.ColumnPanelRowHeight = 35;
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdTime,
            this.colNameTime});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colIdTime
            // 
            this.colIdTime.FieldName = "id";
            this.colIdTime.Name = "colIdTime";
            // 
            // colNameTime
            // 
            this.colNameTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNameTime.AppearanceHeader.Options.UseFont = true;
            this.colNameTime.Caption = "Diễn giải";
            this.colNameTime.FieldName = "name";
            this.colNameTime.Name = "colNameTime";
            this.colNameTime.Visible = true;
            this.colNameTime.VisibleIndex = 0;
            // 
            // barEditItemFrom
            // 
            this.barEditItemFrom.Caption = "Từ ngày";
            this.barEditItemFrom.Edit = this.repositoryItemFrom;
            this.barEditItemFrom.EditWidth = 90;
            this.barEditItemFrom.Id = 18;
            this.barEditItemFrom.Name = "barEditItemFrom";
            // 
            // repositoryItemFrom
            // 
            this.repositoryItemFrom.AutoHeight = false;
            this.repositoryItemFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFrom.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFrom.Name = "repositoryItemFrom";
            // 
            // barEditItemTo
            // 
            this.barEditItemTo.Caption = "Đến ngày";
            this.barEditItemTo.Edit = this.repositoryItemTo;
            this.barEditItemTo.EditWidth = 90;
            this.barEditItemTo.Id = 19;
            this.barEditItemTo.Name = "barEditItemTo";
            // 
            // repositoryItemTo
            // 
            this.repositoryItemTo.AutoHeight = false;
            this.repositoryItemTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTo.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTo.Name = "repositoryItemTo";
            // 
            // btnSearch
            // 
            this.btnSearch.Caption = "Lấy dữ liệu";
            this.btnSearch.Id = 20;
            this.btnSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSearch.ImageOptions.SvgImage")));
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSearch_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Đóng";
            this.btnClose.Id = 21;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // alertControl
            // 
            this.alertControl.AutoFormDelay = 1000;
            this.alertControl.Images = this.imageCollection;
            this.alertControl.ShowPinButton = false;
            this.alertControl.BeforeFormShow += new DevExpress.XtraBars.Alerter.AlertFormEventHandler(this.alertControl_BeforeFormShow);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(0, "Apply_32x32.png");
            this.imageCollection.Images.SetKeyName(1, "BORules_32x32.png");
            // 
            // popupMenu
            // 
            this.popupMenu.Manager = this.barManager;
            this.popupMenu.Name = "popupMenu";
            // 
            // FrmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 268);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBase";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBase_FormClosing);
            this.Load += new System.EventHandler(this.FrmBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFrom.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTo.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected DevExpress.XtraBars.Bar bar;
        protected DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
        private DevExpress.Utils.ImageCollection imageCollection;
        protected DevExpress.XtraBars.BarButtonItem btnAdd;
        protected DevExpress.XtraBars.BarButtonItem btnEdit;
        protected DevExpress.XtraBars.BarButtonItem btnDelete;
        protected DevExpress.XtraBars.BarButtonItem btnSave;
        protected DevExpress.XtraBars.BarButtonItem btnReload;
        protected DevExpress.XtraBars.BarButtonItem btnExport;
        protected DevExpress.XtraBars.BarButtonItem btnImport;
        protected DevExpress.XtraBars.BarButtonItem btnPrint;
        protected DevExpress.XtraBars.BarButtonItem btnPrintOther;
        protected DevExpress.XtraBars.PopupMenu popupMenu;
        protected DevExpress.XtraBars.BarButtonItem btnProperties;
        protected DevExpress.XtraBars.Bar barSearch;
        protected DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemTime;
        protected DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        protected DevExpress.XtraGrid.Columns.GridColumn colIdTime;
        protected DevExpress.XtraGrid.Columns.GridColumn colNameTime;
        protected DevExpress.XtraBars.BarEditItem barEditItemTime;
        protected DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemFrom;
        protected DevExpress.XtraBars.BarEditItem barEditItemFrom;
        protected DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemTo;
        protected DevExpress.XtraBars.BarEditItem barEditItemTo;
        protected DevExpress.XtraBars.BarButtonItem btnSearch;
        protected DevExpress.XtraBars.BarButtonItem btnClose;
    }
}