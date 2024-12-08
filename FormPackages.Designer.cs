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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPackages));
            lsv_PackagesList = new ListView();
            btn_AddPackageGwo = new Button();
            tlt_Tooltip = new ToolTip(components);
            btn_AddPackageAutomaton = new Button();
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
            // btn_AddPackageGwo
            // 
            btn_AddPackageGwo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_AddPackageGwo.BackColor = Color.Gray;
            btn_AddPackageGwo.ForeColor = Color.White;
            btn_AddPackageGwo.Location = new Point(819, 424);
            btn_AddPackageGwo.Name = "btn_AddPackageGwo";
            btn_AddPackageGwo.Size = new Size(62, 50);
            btn_AddPackageGwo.TabIndex = 1;
            btn_AddPackageGwo.Text = "➕";
            tlt_Tooltip.SetToolTip(btn_AddPackageGwo, "Create package using Gray Wolf Optimization algorithm");
            btn_AddPackageGwo.UseVisualStyleBackColor = false;
            btn_AddPackageGwo.Click += btn_AddPackageGwo_Click;
            // 
            // btn_AddPackageAutomaton
            // 
            btn_AddPackageAutomaton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_AddPackageAutomaton.BackColor = Color.Green;
            btn_AddPackageAutomaton.ForeColor = Color.White;
            btn_AddPackageAutomaton.Location = new Point(819, 480);
            btn_AddPackageAutomaton.Name = "btn_AddPackageAutomaton";
            btn_AddPackageAutomaton.Size = new Size(62, 50);
            btn_AddPackageAutomaton.TabIndex = 2;
            btn_AddPackageAutomaton.Text = "➕";
            tlt_Tooltip.SetToolTip(btn_AddPackageAutomaton, "Create package using Learning Automaton algorithm.");
            btn_AddPackageAutomaton.UseVisualStyleBackColor = false;
            btn_AddPackageAutomaton.Click += btn_AddPackageAutomaton_Click;
            // 
            // FormPackages
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 542);
            Controls.Add(btn_AddPackageAutomaton);
            Controls.Add(btn_AddPackageGwo);
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
        private Button btn_AddPackageGwo;
        private ToolTip tlt_Tooltip;
        private Button btn_AddPackageAutomaton;
    }
}