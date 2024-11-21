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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            rtb_MainLogs = new RichTextBox();
            btn_Users = new Button();
            btn_Services = new Button();
            btn_Allocate = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // rtb_MainLogs
            // 
            rtb_MainLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtb_MainLogs.Location = new Point(430, 12);
            rtb_MainLogs.Name = "rtb_MainLogs";
            rtb_MainLogs.Size = new Size(444, 559);
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
            btn_Services.UseVisualStyleBackColor = true;
            btn_Services.Click += btn_Services_Click;
            // 
            // btn_Allocate
            // 
            btn_Allocate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_Allocate.Location = new Point(12, 507);
            btn_Allocate.Name = "btn_Allocate";
            btn_Allocate.Size = new Size(412, 64);
            btn_Allocate.TabIndex = 3;
            btn_Allocate.Text = "Allocate";
            btn_Allocate.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(12, 166);
            button1.Name = "button1";
            button1.Size = new Size(412, 44);
            button1.TabIndex = 4;
            button1.Text = "Make Requests";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(12, 216);
            button2.Name = "button2";
            button2.Size = new Size(412, 44);
            button2.TabIndex = 5;
            button2.Text = "Packages";
            button2.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 583);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btn_Allocate);
            Controls.Add(btn_Services);
            Controls.Add(btn_Users);
            Controls.Add(rtb_MainLogs);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(902, 622);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resource Broker";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtb_MainLogs;
        private Button btn_Users;
        private Button btn_Services;
        private Button btn_Allocate;
        private Button button1;
        private Button button2;
    }
}
