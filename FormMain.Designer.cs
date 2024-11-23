namespace ResourceBroker
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            rtb_MainLogs = new RichTextBox();
            btn_Users = new Button();
            btn_Services = new Button();
            btn_Allocate = new Button();
            btn_Packages = new Button();
            btn_Requests = new Button();
            btn_Allocations = new Button();
            sts_BottomStatus = new StatusStrip();
            tlt_Hints = new ToolTip(components);
            SuspendLayout();
            // 
            // rtb_MainLogs
            // 
            rtb_MainLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtb_MainLogs.Location = new Point(430, 12);
            rtb_MainLogs.Name = "rtb_MainLogs";
            rtb_MainLogs.ReadOnly = true;
            rtb_MainLogs.Size = new Size(444, 546);
            rtb_MainLogs.TabIndex = 0;
            rtb_MainLogs.Text = "";
            // 
            // btn_Users
            // 
            btn_Users.Location = new Point(12, 12);
            btn_Users.Name = "btn_Users";
            btn_Users.Size = new Size(412, 44);
            btn_Users.TabIndex = 1;
            btn_Users.Text = "Users";
            tlt_Hints.SetToolTip(btn_Users, "* Users list\r\n* Register / Edit / Delete User\r\n* Make request for a User");
            btn_Users.UseVisualStyleBackColor = true;
            btn_Users.Click += btn_Users_Click;
            // 
            // btn_Services
            // 
            btn_Services.Location = new Point(12, 62);
            btn_Services.Name = "btn_Services";
            btn_Services.Size = new Size(412, 44);
            btn_Services.TabIndex = 2;
            btn_Services.Text = "Services";
            tlt_Hints.SetToolTip(btn_Services, "* Services list\r\n* Add / Edit / Delete Service\r\n* Service resources");
            btn_Services.UseVisualStyleBackColor = true;
            btn_Services.Click += btn_Services_Click;
            // 
            // btn_Allocate
            // 
            btn_Allocate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_Allocate.Location = new Point(12, 494);
            btn_Allocate.Name = "btn_Allocate";
            btn_Allocate.Size = new Size(412, 64);
            btn_Allocate.TabIndex = 3;
            btn_Allocate.Text = "Allocate";
            tlt_Hints.SetToolTip(btn_Allocate, "Start allocation process");
            btn_Allocate.UseVisualStyleBackColor = true;
            // 
            // btn_Packages
            // 
            btn_Packages.Anchor = AnchorStyles.Left;
            btn_Packages.Location = new Point(12, 330);
            btn_Packages.Name = "btn_Packages";
            btn_Packages.Size = new Size(412, 44);
            btn_Packages.TabIndex = 5;
            btn_Packages.Text = "Packages";
            tlt_Hints.SetToolTip(btn_Packages, "Ready-made packages");
            btn_Packages.UseVisualStyleBackColor = true;
            // 
            // btn_Requests
            // 
            btn_Requests.Anchor = AnchorStyles.Left;
            btn_Requests.Location = new Point(12, 230);
            btn_Requests.Name = "btn_Requests";
            btn_Requests.Size = new Size(412, 44);
            btn_Requests.TabIndex = 6;
            btn_Requests.Text = "Requests";
            tlt_Hints.SetToolTip(btn_Requests, "Users requests");
            btn_Requests.UseVisualStyleBackColor = true;
            btn_Requests.Click += btn_Requests_Click;
            // 
            // btn_Allocations
            // 
            btn_Allocations.Anchor = AnchorStyles.Left;
            btn_Allocations.Location = new Point(12, 280);
            btn_Allocations.Name = "btn_Allocations";
            btn_Allocations.Size = new Size(412, 44);
            btn_Allocations.TabIndex = 7;
            btn_Allocations.Text = "Allocations";
            tlt_Hints.SetToolTip(btn_Allocations, "Requests allocations");
            btn_Allocations.UseVisualStyleBackColor = true;
            btn_Allocations.Click += btn_Allocations_Click;
            // 
            // sts_BottomStatus
            // 
            sts_BottomStatus.Location = new Point(0, 561);
            sts_BottomStatus.Name = "sts_BottomStatus";
            sts_BottomStatus.Size = new Size(886, 22);
            sts_BottomStatus.TabIndex = 8;
            sts_BottomStatus.Text = "statusStrip1";
            // 
            // tlt_Hints
            // 
            tlt_Hints.AutoPopDelay = 10000;
            tlt_Hints.InitialDelay = 500;
            tlt_Hints.ReshowDelay = 100;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 583);
            Controls.Add(sts_BottomStatus);
            Controls.Add(btn_Allocations);
            Controls.Add(btn_Requests);
            Controls.Add(btn_Packages);
            Controls.Add(btn_Allocate);
            Controls.Add(btn_Services);
            Controls.Add(btn_Users);
            Controls.Add(rtb_MainLogs);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(902, 622);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resource Broker";
            Load += FormMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtb_MainLogs;
        private Button btn_Users;
        private Button btn_Services;
        private Button btn_Allocate;
        private Button btn_;
        private Button btn_Packages;
        private Button btn_Requests;
        private Button btn_Allocations;
        private StatusStrip sts_BottomStatus;
        private ToolTip tlt_Hints;
    }
}
