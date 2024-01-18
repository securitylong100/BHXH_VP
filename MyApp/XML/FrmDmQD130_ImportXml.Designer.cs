namespace XML130.XML
{
    partial class FrmDmQD130_ImportXml
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDmQD130_ImportXml));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.customGridControl = new XML130.CustomGridLookUpEdit.CustomGridControl();
            this.customGridView = new XML130.CustomGridLookUpEdit.CustomGridView();
            this.lbLogs = new DevExpress.XtraEditors.ListBoxControl();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.btnImportXmlFolder = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportXml = new DevExpress.XtraBars.BarButtonItem();
            this.col_MA_LK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MACSKCB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NGAYLAP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SOLUONGHOSO = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 45);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.customGridControl);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lbLogs);
            this.splitContainer.Size = new System.Drawing.Size(694, 324);
            this.splitContainer.SplitterDistance = 222;
            this.splitContainer.TabIndex = 0;
            // 
            // customGridControl
            // 
            this.customGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridControl.Location = new System.Drawing.Point(0, 0);
            this.customGridControl.MainView = this.customGridView;
            this.customGridControl.Name = "customGridControl";
            this.customGridControl.Size = new System.Drawing.Size(694, 222);
            this.customGridControl.TabIndex = 0;
            this.customGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.customGridView});
            // 
            // customGridView
            // 
            this.customGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_MA_LK,
            this.col_MACSKCB,
            this.col_NGAYLAP,
            this.col_SOLUONGHOSO});
            this.customGridView.GridControl = this.customGridControl;
            this.customGridView.Name = "customGridView";
            // 
            // lbLogs
            // 
            this.lbLogs.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.lbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLogs.Location = new System.Drawing.Point(0, 0);
            this.lbLogs.Name = "lbLogs";
            this.lbLogs.Size = new System.Drawing.Size(694, 98);
            this.lbLogs.TabIndex = 0;
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnImportXmlFolder,
            this.btnExportXml});
            this.barManager.MainMenu = this.bar2;
            this.barManager.MaxItemId = 2;
            this.barManager.StatusBar = this.bar3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(694, 45);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 369);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(694, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 45);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 324);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(694, 45);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 324);
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImportXmlFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportXml)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // btnImportXmlFolder
            // 
            this.btnImportXmlFolder.Caption = "Mở thư mục Xml";
            this.btnImportXmlFolder.Id = 0;
            this.btnImportXmlFolder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImportXmlFolder.ImageOptions.Image")));
            this.btnImportXmlFolder.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnImportXmlFolder.ImageOptions.LargeImage")));
            this.btnImportXmlFolder.Name = "btnImportXmlFolder";
            this.btnImportXmlFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportXmlFolder_ItemClick);
            // 
            // btnExportXml
            // 
            this.btnExportXml.Caption = "Xuất Xml";
            this.btnExportXml.Id = 1;
            this.btnExportXml.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportXml.ImageOptions.Image")));
            this.btnExportXml.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExportXml.ImageOptions.LargeImage")));
            this.btnExportXml.Name = "btnExportXml";
            this.btnExportXml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportXml_ItemClick);
            // 
            // col_MA_LK
            // 
            this.col_MA_LK.Caption = "Mã LK";
            this.col_MA_LK.FieldName = "MA_LK";
            this.col_MA_LK.Name = "col_MA_LK";
            this.col_MA_LK.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.col_MA_LK.Visible = true;
            this.col_MA_LK.VisibleIndex = 0;
            // 
            // col_MACSKCB
            // 
            this.col_MACSKCB.Caption = "Mã cơ sở KCB";
            this.col_MACSKCB.FieldName = "MACSKCB";
            this.col_MACSKCB.Name = "col_MACSKCB";
            this.col_MACSKCB.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.col_MACSKCB.Visible = true;
            this.col_MACSKCB.VisibleIndex = 1;
            // 
            // col_NGAYLAP
            // 
            this.col_NGAYLAP.Caption = "Ngày lập";
            this.col_NGAYLAP.FieldName = "NGAYLAP";
            this.col_NGAYLAP.Name = "col_NGAYLAP";
            this.col_NGAYLAP.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.col_NGAYLAP.Visible = true;
            this.col_NGAYLAP.VisibleIndex = 2;
            // 
            // col_SOLUONGHOSO
            // 
            this.col_SOLUONGHOSO.Caption = "Số lượng hồ sơ";
            this.col_SOLUONGHOSO.FieldName = "SOLUONGHOSO";
            this.col_SOLUONGHOSO.Name = "col_SOLUONGHOSO";
            this.col_SOLUONGHOSO.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.col_SOLUONGHOSO.Visible = true;
            this.col_SOLUONGHOSO.VisibleIndex = 3;
            // 
            // FrmDmQD130_ImportXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 389);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmDmQD130_ImportXml";
            this.Text = "FrmDmQD130_ImportXml";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private CustomGridLookUpEdit.CustomGridControl customGridControl;
        private CustomGridLookUpEdit.CustomGridView customGridView;
        private DevExpress.XtraEditors.ListBoxControl lbLogs;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnImportXmlFolder;
        private DevExpress.XtraBars.BarButtonItem btnExportXml;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn col_MA_LK;
        private DevExpress.XtraGrid.Columns.GridColumn col_MACSKCB;
        private DevExpress.XtraGrid.Columns.GridColumn col_NGAYLAP;
        private DevExpress.XtraGrid.Columns.GridColumn col_SOLUONGHOSO;
    }
}