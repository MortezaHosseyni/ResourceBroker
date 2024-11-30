namespace ResourceBroker
{
    partial class FormPackages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPackages));
            lsv_PackagesList = new ListView();
            SuspendLayout();
            // 
            // lsv_PackagesList
            // 
            lsv_PackagesList.Dock = DockStyle.Fill;
            lsv_PackagesList.Font = new Font("Segoe UI", 18F);
            lsv_PackagesList.Location = new Point(0, 0);
            lsv_PackagesList.MultiSelect = false;
            lsv_PackagesList.Name = "lsv_PackagesList";
            lsv_PackagesList.Size = new Size(893, 542);
            lsv_PackagesList.TabIndex = 0;
            lsv_PackagesList.UseCompatibleStateImageBehavior = false;
            lsv_PackagesList.MouseDoubleClick += lsv_PackagesList_MouseDoubleClick;
            // 
            // FormPackages
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 542);
            Controls.Add(lsv_PackagesList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(909, 581);
            Name = "FormPackages";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Packages";
            WindowState = FormWindowState.Maximized;
            Load += FormPackages_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView lsv_PackagesList;
    }
}