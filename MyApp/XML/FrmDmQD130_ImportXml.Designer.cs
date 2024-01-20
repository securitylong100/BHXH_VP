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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gc_data = new XML130.CustomGridLookUpEdit.CustomGridControl();
            this.gv_data = new XML130.CustomGridLookUpEdit.CustomGridView();
            this.btnCheckDB = new System.Windows.Forms.Button();
            this.btnSaveDB = new System.Windows.Forms.Button();
            this.btnExportAPI = new System.Windows.Forms.Button();
            this.btnSendAPI = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnLoadDB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtXmlType = new System.Windows.Forms.TextBox();
            this.txtMaLK = new System.Windows.Forms.TextBox();
            this.lvLogs = new System.Windows.Forms.ListView();
            this.colLogTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLogMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvLogs);
            this.splitContainer1.Size = new System.Drawing.Size(1160, 639);
            this.splitContainer1.SplitterDistance = 478;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.gc_data, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCheckDB, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveDB, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExportAPI, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSendAPI, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnImport, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLoadDB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtXmlType, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMaLK, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1160, 478);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // gc_data
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gc_data, 6);
            this.gc_data.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.gc_data.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gc_data.Location = new System.Drawing.Point(4, 71);
            this.gc_data.MainView = this.gv_data;
            this.gc_data.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gc_data.Name = "gc_data";
            this.gc_data.Size = new System.Drawing.Size(1152, 403);
            this.gc_data.TabIndex = 11;
            this.gc_data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_data});
            // 
            // gv_data
            // 
            this.gv_data.DetailHeight = 431;
            this.gv_data.GridControl = this.gc_data;
            this.gv_data.Name = "gv_data";
            this.gv_data.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gv_data.OptionsEditForm.ActionOnModifiedRowChange = DevExpress.XtraGrid.Views.Grid.EditFormModifiedAction.Save;
            this.gv_data.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.gv_data.OptionsView.ColumnAutoWidth = false;
            // 
            // btnCheckDB
            // 
            this.btnCheckDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheckDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckDB.Location = new System.Drawing.Point(390, 2);
            this.btnCheckDB.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCheckDB.Name = "btnCheckDB";
            this.btnCheckDB.Size = new System.Drawing.Size(185, 36);
            this.btnCheckDB.TabIndex = 1;
            this.btnCheckDB.Text = "Check DB";
            this.btnCheckDB.UseVisualStyleBackColor = true;
            this.btnCheckDB.Click += new System.EventHandler(this.btnCheckDB_Click);
            // 
            // btnSaveDB
            // 
            this.btnSaveDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDB.Location = new System.Drawing.Point(583, 2);
            this.btnSaveDB.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSaveDB.Name = "btnSaveDB";
            this.btnSaveDB.Size = new System.Drawing.Size(185, 36);
            this.btnSaveDB.TabIndex = 2;
            this.btnSaveDB.Text = "Save to DB";
            this.btnSaveDB.UseVisualStyleBackColor = true;
            this.btnSaveDB.Click += new System.EventHandler(this.btnSaveDB_Click);
            // 
            // btnExportAPI
            // 
            this.btnExportAPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportAPI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportAPI.Location = new System.Drawing.Point(776, 2);
            this.btnExportAPI.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnExportAPI.Name = "btnExportAPI";
            this.btnExportAPI.Size = new System.Drawing.Size(185, 36);
            this.btnExportAPI.TabIndex = 3;
            this.btnExportAPI.Text = "Export API";
            this.btnExportAPI.UseVisualStyleBackColor = true;
            this.btnExportAPI.Click += new System.EventHandler(this.btnExportAPI_Click);
            // 
            // btnSendAPI
            // 
            this.btnSendAPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSendAPI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendAPI.Location = new System.Drawing.Point(969, 2);
            this.btnSendAPI.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSendAPI.Name = "btnSendAPI";
            this.btnSendAPI.Size = new System.Drawing.Size(187, 36);
            this.btnSendAPI.TabIndex = 4;
            this.btnSendAPI.Text = "Send API";
            this.btnSendAPI.UseVisualStyleBackColor = true;
            this.btnSendAPI.Click += new System.EventHandler(this.btnSendAPI_Click);
            // 
            // btnImport
            // 
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(4, 2);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(185, 36);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "Import Xml";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnLoadDB
            // 
            this.btnLoadDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDB.Location = new System.Drawing.Point(197, 2);
            this.btnLoadDB.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnLoadDB.Name = "btnLoadDB";
            this.btnLoadDB.Size = new System.Drawing.Size(185, 36);
            this.btnLoadDB.TabIndex = 6;
            this.btnLoadDB.Text = "Load DB";
            this.btnLoadDB.UseVisualStyleBackColor = true;
            this.btnLoadDB.Click += new System.EventHandler(this.btnLoadDB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(197, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "XML Table";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(583, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 27);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mã liên kết (MA_LK)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtXmlType
            // 
            this.txtXmlType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXmlType.Location = new System.Drawing.Point(390, 42);
            this.txtXmlType.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtXmlType.Name = "txtXmlType";
            this.txtXmlType.Size = new System.Drawing.Size(185, 23);
            this.txtXmlType.TabIndex = 9;
            // 
            // txtMaLK
            // 
            this.txtMaLK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaLK.Location = new System.Drawing.Point(776, 42);
            this.txtMaLK.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtMaLK.Name = "txtMaLK";
            this.txtMaLK.Size = new System.Drawing.Size(185, 23);
            this.txtMaLK.TabIndex = 10;
            // 
            // lvLogs
            // 
            this.lvLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLogTime,
            this.colLogMessage});
            this.lvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLogs.FullRowSelect = true;
            this.lvLogs.GridLines = true;
            this.lvLogs.HideSelection = false;
            this.lvLogs.Location = new System.Drawing.Point(0, 0);
            this.lvLogs.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lvLogs.Name = "lvLogs";
            this.lvLogs.ShowGroups = false;
            this.lvLogs.Size = new System.Drawing.Size(1160, 157);
            this.lvLogs.TabIndex = 0;
            this.lvLogs.UseCompatibleStateImageBehavior = false;
            this.lvLogs.View = System.Windows.Forms.View.Details;
            // 
            // colLogTime
            // 
            this.colLogTime.Text = "Time";
            this.colLogTime.Width = 100;
            // 
            // colLogMessage
            // 
            this.colLogMessage.Text = "Message";
            this.colLogMessage.Width = 200;
            // 
            // FrmDmQD130_ImportXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 639);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmDmQD130_ImportXml";
            this.Text = "FrmDmQD130_ImportXml";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCheckDB;
        private System.Windows.Forms.Button btnSaveDB;
        private System.Windows.Forms.Button btnExportAPI;
        private System.Windows.Forms.Button btnSendAPI;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnLoadDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtXmlType;
        private System.Windows.Forms.TextBox txtMaLK;
        private System.Windows.Forms.ListView lvLogs;
        private System.Windows.Forms.ColumnHeader colLogTime;
        private System.Windows.Forms.ColumnHeader colLogMessage;
        private CustomGridLookUpEdit.CustomGridControl gc_data;
        private CustomGridLookUpEdit.CustomGridView gv_data;
    }
}