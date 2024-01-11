
namespace XML130
{
    partial class FrmThietLapKetNoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThietLapKetNoi));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.cbbXacThuc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCSDL = new DevExpress.XtraEditors.TextEdit();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.txtTenDangNhap = new DevExpress.XtraEditors.TextEdit();
            this.txtMayChu = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnKetNoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbXacThuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCSDL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMayChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.cbbXacThuc);
            this.layoutControl.Controls.Add(this.txtCSDL);
            this.layoutControl.Controls.Add(this.txtMatKhau);
            this.layoutControl.Controls.Add(this.txtTenDangNhap);
            this.layoutControl.Controls.Add(this.txtMayChu);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(356, 121);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // cbbXacThuc
            // 
            this.cbbXacThuc.Location = new System.Drawing.Point(77, 26);
            this.cbbXacThuc.Name = "cbbXacThuc";
            this.cbbXacThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbXacThuc.Properties.Items.AddRange(new object[] {
            "Quyền Window",
            "Quyền SQL Server"});
            this.cbbXacThuc.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbbXacThuc.Size = new System.Drawing.Size(277, 20);
            this.cbbXacThuc.StyleController = this.layoutControl;
            this.cbbXacThuc.TabIndex = 8;
            this.cbbXacThuc.SelectedIndexChanged += new System.EventHandler(this.cbbXacThuc_SelectedIndexChanged);
            // 
            // txtCSDL
            // 
            this.txtCSDL.Location = new System.Drawing.Point(77, 98);
            this.txtCSDL.Name = "txtCSDL";
            this.txtCSDL.Size = new System.Drawing.Size(277, 20);
            this.txtCSDL.StyleController = this.layoutControl;
            this.txtCSDL.TabIndex = 7;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(77, 74);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Properties.UseSystemPasswordChar = true;
            this.txtMatKhau.Size = new System.Drawing.Size(277, 20);
            this.txtMatKhau.StyleController = this.layoutControl;
            this.txtMatKhau.TabIndex = 6;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(77, 50);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(277, 20);
            this.txtTenDangNhap.StyleController = this.layoutControl;
            this.txtTenDangNhap.TabIndex = 5;
            // 
            // txtMayChu
            // 
            this.txtMayChu.Location = new System.Drawing.Point(77, 2);
            this.txtMayChu.Name = "txtMayChu";
            this.txtMayChu.Size = new System.Drawing.Size(277, 20);
            this.txtMayChu.StyleController = this.layoutControl;
            this.txtMayChu.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(356, 121);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMayChu;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(356, 24);
            this.layoutControlItem1.Text = "Máy chủ";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTenDangNhap;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(356, 24);
            this.layoutControlItem2.Text = "Tên đăng nhập";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtMatKhau;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(356, 24);
            this.layoutControlItem3.Text = "Mật khẩu";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtCSDL;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(356, 25);
            this.layoutControlItem4.Text = "Tên CSDL";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cbbXacThuc;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(356, 24);
            this.layoutControlItem5.Text = "Xác thực với";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(72, 13);
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnKetNoi.Appearance.Options.UseFont = true;
            this.btnKetNoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnKetNoi.ImageOptions.SvgImage")));
            this.btnKetNoi.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnKetNoi.Location = new System.Drawing.Point(40, 129);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(90, 34);
            this.btnKetNoi.TabIndex = 2;
            this.btnKetNoi.Text = "&Kết nối";
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Location = new System.Drawing.Point(136, 129);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(90, 34);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDong.Appearance.Options.UseFont = true;
            this.btnDong.Location = new System.Drawing.Point(232, 129);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(90, 34);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "&Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmThietLapKetNoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 175);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnKetNoi);
            this.Controls.Add(this.layoutControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmThietLapKetNoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmThietLapKetNoi";
            this.Load += new System.EventHandler(this.FrmThietLapKetNoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbbXacThuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCSDL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMayChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.ComboBoxEdit cbbXacThuc;
        private DevExpress.XtraEditors.TextEdit txtCSDL;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraEditors.TextEdit txtTenDangNhap;
        private DevExpress.XtraEditors.TextEdit txtMayChu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnKetNoi;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnDong;
    }
}