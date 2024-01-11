
namespace XML130.Func
{
    partial class FrmDmCSKCB_TTB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDmCSKCB_TTB));
            this.customGridControl = new XML130.CustomGridLookUpEdit.CustomGridControl();
            this.customGridView = new XML130.CustomGridLookUpEdit.CustomGridView();
            this.colTEN_TB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKY_HIEU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCONGTY_SX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNUOC_SX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNAM_SX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNAM_SD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMA_MAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTU_NGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHD_DEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHD_TU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSO_LUU_HANH = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFrom.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTo.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bar
            // 
            this.bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReload),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExport)});
            this.bar.OptionsBar.AllowQuickCustomization = false;
            this.bar.OptionsBar.DisableCustomization = true;
            this.bar.OptionsBar.DrawDragBorder = false;
            this.bar.OptionsBar.UseWholeRow = true;
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAdd.ImageOptions.SvgImage")));
            this.btnAdd.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnEdit
            // 
            this.btnEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEdit.ImageOptions.SvgImage")));
            this.btnEdit.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            // 
            // btnReload
            // 
            this.btnReload.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnReload.ImageOptions.SvgImage")));
            this.btnReload.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnReload.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnExport
            // 
            this.btnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.Image")));
            this.btnExport.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnImport
            // 
            this.btnImport.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            // 
            // btnPrint
            // 
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            // 
            // btnPrintOther
            // 
            this.btnPrintOther.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintOther.ImageOptions.SvgImage")));
            this.btnPrintOther.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            // 
            // btnProperties
            // 
            this.btnProperties.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnProperties.ImageOptions.SvgImage")));
            this.btnProperties.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            // 
            // barSearch
            // 
            this.barSearch.OptionsBar.AllowQuickCustomization = false;
            this.barSearch.OptionsBar.DisableCustomization = true;
            this.barSearch.OptionsBar.DrawDragBorder = false;
            this.barSearch.OptionsBar.UseWholeRow = true;
            this.barSearch.Visible = false;
            // 
            // repositoryItemTime
            // 
            this.repositoryItemTime.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.repositoryItemTime.Appearance.Options.UseFont = true;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colNameTime
            // 
            this.colNameTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNameTime.AppearanceHeader.Options.UseFont = true;
            // 
            // repositoryItemFrom
            // 
            // 
            // repositoryItemTo
            // 
            // 
            // btnSearch
            // 
            this.btnSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSearch.ImageOptions.SvgImage")));
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            // 
            // customGridControl
            // 
            this.customGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridControl.Location = new System.Drawing.Point(0, 62);
            this.customGridControl.MainView = this.customGridView;
            this.customGridControl.MenuManager = this.barManager;
            this.customGridControl.Name = "customGridControl";
            this.customGridControl.Size = new System.Drawing.Size(1189, 478);
            this.customGridControl.TabIndex = 4;
            this.customGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.customGridView});
            // 
            // customGridView
            // 
            this.customGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTEN_TB,
            this.colKY_HIEU,
            this.colCONGTY_SX,
            this.colNUOC_SX,
            this.colNAM_SX,
            this.colNAM_SD,
            this.colMA_MAY,
            this.colSO_LUU_HANH,
            this.colHD_TU,
            this.colHD_DEN,
            this.colTU_NGAY,
            this.colHL});
            this.customGridView.GridControl = this.customGridControl;
            this.customGridView.Name = "customGridView";
            this.customGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colTEN_TB
            // 
            this.colTEN_TB.Caption = "Tên thiết bị";
            this.colTEN_TB.FieldName = "TEN_TB";
            this.colTEN_TB.Name = "colTEN_TB";
            this.colTEN_TB.Visible = true;
            this.colTEN_TB.VisibleIndex = 0;
            this.colTEN_TB.Width = 322;
            // 
            // colKY_HIEU
            // 
            this.colKY_HIEU.Caption = "Ký hiệu";
            this.colKY_HIEU.FieldName = "KY_HIEU";
            this.colKY_HIEU.Name = "colKY_HIEU";
            this.colKY_HIEU.Visible = true;
            this.colKY_HIEU.VisibleIndex = 1;
            this.colKY_HIEU.Width = 101;
            // 
            // colCONGTY_SX
            // 
            this.colCONGTY_SX.Caption = "Công ty sản xuất";
            this.colCONGTY_SX.FieldName = "CONGTY_SX";
            this.colCONGTY_SX.Name = "colCONGTY_SX";
            this.colCONGTY_SX.Visible = true;
            this.colCONGTY_SX.VisibleIndex = 2;
            this.colCONGTY_SX.Width = 104;
            // 
            // colNUOC_SX
            // 
            this.colNUOC_SX.Caption = "Nước sản xuất";
            this.colNUOC_SX.FieldName = "NUOC_SX";
            this.colNUOC_SX.Name = "colNUOC_SX";
            this.colNUOC_SX.Visible = true;
            this.colNUOC_SX.VisibleIndex = 3;
            this.colNUOC_SX.Width = 89;
            // 
            // colNAM_SX
            // 
            this.colNAM_SX.Caption = "Năm sản xuất";
            this.colNAM_SX.FieldName = "NAM_SX";
            this.colNAM_SX.Name = "colNAM_SX";
            this.colNAM_SX.Visible = true;
            this.colNAM_SX.VisibleIndex = 4;
            this.colNAM_SX.Width = 179;
            // 
            // colNAM_SD
            // 
            this.colNAM_SD.Caption = "Năm sử dụng";
            this.colNAM_SD.FieldName = "NAM_SD";
            this.colNAM_SD.Name = "colNAM_SD";
            this.colNAM_SD.Visible = true;
            this.colNAM_SD.VisibleIndex = 5;
            this.colNAM_SD.Width = 150;
            // 
            // colMA_MAY
            // 
            this.colMA_MAY.Caption = "Mã máy";
            this.colMA_MAY.FieldName = "MA_MAY";
            this.colMA_MAY.Name = "colMA_MAY";
            this.colMA_MAY.Visible = true;
            this.colMA_MAY.VisibleIndex = 6;
            this.colMA_MAY.Width = 150;
            // 
            // colTU_NGAY
            // 
            this.colTU_NGAY.Caption = "Từ ngày";
            this.colTU_NGAY.FieldName = "TU_NGAY";
            this.colTU_NGAY.Name = "colTU_NGAY";
            this.colTU_NGAY.Visible = true;
            this.colTU_NGAY.VisibleIndex = 10;
            this.colTU_NGAY.Width = 165;
            // 
            // colHL
            // 
            this.colHL.Caption = "HL";
            this.colHL.FieldName = "HL";
            this.colHL.Name = "colHL";
            this.colHL.Visible = true;
            this.colHL.VisibleIndex = 11;
            this.colHL.Width = 94;
            // 
            // colHD_DEN
            // 
            this.colHD_DEN.Caption = "HD đến";
            this.colHD_DEN.FieldName = "HD_DEN";
            this.colHD_DEN.Name = "colHD_DEN";
            this.colHD_DEN.Visible = true;
            this.colHD_DEN.VisibleIndex = 9;
            this.colHD_DEN.Width = 84;
            // 
            // colHD_TU
            // 
            this.colHD_TU.Caption = "Hạn dùng từ";
            this.colHD_TU.FieldName = "HD_TU";
            this.colHD_TU.Name = "colHD_TU";
            this.colHD_TU.Visible = true;
            this.colHD_TU.VisibleIndex = 8;
            this.colHD_TU.Width = 84;
            // 
            // colSO_LUU_HANH
            // 
            this.colSO_LUU_HANH.Caption = "Số lưu hành";
            this.colSO_LUU_HANH.FieldName = "SO_LUU_HANH";
            this.colSO_LUU_HANH.Name = "colSO_LUU_HANH";
            this.colSO_LUU_HANH.Visible = true;
            this.colSO_LUU_HANH.VisibleIndex = 7;
            this.colSO_LUU_HANH.Width = 84;
            // 
            // FrmDmCSKCB_TTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 540);
            this.Controls.Add(this.customGridControl);
            this.Name = "FrmDmCSKCB_TTB";
            this.Text = "FrmDmCSKCB_TTB";
            this.Controls.SetChildIndex(this.customGridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFrom.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTo.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomGridLookUpEdit.CustomGridControl customGridControl;
        private CustomGridLookUpEdit.CustomGridView customGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colTEN_TB;
        private DevExpress.XtraGrid.Columns.GridColumn colKY_HIEU;
        private DevExpress.XtraGrid.Columns.GridColumn colCONGTY_SX;
        private DevExpress.XtraGrid.Columns.GridColumn colTU_NGAY;
        private DevExpress.XtraGrid.Columns.GridColumn colHL;
        private DevExpress.XtraGrid.Columns.GridColumn colNUOC_SX;
        private DevExpress.XtraGrid.Columns.GridColumn colNAM_SX;
        private DevExpress.XtraGrid.Columns.GridColumn colNAM_SD;
        private DevExpress.XtraGrid.Columns.GridColumn colMA_MAY;
        private DevExpress.XtraGrid.Columns.GridColumn colSO_LUU_HANH;
        private DevExpress.XtraGrid.Columns.GridColumn colHD_TU;
        private DevExpress.XtraGrid.Columns.GridColumn colHD_DEN;
    }
}