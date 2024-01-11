
namespace XML130.Func
{
    partial class FrmNCC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNCC));
            this.customGridControl = new XML130.CustomGridLookUpEdit.CustomGridControl();
            this.customGridView = new XML130.CustomGridLookUpEdit.CustomGridView();
            this.colMaNCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenCoSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNguoiGiaoHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaSoThue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.customGridControl.Size = new System.Drawing.Size(1055, 478);
            this.customGridControl.TabIndex = 4;
            this.customGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.customGridView});
            // 
            // customGridView
            // 
            this.customGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaNCC,
            this.colTenCoSo,
            this.colDiaChi,
            this.colSDT,
            this.colTenNguoiGiaoHang,
            this.colMaSoThue,
            this.colGhiChu});
            this.customGridView.GridControl = this.customGridControl;
            this.customGridView.Name = "customGridView";
            this.customGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colMaNCC
            // 
            this.colMaNCC.Caption = "Mã NCC";
            this.colMaNCC.FieldName = "MaNCC";
            this.colMaNCC.Name = "colMaNCC";
            this.colMaNCC.Visible = true;
            this.colMaNCC.VisibleIndex = 0;
            this.colMaNCC.Width = 87;
            // 
            // colTenCoSo
            // 
            this.colTenCoSo.Caption = "Tên cơ sở";
            this.colTenCoSo.FieldName = "TenCoSo";
            this.colTenCoSo.Name = "colTenCoSo";
            this.colTenCoSo.Visible = true;
            this.colTenCoSo.VisibleIndex = 1;
            this.colTenCoSo.Width = 219;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Caption = "Địa chỉ";
            this.colDiaChi.FieldName = "DiaChi";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 2;
            this.colDiaChi.Width = 219;
            // 
            // colSDT
            // 
            this.colSDT.Caption = "Số điện thoại";
            this.colSDT.FieldName = "SDT";
            this.colSDT.Name = "colSDT";
            this.colSDT.Visible = true;
            this.colSDT.VisibleIndex = 3;
            this.colSDT.Width = 92;
            // 
            // colTenNguoiGiaoHang
            // 
            this.colTenNguoiGiaoHang.Caption = "Người giao hàng";
            this.colTenNguoiGiaoHang.FieldName = "TenNguoiGiaoHang";
            this.colTenNguoiGiaoHang.Name = "colTenNguoiGiaoHang";
            this.colTenNguoiGiaoHang.Visible = true;
            this.colTenNguoiGiaoHang.VisibleIndex = 4;
            this.colTenNguoiGiaoHang.Width = 81;
            // 
            // colMaSoThue
            // 
            this.colMaSoThue.Caption = "Mã số thuế";
            this.colMaSoThue.FieldName = "MaSoThue";
            this.colMaSoThue.Name = "colMaSoThue";
            this.colMaSoThue.Visible = true;
            this.colMaSoThue.VisibleIndex = 5;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 6;
            this.colGhiChu.Width = 195;
            // 
            // FrmNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 540);
            this.Controls.Add(this.customGridControl);
            this.Name = "FrmNCC";
            this.Text = "FrmNhaCungCap";
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
        private DevExpress.XtraGrid.Columns.GridColumn colMaNCC;
        private DevExpress.XtraGrid.Columns.GridColumn colTenCoSo;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colSDT;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNguoiGiaoHang;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSoThue;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
    }
}