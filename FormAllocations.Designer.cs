namespace ResourceBroker
{
    partial class FormAllocations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAllocations));
            dgv_Allocations = new DataGridView();
            col_allocations_Id = new DataGridViewTextBoxColumn();
            col_allocations_User = new DataGridViewTextBoxColumn();
            col_allocations_Resource = new DataGridViewTextBoxColumn();
            col_allocations_CreatedAt = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_Allocations).BeginInit();
            SuspendLayout();
            // 
            // dgv_Allocations
            // 
            dgv_Allocations.AllowUserToAddRows = false;
            dgv_Allocations.AllowUserToDeleteRows = false;
            dgv_Allocations.BackgroundColor = SystemColors.ControlLight;
            dgv_Allocations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Allocations.Columns.AddRange(new DataGridViewColumn[] { col_allocations_Id, col_allocations_User, col_allocations_Resource, col_allocations_CreatedAt });
            dgv_Allocations.Dock = DockStyle.Fill;
            dgv_Allocations.Location = new Point(0, 0);
            dgv_Allocations.Name = "dgv_Allocations";
            dgv_Allocations.ReadOnly = true;
            dgv_Allocations.Size = new Size(800, 450);
            dgv_Allocations.TabIndex = 0;
            // 
            // col_allocations_Id
            // 
            col_allocations_Id.HeaderText = "Id";
            col_allocations_Id.Name = "col_allocations_Id";
            col_allocations_Id.ReadOnly = true;
            col_allocations_Id.Visible = false;
            // 
            // col_allocations_User
            // 
            col_allocations_User.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_allocations_User.HeaderText = "User";
            col_allocations_User.Name = "col_allocations_User";
            col_allocations_User.ReadOnly = true;
            // 
            // col_allocations_Resource
            // 
            col_allocations_Resource.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_allocations_Resource.HeaderText = "Resource";
            col_allocations_Resource.Name = "col_allocations_Resource";
            col_allocations_Resource.ReadOnly = true;
            // 
            // col_allocations_CreatedAt
            // 
            col_allocations_CreatedAt.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_allocations_CreatedAt.HeaderText = "Allocation Date";
            col_allocations_CreatedAt.Name = "col_allocations_CreatedAt";
            col_allocations_CreatedAt.ReadOnly = true;
            // 
            // FormAllocations
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_Allocations);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAllocations";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Allocations";
            Load += FormAllocations_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Allocations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_Allocations;
        private DataGridViewTextBoxColumn col_allocations_Id;
        private DataGridViewTextBoxColumn col_allocations_User;
        private DataGridViewTextBoxColumn col_allocations_Resource;
        private DataGridViewTextBoxColumn col_allocations_CreatedAt;
    }
}