namespace ResourceBroker
{
    partial class FormServices
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServices));
            dgv_Services = new DataGridView();
            col_services_Id = new DataGridViewTextBoxColumn();
            col_services_Name = new DataGridViewTextBoxColumn();
            col_services_Description = new DataGridViewTextBoxColumn();
            col_services_Download = new DataGridViewTextBoxColumn();
            col_services_Upload = new DataGridViewTextBoxColumn();
            col_services_Bandwidth = new DataGridViewTextBoxColumn();
            col_services_CreatedAt = new DataGridViewTextBoxColumn();
            pnl_AddService = new Panel();
            btn_AddService = new Button();
            txt_Bandwidth = new TextBox();
            lbl_Bandwidth = new Label();
            txt_Upload = new TextBox();
            lbl_Upload = new Label();
            txt_Download = new TextBox();
            lbl_Download = new Label();
            txt_Description = new TextBox();
            lbl_Description = new Label();
            txt_Name = new TextBox();
            lbl_Name = new Label();
            cms_ServicesTable = new ContextMenuStrip(components);
            btn_EditService = new ToolStripMenuItem();
            btn_DeleteService = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            btn_ServiceResources = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgv_Services).BeginInit();
            pnl_AddService.SuspendLayout();
            cms_ServicesTable.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_Services
            // 
            dgv_Services.AllowUserToAddRows = false;
            dgv_Services.AllowUserToDeleteRows = false;
            dgv_Services.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Services.BackgroundColor = SystemColors.ControlLight;
            dgv_Services.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Services.Columns.AddRange(new DataGridViewColumn[] { col_services_Id, col_services_Name, col_services_Description, col_services_Download, col_services_Upload, col_services_Bandwidth, col_services_CreatedAt });
            dgv_Services.ContextMenuStrip = cms_ServicesTable;
            dgv_Services.Location = new Point(12, 12);
            dgv_Services.Name = "dgv_Services";
            dgv_Services.ReadOnly = true;
            dgv_Services.Size = new Size(847, 387);
            dgv_Services.TabIndex = 0;
            // 
            // col_services_Id
            // 
            col_services_Id.HeaderText = "Id";
            col_services_Id.Name = "col_services_Id";
            col_services_Id.ReadOnly = true;
            col_services_Id.Visible = false;
            // 
            // col_services_Name
            // 
            col_services_Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_services_Name.HeaderText = "Name";
            col_services_Name.Name = "col_services_Name";
            col_services_Name.ReadOnly = true;
            // 
            // col_services_Description
            // 
            col_services_Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_services_Description.HeaderText = "Description";
            col_services_Description.Name = "col_services_Description";
            col_services_Description.ReadOnly = true;
            // 
            // col_services_Download
            // 
            col_services_Download.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_services_Download.HeaderText = "Download";
            col_services_Download.Name = "col_services_Download";
            col_services_Download.ReadOnly = true;
            // 
            // col_services_Upload
            // 
            col_services_Upload.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_services_Upload.HeaderText = "Upload";
            col_services_Upload.Name = "col_services_Upload";
            col_services_Upload.ReadOnly = true;
            // 
            // col_services_Bandwidth
            // 
            col_services_Bandwidth.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_services_Bandwidth.HeaderText = "Bandwidth";
            col_services_Bandwidth.Name = "col_services_Bandwidth";
            col_services_Bandwidth.ReadOnly = true;
            // 
            // col_services_CreatedAt
            // 
            col_services_CreatedAt.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_services_CreatedAt.HeaderText = "Added Date";
            col_services_CreatedAt.Name = "col_services_CreatedAt";
            col_services_CreatedAt.ReadOnly = true;
            // 
            // pnl_AddService
            // 
            pnl_AddService.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_AddService.Controls.Add(btn_AddService);
            pnl_AddService.Controls.Add(txt_Bandwidth);
            pnl_AddService.Controls.Add(lbl_Bandwidth);
            pnl_AddService.Controls.Add(txt_Upload);
            pnl_AddService.Controls.Add(lbl_Upload);
            pnl_AddService.Controls.Add(txt_Download);
            pnl_AddService.Controls.Add(lbl_Download);
            pnl_AddService.Controls.Add(txt_Description);
            pnl_AddService.Controls.Add(lbl_Description);
            pnl_AddService.Controls.Add(txt_Name);
            pnl_AddService.Controls.Add(lbl_Name);
            pnl_AddService.Location = new Point(12, 405);
            pnl_AddService.Name = "pnl_AddService";
            pnl_AddService.Size = new Size(847, 95);
            pnl_AddService.TabIndex = 1;
            // 
            // btn_AddService
            // 
            btn_AddService.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btn_AddService.Location = new Point(323, 37);
            btn_AddService.Name = "btn_AddService";
            btn_AddService.Size = new Size(422, 48);
            btn_AddService.TabIndex = 10;
            btn_AddService.Text = "Add Service";
            btn_AddService.UseVisualStyleBackColor = true;
            // 
            // txt_Bandwidth
            // 
            txt_Bandwidth.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txt_Bandwidth.Location = new Point(671, 8);
            txt_Bandwidth.Name = "txt_Bandwidth";
            txt_Bandwidth.Size = new Size(74, 23);
            txt_Bandwidth.TabIndex = 9;
            // 
            // lbl_Bandwidth
            // 
            lbl_Bandwidth.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_Bandwidth.AutoSize = true;
            lbl_Bandwidth.Location = new Point(601, 11);
            lbl_Bandwidth.Name = "lbl_Bandwidth";
            lbl_Bandwidth.Size = new Size(64, 15);
            lbl_Bandwidth.TabIndex = 8;
            lbl_Bandwidth.Text = "Bandwidth";
            // 
            // txt_Upload
            // 
            txt_Upload.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txt_Upload.Location = new Point(521, 8);
            txt_Upload.Name = "txt_Upload";
            txt_Upload.Size = new Size(74, 23);
            txt_Upload.TabIndex = 7;
            // 
            // lbl_Upload
            // 
            lbl_Upload.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_Upload.AutoSize = true;
            lbl_Upload.Location = new Point(470, 11);
            lbl_Upload.Name = "lbl_Upload";
            lbl_Upload.Size = new Size(45, 15);
            lbl_Upload.TabIndex = 6;
            lbl_Upload.Text = "Upload";
            // 
            // txt_Download
            // 
            txt_Download.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txt_Download.Location = new Point(390, 8);
            txt_Download.Name = "txt_Download";
            txt_Download.Size = new Size(74, 23);
            txt_Download.TabIndex = 5;
            // 
            // lbl_Download
            // 
            lbl_Download.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_Download.AutoSize = true;
            lbl_Download.Location = new Point(323, 11);
            lbl_Download.Name = "lbl_Download";
            lbl_Download.Size = new Size(61, 15);
            lbl_Download.TabIndex = 4;
            lbl_Download.Text = "Download";
            // 
            // txt_Description
            // 
            txt_Description.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txt_Description.Location = new Point(128, 34);
            txt_Description.Multiline = true;
            txt_Description.Name = "txt_Description";
            txt_Description.Size = new Size(184, 51);
            txt_Description.TabIndex = 3;
            // 
            // lbl_Description
            // 
            lbl_Description.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_Description.AutoSize = true;
            lbl_Description.Location = new Point(55, 37);
            lbl_Description.Name = "lbl_Description";
            lbl_Description.Size = new Size(67, 15);
            lbl_Description.TabIndex = 2;
            lbl_Description.Text = "Description";
            // 
            // txt_Name
            // 
            txt_Name.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txt_Name.Location = new Point(128, 5);
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(184, 23);
            txt_Name.TabIndex = 1;
            // 
            // lbl_Name
            // 
            lbl_Name.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_Name.AutoSize = true;
            lbl_Name.Location = new Point(83, 8);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(39, 15);
            lbl_Name.TabIndex = 0;
            lbl_Name.Text = "Name";
            // 
            // cms_ServicesTable
            // 
            cms_ServicesTable.Items.AddRange(new ToolStripItem[] { btn_EditService, btn_DeleteService, toolStripMenuItem1, btn_ServiceResources });
            cms_ServicesTable.Name = "cms_ServicesTable";
            cms_ServicesTable.Size = new Size(128, 76);
            // 
            // btn_EditService
            // 
            btn_EditService.Name = "btn_EditService";
            btn_EditService.Size = new Size(127, 22);
            btn_EditService.Text = "Edit";
            // 
            // btn_DeleteService
            // 
            btn_DeleteService.BackColor = Color.FromArgb(255, 192, 192);
            btn_DeleteService.Name = "btn_DeleteService";
            btn_DeleteService.Size = new Size(127, 22);
            btn_DeleteService.Text = "Delete";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(124, 6);
            // 
            // btn_ServiceResources
            // 
            btn_ServiceResources.Name = "btn_ServiceResources";
            btn_ServiceResources.Size = new Size(127, 22);
            btn_ServiceResources.Text = "Resources";
            btn_ServiceResources.Click += btn_ServiceResources_Click;
            // 
            // FormServices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(871, 512);
            Controls.Add(pnl_AddService);
            Controls.Add(dgv_Services);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(887, 551);
            Name = "FormServices";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Services";
            ((System.ComponentModel.ISupportInitialize)dgv_Services).EndInit();
            pnl_AddService.ResumeLayout(false);
            pnl_AddService.PerformLayout();
            cms_ServicesTable.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_Services;
        private Panel pnl_AddService;
        private Label lbl_Name;
        private TextBox txt_Name;
        private TextBox txt_Description;
        private Label lbl_Description;
        private TextBox txt_Download;
        private Label lbl_Download;
        private TextBox txt_Upload;
        private Label lbl_Upload;
        private TextBox txt_Bandwidth;
        private Label lbl_Bandwidth;
        private Button btn_AddService;
        private ContextMenuStrip cms_ServicesTable;
        private ToolStripMenuItem btn_EditService;
        private ToolStripMenuItem btn_DeleteService;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem btn_ServiceResources;
        private DataGridViewTextBoxColumn col_services_Id;
        private DataGridViewTextBoxColumn col_services_Name;
        private DataGridViewTextBoxColumn col_services_Description;
        private DataGridViewTextBoxColumn col_services_Download;
        private DataGridViewTextBoxColumn col_services_Upload;
        private DataGridViewTextBoxColumn col_services_Bandwidth;
        private DataGridViewTextBoxColumn col_services_CreatedAt;
    }
}