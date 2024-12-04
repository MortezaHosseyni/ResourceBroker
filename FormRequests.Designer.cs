namespace ResourceBroker
{
    partial class FormRequests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRequests));
            dgv_Requests = new DataGridView();
            col_requests_Id = new DataGridViewTextBoxColumn();
            col_requests_User = new DataGridViewTextBoxColumn();
            col_requests_Status = new DataGridViewTextBoxColumn();
            col_requests_Resource = new DataGridViewTextBoxColumn();
            col_requests_CreatedAt = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_Requests).BeginInit();
            SuspendLayout();
            // 
            // dgv_Requests
            // 
            dgv_Requests.AllowUserToAddRows = false;
            dgv_Requests.AllowUserToDeleteRows = false;
            dgv_Requests.BackgroundColor = SystemColors.ControlLight;
            dgv_Requests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Requests.Columns.AddRange(new DataGridViewColumn[] { col_requests_Id, col_requests_User, col_requests_Status, col_requests_Resource, col_requests_CreatedAt });
            dgv_Requests.Dock = DockStyle.Fill;
            dgv_Requests.Location = new Point(0, 0);
            dgv_Requests.Name = "dgv_Requests";
            dgv_Requests.ReadOnly = true;
            dgv_Requests.Size = new Size(800, 450);
            dgv_Requests.TabIndex = 0;
            // 
            // col_requests_Id
            // 
            col_requests_Id.HeaderText = "Id";
            col_requests_Id.Name = "col_requests_Id";
            col_requests_Id.ReadOnly = true;
            col_requests_Id.Visible = false;
            // 
            // col_requests_User
            // 
            col_requests_User.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_requests_User.HeaderText = "User";
            col_requests_User.Name = "col_requests_User";
            col_requests_User.ReadOnly = true;
            // 
            // col_requests_Status
            // 
            col_requests_Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_requests_Status.HeaderText = "Status";
            col_requests_Status.Name = "col_requests_Status";
            col_requests_Status.ReadOnly = true;
            // 
            // col_requests_Resource
            // 
            col_requests_Resource.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_requests_Resource.HeaderText = "Resource";
            col_requests_Resource.Name = "col_requests_Resource";
            col_requests_Resource.ReadOnly = true;
            // 
            // col_requests_CreatedAt
            // 
            col_requests_CreatedAt.HeaderText = "Request Date";
            col_requests_CreatedAt.Name = "col_requests_CreatedAt";
            col_requests_CreatedAt.ReadOnly = true;
            // 
            // FormRequests
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_Requests);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormRequests";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Requests";
            WindowState = FormWindowState.Maximized;
            Load += FormRequests_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Requests).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_Requests;
        private DataGridViewTextBoxColumn col_requests_Id;
        private DataGridViewTextBoxColumn col_requests_User;
        private DataGridViewTextBoxColumn col_requests_Status;
        private DataGridViewTextBoxColumn col_requests_Resource;
        private DataGridViewTextBoxColumn col_requests_CreatedAt;
    }
}