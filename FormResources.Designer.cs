﻿namespace ResourceBroker
{
    partial class FormResources
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResources));
            dgv_Resources = new DataGridView();
            cms_ResourcesTable = new ContextMenuStrip(components);
            btn_EditResource = new ToolStripMenuItem();
            btn_DeleteResource = new ToolStripMenuItem();
            pnl_AddResource = new Panel();
            btn_AddResource = new Button();
            txt_Capacity = new TextBox();
            lbl_Capacity = new Label();
            txt_Count = new TextBox();
            lbl_Count = new Label();
            lbl_Type = new Label();
            cmb_ResourceType = new ComboBox();
            txt_Description = new TextBox();
            lbl_Description = new Label();
            txt_Name = new TextBox();
            lbl_Name = new Label();
            col_resources_Id = new DataGridViewTextBoxColumn();
            col_resources_Name = new DataGridViewTextBoxColumn();
            col_resources_Description = new DataGridViewTextBoxColumn();
            col_resources_Type = new DataGridViewTextBoxColumn();
            col_resources_Capacity = new DataGridViewTextBoxColumn();
            col_resources_CreatedAt = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_Resources).BeginInit();
            cms_ResourcesTable.SuspendLayout();
            pnl_AddResource.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_Resources
            // 
            dgv_Resources.AllowUserToAddRows = false;
            dgv_Resources.AllowUserToDeleteRows = false;
            dgv_Resources.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Resources.BackgroundColor = SystemColors.ControlLight;
            dgv_Resources.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Resources.Columns.AddRange(new DataGridViewColumn[] { col_resources_Id, col_resources_Name, col_resources_Description, col_resources_Type, col_resources_Capacity, col_resources_CreatedAt });
            dgv_Resources.ContextMenuStrip = cms_ResourcesTable;
            dgv_Resources.Location = new Point(14, 16);
            dgv_Resources.Margin = new Padding(3, 4, 3, 4);
            dgv_Resources.Name = "dgv_Resources";
            dgv_Resources.ReadOnly = true;
            dgv_Resources.RowHeadersWidth = 51;
            dgv_Resources.Size = new Size(887, 504);
            dgv_Resources.TabIndex = 0;
            // 
            // cms_ResourcesTable
            // 
            cms_ResourcesTable.ImageScalingSize = new Size(20, 20);
            cms_ResourcesTable.Items.AddRange(new ToolStripItem[] { btn_EditResource, btn_DeleteResource });
            cms_ResourcesTable.Name = "cms_ResourcesTable";
            cms_ResourcesTable.Size = new Size(123, 52);
            // 
            // btn_EditResource
            // 
            btn_EditResource.Name = "btn_EditResource";
            btn_EditResource.Size = new Size(122, 24);
            btn_EditResource.Text = "Edit";
            // 
            // btn_DeleteResource
            // 
            btn_DeleteResource.BackColor = Color.FromArgb(255, 192, 192);
            btn_DeleteResource.Name = "btn_DeleteResource";
            btn_DeleteResource.Size = new Size(122, 24);
            btn_DeleteResource.Text = "Delete";
            // 
            // pnl_AddResource
            // 
            pnl_AddResource.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_AddResource.Controls.Add(btn_AddResource);
            pnl_AddResource.Controls.Add(txt_Capacity);
            pnl_AddResource.Controls.Add(lbl_Capacity);
            pnl_AddResource.Controls.Add(txt_Count);
            pnl_AddResource.Controls.Add(lbl_Count);
            pnl_AddResource.Controls.Add(lbl_Type);
            pnl_AddResource.Controls.Add(cmb_ResourceType);
            pnl_AddResource.Controls.Add(txt_Description);
            pnl_AddResource.Controls.Add(lbl_Description);
            pnl_AddResource.Controls.Add(txt_Name);
            pnl_AddResource.Controls.Add(lbl_Name);
            pnl_AddResource.Location = new Point(14, 528);
            pnl_AddResource.Margin = new Padding(3, 4, 3, 4);
            pnl_AddResource.Name = "pnl_AddResource";
            pnl_AddResource.Size = new Size(887, 124);
            pnl_AddResource.TabIndex = 1;
            // 
            // btn_AddResource
            // 
            btn_AddResource.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btn_AddResource.Location = new Point(335, 47);
            btn_AddResource.Margin = new Padding(3, 4, 3, 4);
            btn_AddResource.Name = "btn_AddResource";
            btn_AddResource.Size = new Size(510, 68);
            btn_AddResource.TabIndex = 14;
            btn_AddResource.Text = "Add Resource";
            btn_AddResource.UseVisualStyleBackColor = true;
            btn_AddResource.Click += btn_AddResource_Click;
            // 
            // txt_Capacity
            // 
            txt_Capacity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txt_Capacity.Location = new Point(760, 8);
            txt_Capacity.Margin = new Padding(3, 4, 3, 4);
            txt_Capacity.Name = "txt_Capacity";
            txt_Capacity.Size = new Size(84, 27);
            txt_Capacity.TabIndex = 13;
            // 
            // lbl_Capacity
            // 
            lbl_Capacity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_Capacity.AutoSize = true;
            lbl_Capacity.Location = new Point(693, 12);
            lbl_Capacity.Name = "lbl_Capacity";
            lbl_Capacity.Size = new Size(66, 20);
            lbl_Capacity.TabIndex = 12;
            lbl_Capacity.Text = "Capacity";
            // 
            // txt_Count
            // 
            txt_Count.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txt_Count.Location = new Point(601, 8);
            txt_Count.Margin = new Padding(3, 4, 3, 4);
            txt_Count.Name = "txt_Count";
            txt_Count.Size = new Size(84, 27);
            txt_Count.TabIndex = 11;
            // 
            // lbl_Count
            // 
            lbl_Count.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_Count.AutoSize = true;
            lbl_Count.Location = new Point(549, 12);
            lbl_Count.Name = "lbl_Count";
            lbl_Count.Size = new Size(48, 20);
            lbl_Count.TabIndex = 10;
            lbl_Count.Text = "Count";
            // 
            // lbl_Type
            // 
            lbl_Type.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_Type.AutoSize = true;
            lbl_Type.Location = new Point(335, 12);
            lbl_Type.Name = "lbl_Type";
            lbl_Type.Size = new Size(40, 20);
            lbl_Type.TabIndex = 9;
            lbl_Type.Text = "Type";
            // 
            // cmb_ResourceType
            // 
            cmb_ResourceType.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            cmb_ResourceType.FormattingEnabled = true;
            cmb_ResourceType.Items.AddRange(new object[] { "Cpu", "Gpu", "Ram", "Ssd", "Hdd" });
            cmb_ResourceType.Location = new Point(377, 8);
            cmb_ResourceType.Margin = new Padding(3, 4, 3, 4);
            cmb_ResourceType.Name = "cmb_ResourceType";
            cmb_ResourceType.Size = new Size(158, 28);
            cmb_ResourceType.TabIndex = 8;
            // 
            // txt_Description
            // 
            txt_Description.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txt_Description.Location = new Point(117, 47);
            txt_Description.Margin = new Padding(3, 4, 3, 4);
            txt_Description.Multiline = true;
            txt_Description.Name = "txt_Description";
            txt_Description.Size = new Size(210, 67);
            txt_Description.TabIndex = 7;
            // 
            // lbl_Description
            // 
            lbl_Description.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_Description.AutoSize = true;
            lbl_Description.Location = new Point(33, 51);
            lbl_Description.Name = "lbl_Description";
            lbl_Description.Size = new Size(85, 20);
            lbl_Description.TabIndex = 6;
            lbl_Description.Text = "Description";
            // 
            // txt_Name
            // 
            txt_Name.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txt_Name.Location = new Point(117, 8);
            txt_Name.Margin = new Padding(3, 4, 3, 4);
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(210, 27);
            txt_Name.TabIndex = 5;
            // 
            // lbl_Name
            // 
            lbl_Name.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_Name.AutoSize = true;
            lbl_Name.Location = new Point(65, 12);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(49, 20);
            lbl_Name.TabIndex = 4;
            lbl_Name.Text = "Name";
            // 
            // col_resources_Id
            // 
            col_resources_Id.HeaderText = "Id";
            col_resources_Id.MinimumWidth = 6;
            col_resources_Id.Name = "col_resources_Id";
            col_resources_Id.ReadOnly = true;
            col_resources_Id.Visible = false;
            col_resources_Id.Width = 125;
            // 
            // col_resources_Name
            // 
            col_resources_Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_resources_Name.HeaderText = "Name";
            col_resources_Name.MinimumWidth = 6;
            col_resources_Name.Name = "col_resources_Name";
            col_resources_Name.ReadOnly = true;
            // 
            // col_resources_Description
            // 
            col_resources_Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_resources_Description.HeaderText = "Description";
            col_resources_Description.MinimumWidth = 6;
            col_resources_Description.Name = "col_resources_Description";
            col_resources_Description.ReadOnly = true;
            // 
            // col_resources_Type
            // 
            col_resources_Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_resources_Type.HeaderText = "Resource Type";
            col_resources_Type.MinimumWidth = 6;
            col_resources_Type.Name = "col_resources_Type";
            col_resources_Type.ReadOnly = true;
            // 
            // col_resources_Capacity
            // 
            col_resources_Capacity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_resources_Capacity.HeaderText = "Capacity";
            col_resources_Capacity.MinimumWidth = 6;
            col_resources_Capacity.Name = "col_resources_Capacity";
            col_resources_Capacity.ReadOnly = true;
            // 
            // col_resources_CreatedAt
            // 
            col_resources_CreatedAt.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_resources_CreatedAt.HeaderText = "Added Date";
            col_resources_CreatedAt.MinimumWidth = 6;
            col_resources_CreatedAt.Name = "col_resources_CreatedAt";
            col_resources_CreatedAt.ReadOnly = true;
            // 
            // FormResources
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 668);
            Controls.Add(pnl_AddResource);
            Controls.Add(dgv_Resources);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(930, 704);
            Name = "FormResources";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resources";
            Load += FormResources_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Resources).EndInit();
            cms_ResourcesTable.ResumeLayout(false);
            pnl_AddResource.ResumeLayout(false);
            pnl_AddResource.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_Resources;
        private Panel pnl_AddResource;
        private TextBox txt_Description;
        private Label lbl_Description;
        private TextBox txt_Name;
        private Label lbl_Name;
        private Label lbl_Type;
        private ComboBox cmb_ResourceType;
        private TextBox txt_Capacity;
        private Label lbl_Capacity;
        private TextBox txt_Count;
        private Label lbl_Count;
        private Button btn_AddResource;
        private ContextMenuStrip cms_ResourcesTable;
        private ToolStripMenuItem btn_EditResource;
        private ToolStripMenuItem btn_DeleteResource;
        private DataGridViewTextBoxColumn col_resources_Id;
        private DataGridViewTextBoxColumn col_resources_Name;
        private DataGridViewTextBoxColumn col_resources_Description;
        private DataGridViewTextBoxColumn col_resources_Type;
        private DataGridViewTextBoxColumn col_resources_Capacity;
        private DataGridViewTextBoxColumn col_resources_CreatedAt;
    }
}