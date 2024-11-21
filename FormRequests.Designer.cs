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
            ((System.ComponentModel.ISupportInitialize)dgv_Requests).BeginInit();
            SuspendLayout();
            // 
            // dgv_Requests
            // 
            dgv_Requests.AllowUserToAddRows = false;
            dgv_Requests.AllowUserToDeleteRows = false;
            dgv_Requests.BackgroundColor = SystemColors.ControlLight;
            dgv_Requests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Requests.Dock = DockStyle.Fill;
            dgv_Requests.Location = new Point(0, 0);
            dgv_Requests.Name = "dgv_Requests";
            dgv_Requests.ReadOnly = true;
            dgv_Requests.Size = new Size(800, 450);
            dgv_Requests.TabIndex = 0;
            // 
            // FormRequests
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_Requests);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormRequests";
            Text = "Requests";
            ((System.ComponentModel.ISupportInitialize)dgv_Requests).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_Requests;
    }
}