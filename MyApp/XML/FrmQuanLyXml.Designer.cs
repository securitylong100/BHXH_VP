namespace XML130.XML
{
    partial class FrmQuanLyXml
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuanLyXml));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions4 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions5 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions6 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            this.pnlButtons = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtMaLK = new DevExpress.XtraEditors.TextEdit();
            this.cboXmlTypes = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lbLogs = new DevExpress.XtraEditors.ListBoxControl();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.linkLogin = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.tcXmls = new DevExpress.XtraBars.Navigation.TabPane();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboXmlTypes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcXmls)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.ButtonInterval = 50;
            windowsUIButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions1.SvgImage")));
            windowsUIButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions2.SvgImage")));
            windowsUIButtonImageOptions3.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions3.SvgImage")));
            windowsUIButtonImageOptions4.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions4.SvgImage")));
            windowsUIButtonImageOptions5.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions5.SvgImage")));
            windowsUIButtonImageOptions6.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions6.SvgImage")));
            this.pnlButtons.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Mở thư mục", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Lưu tất cả tệp Xml trong thư mục vào CSDL", -1, true, null, true, false, true, "cmdImportFolder", -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Mở tệp", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Đọc dữ liệu tệp Xml vào giao diện", -1, true, null, true, false, true, "cmdOpenXmlFile", -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Kiểm tra", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Kiểm tra lỗi dữ liệu các tệp Xml đang mở", -1, true, null, true, false, true, "cmdCheckXml", -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Lưu vào CSDL", true, windowsUIButtonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Lưu thay đổi vào CSDL", -1, true, null, true, false, true, "cmdSaveDb", -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Xuất Xml", true, windowsUIButtonImageOptions5, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Xuất dữ liệu hiện tại ra tệp Xml", -1, true, null, true, false, true, "cmdExportXml", -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUISeparator(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Gửi API", true, windowsUIButtonImageOptions6, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Gửi tệp Xml vừa xuất đến API của BHXH", -1, true, null, true, false, true, "cmdSendApi", -1, false)});
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 508);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(958, 92);
            this.pnlButtons.TabIndex = 0;
            this.pnlButtons.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.pnlButtons_ButtonClick);
            // 
            // layoutControl1
            // 
            this.tablePanel1.SetColumn(this.layoutControl1, 0);
            this.layoutControl1.Controls.Add(this.txtMaLK);
            this.layoutControl1.Controls.Add(this.cboXmlTypes);
            this.layoutControl1.Location = new System.Drawing.Point(3, 29);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1108, 0, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.tablePanel1.SetRow(this.layoutControl1, 1);
            this.layoutControl1.Size = new System.Drawing.Size(952, 94);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtMaLK
            // 
            this.txtMaLK.Location = new System.Drawing.Point(17, 42);
            this.txtMaLK.Name = "txtMaLK";
            this.txtMaLK.Size = new System.Drawing.Size(452, 22);
            this.txtMaLK.StyleController = this.layoutControl1;
            this.txtMaLK.TabIndex = 4;
            this.txtMaLK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaLK_KeyDown);
            // 
            // cboXmlTypes
            // 
            this.cboXmlTypes.Location = new System.Drawing.Point(483, 42);
            this.cboXmlTypes.Name = "cboXmlTypes";
            this.cboXmlTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboXmlTypes.Properties.ValidateOnEnterKey = true;
            this.cboXmlTypes.Size = new System.Drawing.Size(452, 22);
            this.cboXmlTypes.StyleController = this.layoutControl1;
            this.cboXmlTypes.TabIndex = 5;
            this.cboXmlTypes.SelectedIndexChanged += new System.EventHandler(this.cboXmlTypes_SelectedIndexChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition1.Width = 50D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition2.Width = 50D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2});
            rowDefinition1.Height = 100D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1});
            this.Root.Size = new System.Drawing.Size(952, 94);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.BestFitWeight = 50;
            this.layoutControlItem1.Control = this.txtMaLK;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(466, 74);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Text = "Mã lượt khám";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cboXmlTypes;
            this.layoutControlItem2.Location = new System.Drawing.Point(466, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(466, 74);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.Text = "Loại hồ sơ";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // lbLogs
            // 
            this.lbLogs.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.tablePanel1.SetColumn(this.lbLogs, 0);
            this.lbLogs.Location = new System.Drawing.Point(3, 411);
            this.lbLogs.Name = "lbLogs";
            this.tablePanel1.SetRow(this.lbLogs, 3);
            this.lbLogs.Size = new System.Drawing.Size(952, 94);
            this.lbLogs.TabIndex = 0;
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
            this.tablePanel1.Controls.Add(this.linkLogin);
            this.tablePanel1.Controls.Add(this.lbLogs);
            this.tablePanel1.Controls.Add(this.tcXmls);
            this.tablePanel1.Controls.Add(this.layoutControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F)});
            this.tablePanel1.Size = new System.Drawing.Size(958, 508);
            this.tablePanel1.TabIndex = 1;
            // 
            // linkLogin
            // 
            this.tablePanel1.SetColumn(this.linkLogin, 0);
            this.linkLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLogin.Location = new System.Drawing.Point(3, 3);
            this.linkLogin.Name = "linkLogin";
            this.tablePanel1.SetRow(this.linkLogin, 0);
            this.linkLogin.Size = new System.Drawing.Size(952, 20);
            this.linkLogin.TabIndex = 0;
            this.linkLogin.Text = "Đăng nhập API";
            this.linkLogin.Click += new System.EventHandler(this.linkLogin_Click);
            // 
            // tcXmls
            // 
            this.tcXmls.AllowHtmlDraw = true;
            this.tcXmls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tablePanel1.SetColumn(this.tcXmls, 0);
            this.tcXmls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcXmls.Location = new System.Drawing.Point(3, 129);
            this.tcXmls.Name = "tcXmls";
            this.tcXmls.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.Text;
            this.tcXmls.RegularSize = new System.Drawing.Size(952, 276);
            this.tablePanel1.SetRow(this.tcXmls, 2);
            this.tcXmls.SelectedPage = null;
            this.tcXmls.Size = new System.Drawing.Size(952, 276);
            this.tcXmls.TabIndex = 1;
            this.tcXmls.Text = "tabPane1";
            // 
            // FrmQuanLyXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 600);
            this.Controls.Add(this.tablePanel1);
            this.Controls.Add(this.pnlButtons);
            this.Name = "FrmQuanLyXml";
            this.Text = "FrmQuanLyXml";
            this.Load += new System.EventHandler(this.FrmQuanLyXml_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboXmlTypes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcXmls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel pnlButtons;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.ListBoxControl lbLogs;
        private DevExpress.XtraBars.Navigation.TabPane tcXmls;
        private DevExpress.XtraEditors.TextEdit txtMaLK;
        private DevExpress.XtraEditors.ComboBoxEdit cboXmlTypes;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.HyperlinkLabelControl linkLogin;
    }
}