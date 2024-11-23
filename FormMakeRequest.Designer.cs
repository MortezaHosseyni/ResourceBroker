namespace ResourceBroker
{
    partial class FormMakeRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMakeRequest));
            lbl_Cpu = new Label();
            lbl_Gpu = new Label();
            lbl_Ram = new Label();
            lbl_Ssd = new Label();
            lbl_Hdd = new Label();
            cmb_Cpu = new ComboBox();
            cmb_Gpu = new ComboBox();
            cmb_Ram = new ComboBox();
            cmb_Ssd = new ComboBox();
            cmb_Hdd = new ComboBox();
            btn_Request = new Button();
            SuspendLayout();
            // 
            // lbl_Cpu
            // 
            lbl_Cpu.AutoSize = true;
            lbl_Cpu.Location = new Point(89, 38);
            lbl_Cpu.Name = "lbl_Cpu";
            lbl_Cpu.Size = new Size(30, 15);
            lbl_Cpu.TabIndex = 0;
            lbl_Cpu.Text = "CPU";
            // 
            // lbl_Gpu
            // 
            lbl_Gpu.AutoSize = true;
            lbl_Gpu.Location = new Point(89, 67);
            lbl_Gpu.Name = "lbl_Gpu";
            lbl_Gpu.Size = new Size(30, 15);
            lbl_Gpu.TabIndex = 1;
            lbl_Gpu.Text = "GPU";
            // 
            // lbl_Ram
            // 
            lbl_Ram.AutoSize = true;
            lbl_Ram.Location = new Point(86, 96);
            lbl_Ram.Name = "lbl_Ram";
            lbl_Ram.Size = new Size(33, 15);
            lbl_Ram.TabIndex = 2;
            lbl_Ram.Text = "RAM";
            // 
            // lbl_Ssd
            // 
            lbl_Ssd.AutoSize = true;
            lbl_Ssd.Location = new Point(92, 125);
            lbl_Ssd.Name = "lbl_Ssd";
            lbl_Ssd.Size = new Size(27, 15);
            lbl_Ssd.TabIndex = 3;
            lbl_Ssd.Text = "SSD";
            // 
            // lbl_Hdd
            // 
            lbl_Hdd.AutoSize = true;
            lbl_Hdd.Location = new Point(87, 154);
            lbl_Hdd.Name = "lbl_Hdd";
            lbl_Hdd.Size = new Size(32, 15);
            lbl_Hdd.TabIndex = 4;
            lbl_Hdd.Text = "HDD";
            // 
            // cmb_Cpu
            // 
            cmb_Cpu.FormattingEnabled = true;
            cmb_Cpu.Location = new Point(125, 35);
            cmb_Cpu.Name = "cmb_Cpu";
            cmb_Cpu.Size = new Size(319, 23);
            cmb_Cpu.TabIndex = 5;
            // 
            // cmb_Gpu
            // 
            cmb_Gpu.FormattingEnabled = true;
            cmb_Gpu.Location = new Point(125, 64);
            cmb_Gpu.Name = "cmb_Gpu";
            cmb_Gpu.Size = new Size(319, 23);
            cmb_Gpu.TabIndex = 6;
            // 
            // cmb_Ram
            // 
            cmb_Ram.FormattingEnabled = true;
            cmb_Ram.Location = new Point(125, 93);
            cmb_Ram.Name = "cmb_Ram";
            cmb_Ram.Size = new Size(319, 23);
            cmb_Ram.TabIndex = 7;
            // 
            // cmb_Ssd
            // 
            cmb_Ssd.FormattingEnabled = true;
            cmb_Ssd.Location = new Point(125, 122);
            cmb_Ssd.Name = "cmb_Ssd";
            cmb_Ssd.Size = new Size(319, 23);
            cmb_Ssd.TabIndex = 8;
            // 
            // cmb_Hdd
            // 
            cmb_Hdd.FormattingEnabled = true;
            cmb_Hdd.Location = new Point(125, 151);
            cmb_Hdd.Name = "cmb_Hdd";
            cmb_Hdd.Size = new Size(319, 23);
            cmb_Hdd.TabIndex = 9;
            // 
            // btn_Request
            // 
            btn_Request.Location = new Point(48, 252);
            btn_Request.Name = "btn_Request";
            btn_Request.Size = new Size(449, 38);
            btn_Request.TabIndex = 10;
            btn_Request.Text = "Request";
            btn_Request.UseVisualStyleBackColor = true;
            btn_Request.Click += btn_Request_Click;
            // 
            // FormMakeRequest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 333);
            Controls.Add(btn_Request);
            Controls.Add(cmb_Hdd);
            Controls.Add(cmb_Ssd);
            Controls.Add(cmb_Ram);
            Controls.Add(cmb_Gpu);
            Controls.Add(cmb_Cpu);
            Controls.Add(lbl_Hdd);
            Controls.Add(lbl_Ssd);
            Controls.Add(lbl_Ram);
            Controls.Add(lbl_Gpu);
            Controls.Add(lbl_Cpu);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMakeRequest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Make Request";
            Load += FormMakeRequest_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Cpu;
        private Label lbl_Gpu;
        private Label lbl_Ram;
        private Label lbl_Ssd;
        private Label lbl_Hdd;
        private ComboBox cmb_Cpu;
        private ComboBox cmb_Gpu;
        private ComboBox cmb_Ram;
        private ComboBox cmb_Ssd;
        private ComboBox cmb_Hdd;
        private Button btn_Request;
    }
}