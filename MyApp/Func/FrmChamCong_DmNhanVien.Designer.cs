
namespace XML130.Func
{
    partial class FrmChamCong_DmNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChamCong_DmNhanVien));
            this.customGridControl = new XML130.CustomGridLookUpEdit.CustomGridControl();
            this.customGridView = new XML130.CustomGridLookUpEdit.CustomGridView();
            this.colMaNv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhoaPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChucVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColGioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQueQuan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChiHT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCCCD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDanToc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuocTich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTKNganHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayLamViec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserEnrollNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserEnrollName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserCardNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMatMa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiQuyen = new DevExpress.XtraGrid.Columns.GridColumn();
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete)});
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
            this.btnExport.ImageOptions.Image = global::XML130.Properties.Resources.excel_24;
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
            // barEditItemTime
            // 
            this.barEditItemTime.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // repositoryItemFrom
            // 
            // 
            // barEditItemFrom
            // 
            this.barEditItemFrom.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // repositoryItemTo
            // 
            // 
            // barEditItemTo
            // 
            this.barEditItemTo.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnSearch
            // 
            this.btnSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSearch.ImageOptions.SvgImage")));
            this.btnSearch.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            // 
            // customGridControl
            // 
            this.customGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridControl.Location = new System.Drawing.Point(0, 54);
            this.customGridControl.MainView = this.customGridView;
            this.customGridControl.MenuManager = this.barManager;
            this.customGridControl.Name = "customGridControl";
            this.customGridControl.Size = new System.Drawing.Size(1362, 589);
            this.customGridControl.TabIndex = 4;
            this.customGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.customGridView});
            this.customGridControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.customGridControl_MouseDoubleClick);
            // 
            // customGridView
            // 
            this.customGridView.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.customGridView.Appearance.Row.Options.UseFont = true;
            this.customGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaNv,
            this.colTenNv,
            this.colTrangThai,
            this.colKhoaPhong,
            this.colChucVu,
            this.ColGioiTinh,
            this.ColNgaySinh,
            this.colQueQuan,
            this.colDiaChiHT,
            this.colCCCD,
            this.colNoiCap,
            this.colNgayCap,
            this.colDanToc,
            this.colQuocTich,
            this.colSDT,
            this.colSoTKNganHang,
            this.colNgayLamViec,
            this.colUserEnrollNumber,
            this.colUserEnrollName,
            this.colUserCardNo,
            this.colMatMa,
            this.colLoaiQuyen});
            this.customGridView.GridControl = this.customGridControl;
            this.customGridView.Name = "customGridView";
            this.customGridView.OptionsView.ShowGroupPanel = false;
            this.customGridView.RowHeight = 27;
            // 
            // colMaNv
            // 
            this.colMaNv.Caption = "Mã";
            this.colMaNv.FieldName = "MaNv";
            this.colMaNv.Name = "colMaNv";
            this.colMaNv.Visible = true;
            this.colMaNv.VisibleIndex = 0;
            this.colMaNv.Width = 45;
            // 
            // colTenNv
            // 
            this.colTenNv.Caption = "Tên nhân viên";
            this.colTenNv.FieldName = "TenNv";
            this.colTenNv.Name = "colTenNv";
            this.colTenNv.Visible = true;
            this.colTenNv.VisibleIndex = 1;
            this.colTenNv.Width = 115;
            // 
            // colTrangThai
            // 
            this.colTrangThai.Caption = "Danh sách";
            this.colTrangThai.FieldName = "TrangThaiText";
            this.colTrangThai.Name = "colTrangThai";
            // 
            // colKhoaPhong
            // 
            this.colKhoaPhong.Caption = "Khoa phòng";
            this.colKhoaPhong.FieldName = "TenKhoaPhong";
            this.colKhoaPhong.Name = "colKhoaPhong";
            this.colKhoaPhong.Visible = true;
            this.colKhoaPhong.VisibleIndex = 3;
            this.colKhoaPhong.Width = 145;
            // 
            // colChucVu
            // 
            this.colChucVu.Caption = "Chức vụ";
            this.colChucVu.FieldName = "ChucVu";
            this.colChucVu.Name = "colChucVu";
            this.colChucVu.Visible = true;
            this.colChucVu.VisibleIndex = 4;
            this.colChucVu.Width = 64;
            // 
            // ColGioiTinh
            // 
            this.ColGioiTinh.Caption = "Giới tính";
            this.ColGioiTinh.FieldName = "GioiTinh";
            this.ColGioiTinh.Name = "ColGioiTinh";
            this.ColGioiTinh.Visible = true;
            this.ColGioiTinh.VisibleIndex = 5;
            this.ColGioiTinh.Width = 64;
            // 
            // ColNgaySinh
            // 
            this.ColNgaySinh.Caption = "Ngày sinh";
            this.ColNgaySinh.FieldName = "NgaySinh";
            this.ColNgaySinh.Name = "ColNgaySinh";
            this.ColNgaySinh.Visible = true;
            this.ColNgaySinh.VisibleIndex = 6;
            this.ColNgaySinh.Width = 64;
            // 
            // colQueQuan
            // 
            this.colQueQuan.Caption = "Quê quán";
            this.colQueQuan.FieldName = "QueQuan";
            this.colQueQuan.Name = "colQueQuan";
            this.colQueQuan.Visible = true;
            this.colQueQuan.VisibleIndex = 7;
            this.colQueQuan.Width = 64;
            // 
            // colDiaChiHT
            // 
            this.colDiaChiHT.Caption = "Địa chỉ hiện tại";
            this.colDiaChiHT.FieldName = "DiaChiHT";
            this.colDiaChiHT.Name = "colDiaChiHT";
            this.colDiaChiHT.Visible = true;
            this.colDiaChiHT.VisibleIndex = 8;
            this.colDiaChiHT.Width = 64;
            // 
            // colCCCD
            // 
            this.colCCCD.Caption = "Số CCCD/CMT";
            this.colCCCD.FieldName = "CCCD";
            this.colCCCD.Name = "colCCCD";
            this.colCCCD.Visible = true;
            this.colCCCD.VisibleIndex = 9;
            this.colCCCD.Width = 64;
            // 
            // colNoiCap
            // 
            this.colNoiCap.Caption = "Nơi cấp";
            this.colNoiCap.FieldName = "NoiCap";
            this.colNoiCap.Name = "colNoiCap";
            this.colNoiCap.Visible = true;
            this.colNoiCap.VisibleIndex = 10;
            this.colNoiCap.Width = 64;
            // 
            // colNgayCap
            // 
            this.colNgayCap.Caption = "Ngày cấp";
            this.colNgayCap.FieldName = "NgayCap";
            this.colNgayCap.Name = "colNgayCap";
            this.colNgayCap.Visible = true;
            this.colNgayCap.VisibleIndex = 11;
            this.colNgayCap.Width = 64;
            // 
            // colDanToc
            // 
            this.colDanToc.Caption = "Dân tộc";
            this.colDanToc.FieldName = "DanToc";
            this.colDanToc.Name = "colDanToc";
            this.colDanToc.Visible = true;
            this.colDanToc.VisibleIndex = 12;
            this.colDanToc.Width = 64;
            // 
            // colQuocTich
            // 
            this.colQuocTich.Caption = "Quốc tịch";
            this.colQuocTich.FieldName = "QuocTich";
            this.colQuocTich.Name = "colQuocTich";
            this.colQuocTich.Visible = true;
            this.colQuocTich.VisibleIndex = 13;
            this.colQuocTich.Width = 64;
            // 
            // colSDT
            // 
            this.colSDT.Caption = "Điện thoại liên lạc";
            this.colSDT.FieldName = "SDT";
            this.colSDT.Name = "colSDT";
            this.colSDT.Visible = true;
            this.colSDT.VisibleIndex = 2;
            this.colSDT.Width = 50;
            // 
            // colSoTKNganHang
            // 
            this.colSoTKNganHang.Caption = "Số TK Ngân hàng";
            this.colSoTKNganHang.FieldName = "SoTKNganHang";
            this.colSoTKNganHang.Name = "colSoTKNganHang";
            this.colSoTKNganHang.Visible = true;
            this.colSoTKNganHang.VisibleIndex = 14;
            this.colSoTKNganHang.Width = 64;
            // 
            // colNgayLamViec
            // 
            this.colNgayLamViec.Caption = "Ngày vào làm việc";
            this.colNgayLamViec.FieldName = "NgayLamViec";
            this.colNgayLamViec.Name = "colNgayLamViec";
            this.colNgayLamViec.Visible = true;
            this.colNgayLamViec.VisibleIndex = 15;
            this.colNgayLamViec.Width = 64;
            // 
            // colUserEnrollNumber
            // 
            this.colUserEnrollNumber.Caption = "Mã chấm công";
            this.colUserEnrollNumber.FieldName = "UserEnrollNumber";
            this.colUserEnrollNumber.Name = "colUserEnrollNumber";
            this.colUserEnrollNumber.Visible = true;
            this.colUserEnrollNumber.VisibleIndex = 16;
            this.colUserEnrollNumber.Width = 64;
            // 
            // colUserEnrollName
            // 
            this.colUserEnrollName.Caption = "Tên chấm công";
            this.colUserEnrollName.FieldName = "UserEnrollName";
            this.colUserEnrollName.Name = "colUserEnrollName";
            this.colUserEnrollName.Visible = true;
            this.colUserEnrollName.VisibleIndex = 17;
            this.colUserEnrollName.Width = 64;
            // 
            // colUserCardNo
            // 
            this.colUserCardNo.Caption = "Mã thẻ";
            this.colUserCardNo.FieldName = "UserCardNo";
            this.colUserCardNo.Name = "colUserCardNo";
            this.colUserCardNo.Visible = true;
            this.colUserCardNo.VisibleIndex = 18;
            this.colUserCardNo.Width = 93;
            // 
            // colMatMa
            // 
            this.colMatMa.Caption = "Mật mã";
            this.colMatMa.FieldName = "MatMa";
            this.colMatMa.Name = "colMatMa";
            this.colMatMa.Visible = true;
            this.colMatMa.VisibleIndex = 19;
            // 
            // colLoaiQuyen
            // 
            this.colLoaiQuyen.Caption = "Loại quyền";
            this.colLoaiQuyen.FieldName = "LoaiQuyen";
            this.colLoaiQuyen.Name = "colLoaiQuyen";
            this.colLoaiQuyen.Visible = true;
            this.colLoaiQuyen.VisibleIndex = 20;
            // 
            // FrmChamCong_DmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 643);
            this.Controls.Add(this.customGridControl);
            this.Name = "FrmChamCong_DmNhanVien";
            this.Text = "FrmChamCong_DmNhanVien";
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
        private DevExpress.XtraGrid.Columns.GridColumn colMaNv;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNv;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn colSDT;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoaPhong;
        private DevExpress.XtraGrid.Columns.GridColumn colChucVu;
        private DevExpress.XtraGrid.Columns.GridColumn ColGioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn ColNgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn colQueQuan;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChiHT;
        private DevExpress.XtraGrid.Columns.GridColumn colCCCD;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiCap;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayCap;
        private DevExpress.XtraGrid.Columns.GridColumn colDanToc;
        private DevExpress.XtraGrid.Columns.GridColumn colQuocTich;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTKNganHang;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayLamViec;
        private DevExpress.XtraGrid.Columns.GridColumn colUserEnrollNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colUserEnrollName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserCardNo;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiQuyen;
        private DevExpress.XtraGrid.Columns.GridColumn colMatMa;
    }
}