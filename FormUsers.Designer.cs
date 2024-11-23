namespace ResourceBroker
{
    partial class FormUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsers));
            dgv_Users = new DataGridView();
            cms_UsersTable = new ContextMenuStrip(components);
            btn_EditUser = new ToolStripMenuItem();
            btn_DeleteUser = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            btn_MakeRequest = new ToolStripMenuItem();
            pnl_RegisterUser = new Panel();
            btn_RegisterUser = new Button();
            lbl_Email = new Label();
            txt_Email = new TextBox();
            lbl_Phone = new Label();
            txt_Phone = new TextBox();
            lbl_LastName = new Label();
            txt_LastName = new TextBox();
            lbl_FirstName = new Label();
            txt_FirstName = new TextBox();
            col_users_Id = new DataGridViewTextBoxColumn();
            col_users_FirstName = new DataGridViewTextBoxColumn();
            col_users_LastName = new DataGridViewTextBoxColumn();
            col_users_Phone = new DataGridViewTextBoxColumn();
            col_users_Email = new DataGridViewTextBoxColumn();
            col_users_Requests = new DataGridViewTextBoxColumn();
            col_users_Allocates = new DataGridViewTextBoxColumn();
            col_users_CreatedAt = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_Users).BeginInit();
            cms_UsersTable.SuspendLayout();
            pnl_RegisterUser.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_Users
            // 
            dgv_Users.AllowUserToAddRows = false;
            dgv_Users.AllowUserToDeleteRows = false;
            dgv_Users.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Users.BackgroundColor = SystemColors.ControlLight;
            dgv_Users.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Users.Columns.AddRange(new DataGridViewColumn[] { col_users_Id, col_users_FirstName, col_users_LastName, col_users_Phone, col_users_Email, col_users_Requests, col_users_Allocates, col_users_CreatedAt });
            dgv_Users.ContextMenuStrip = cms_UsersTable;
            dgv_Users.Location = new Point(12, 12);
            dgv_Users.Name = "dgv_Users";
            dgv_Users.ReadOnly = true;
            dgv_Users.Size = new Size(864, 400);
            dgv_Users.TabIndex = 0;
            // 
            // cms_UsersTable
            // 
            cms_UsersTable.Items.AddRange(new ToolStripItem[] { btn_EditUser, btn_DeleteUser, toolStripMenuItem1, btn_MakeRequest });
            cms_UsersTable.Name = "cms_UsersTable";
            cms_UsersTable.Size = new Size(155, 76);
            // 
            // btn_EditUser
            // 
            btn_EditUser.Name = "btn_EditUser";
            btn_EditUser.Size = new Size(154, 22);
            btn_EditUser.Text = "Edit";
            // 
            // btn_DeleteUser
            // 
            btn_DeleteUser.BackColor = Color.FromArgb(255, 192, 192);
            btn_DeleteUser.Name = "btn_DeleteUser";
            btn_DeleteUser.Size = new Size(154, 22);
            btn_DeleteUser.Text = "Delete";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(151, 6);
            // 
            // btn_MakeRequest
            // 
            btn_MakeRequest.Name = "btn_MakeRequest";
            btn_MakeRequest.Size = new Size(154, 22);
            btn_MakeRequest.Text = "Make a request";
            btn_MakeRequest.Click += btn_MakeRequest_Click;
            // 
            // pnl_RegisterUser
            // 
            pnl_RegisterUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_RegisterUser.Controls.Add(btn_RegisterUser);
            pnl_RegisterUser.Controls.Add(lbl_Email);
            pnl_RegisterUser.Controls.Add(txt_Email);
            pnl_RegisterUser.Controls.Add(lbl_Phone);
            pnl_RegisterUser.Controls.Add(txt_Phone);
            pnl_RegisterUser.Controls.Add(lbl_LastName);
            pnl_RegisterUser.Controls.Add(txt_LastName);
            pnl_RegisterUser.Controls.Add(lbl_FirstName);
            pnl_RegisterUser.Controls.Add(txt_FirstName);
            pnl_RegisterUser.Location = new Point(12, 418);
            pnl_RegisterUser.Name = "pnl_RegisterUser";
            pnl_RegisterUser.Size = new Size(864, 134);
            pnl_RegisterUser.TabIndex = 1;
            // 
            // btn_RegisterUser
            // 
            btn_RegisterUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btn_RegisterUser.Location = new Point(142, 74);
            btn_RegisterUser.Name = "btn_RegisterUser";
            btn_RegisterUser.Size = new Size(527, 43);
            btn_RegisterUser.TabIndex = 8;
            btn_RegisterUser.Text = "Register User";
            btn_RegisterUser.UseVisualStyleBackColor = true;
            btn_RegisterUser.Click += btn_RegisterUser_Click;
            // 
            // lbl_Email
            // 
            lbl_Email.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_Email.AutoSize = true;
            lbl_Email.Location = new Point(438, 48);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(36, 15);
            lbl_Email.TabIndex = 7;
            lbl_Email.Text = "Email";
            // 
            // txt_Email
            // 
            txt_Email.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txt_Email.Location = new Point(480, 45);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(189, 23);
            txt_Email.TabIndex = 6;
            // 
            // lbl_Phone
            // 
            lbl_Phone.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_Phone.AutoSize = true;
            lbl_Phone.Location = new Point(432, 19);
            lbl_Phone.Name = "lbl_Phone";
            lbl_Phone.Size = new Size(41, 15);
            lbl_Phone.TabIndex = 5;
            lbl_Phone.Text = "Phone";
            // 
            // txt_Phone
            // 
            txt_Phone.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txt_Phone.Location = new Point(480, 16);
            txt_Phone.Name = "txt_Phone";
            txt_Phone.Size = new Size(189, 23);
            txt_Phone.TabIndex = 4;
            // 
            // lbl_LastName
            // 
            lbl_LastName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_LastName.AutoSize = true;
            lbl_LastName.Location = new Point(142, 48);
            lbl_LastName.Name = "lbl_LastName";
            lbl_LastName.Size = new Size(63, 15);
            lbl_LastName.TabIndex = 3;
            lbl_LastName.Text = "Last Name";
            // 
            // txt_LastName
            // 
            txt_LastName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txt_LastName.Location = new Point(212, 45);
            txt_LastName.Name = "txt_LastName";
            txt_LastName.Size = new Size(189, 23);
            txt_LastName.TabIndex = 2;
            // 
            // lbl_FirstName
            // 
            lbl_FirstName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_FirstName.AutoSize = true;
            lbl_FirstName.Location = new Point(142, 19);
            lbl_FirstName.Name = "lbl_FirstName";
            lbl_FirstName.Size = new Size(64, 15);
            lbl_FirstName.TabIndex = 1;
            lbl_FirstName.Text = "First Name";
            // 
            // txt_FirstName
            // 
            txt_FirstName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txt_FirstName.Location = new Point(212, 16);
            txt_FirstName.Name = "txt_FirstName";
            txt_FirstName.Size = new Size(189, 23);
            txt_FirstName.TabIndex = 0;
            // 
            // col_users_Id
            // 
            col_users_Id.HeaderText = "Id";
            col_users_Id.Name = "col_users_Id";
            col_users_Id.ReadOnly = true;
            col_users_Id.Visible = false;
            // 
            // col_users_FirstName
            // 
            col_users_FirstName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_users_FirstName.HeaderText = "First Name";
            col_users_FirstName.Name = "col_users_FirstName";
            col_users_FirstName.ReadOnly = true;
            // 
            // col_users_LastName
            // 
            col_users_LastName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_users_LastName.HeaderText = "Last Name";
            col_users_LastName.Name = "col_users_LastName";
            col_users_LastName.ReadOnly = true;
            // 
            // col_users_Phone
            // 
            col_users_Phone.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_users_Phone.HeaderText = "Phone";
            col_users_Phone.Name = "col_users_Phone";
            col_users_Phone.ReadOnly = true;
            // 
            // col_users_Email
            // 
            col_users_Email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_users_Email.HeaderText = "Email";
            col_users_Email.Name = "col_users_Email";
            col_users_Email.ReadOnly = true;
            // 
            // col_users_Requests
            // 
            col_users_Requests.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_users_Requests.HeaderText = "Requests";
            col_users_Requests.Name = "col_users_Requests";
            col_users_Requests.ReadOnly = true;
            // 
            // col_users_Allocates
            // 
            col_users_Allocates.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_users_Allocates.HeaderText = "Allocations";
            col_users_Allocates.Name = "col_users_Allocates";
            col_users_Allocates.ReadOnly = true;
            // 
            // col_users_CreatedAt
            // 
            col_users_CreatedAt.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_users_CreatedAt.HeaderText = "Registered Date";
            col_users_CreatedAt.Name = "col_users_CreatedAt";
            col_users_CreatedAt.ReadOnly = true;
            // 
            // FormUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 564);
            Controls.Add(pnl_RegisterUser);
            Controls.Add(dgv_Users);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(904, 603);
            Name = "FormUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Users";
            Load += FormUsers_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Users).EndInit();
            cms_UsersTable.ResumeLayout(false);
            pnl_RegisterUser.ResumeLayout(false);
            pnl_RegisterUser.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_Users;
        private Panel pnl_RegisterUser;
        private Label lbl_FirstName;
        private TextBox txt_FirstName;
        private Label lbl_LastName;
        private TextBox txt_LastName;
        private Label lbl_Phone;
        private TextBox txt_Phone;
        private Label lbl_Email;
        private TextBox txt_Email;
        private Button btn_RegisterUser;
        private ContextMenuStrip cms_UsersTable;
        private ToolStripMenuItem btn_EditUser;
        private ToolStripMenuItem btn_DeleteUser;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem btn_MakeRequest;
        private DataGridViewTextBoxColumn col_users_Id;
        private DataGridViewTextBoxColumn col_users_FirstName;
        private DataGridViewTextBoxColumn col_users_LastName;
        private DataGridViewTextBoxColumn col_users_Phone;
        private DataGridViewTextBoxColumn col_users_Email;
        private DataGridViewTextBoxColumn col_users_Requests;
        private DataGridViewTextBoxColumn col_users_Allocates;
        private DataGridViewTextBoxColumn col_users_CreatedAt;
    }
}