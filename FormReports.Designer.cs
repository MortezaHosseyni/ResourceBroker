namespace ResourceBroker
{
    partial class FormReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReports));
            btn_Comparison = new Button();
            btn_GwoCurve = new Button();
            btn_GwoEfficiency = new Button();
            btn_AutomatonCurve = new Button();
            btn_AutomatonEfficiency = new Button();
            SuspendLayout();
            // 
            // btn_Comparison
            // 
            btn_Comparison.Location = new Point(12, 12);
            btn_Comparison.Name = "btn_Comparison";
            btn_Comparison.Size = new Size(325, 49);
            btn_Comparison.TabIndex = 0;
            btn_Comparison.Text = "GWO and Automaton Comparison Chart";
            btn_Comparison.UseVisualStyleBackColor = true;
            btn_Comparison.Click += btn_Comparison_Click;
            // 
            // btn_GwoCurve
            // 
            btn_GwoCurve.Location = new Point(12, 185);
            btn_GwoCurve.Name = "btn_GwoCurve";
            btn_GwoCurve.Size = new Size(325, 49);
            btn_GwoCurve.TabIndex = 1;
            btn_GwoCurve.Text = "GWO Convergence Curve";
            btn_GwoCurve.UseVisualStyleBackColor = true;
            btn_GwoCurve.Click += btn_GwoCurve_Click;
            // 
            // btn_GwoEfficiency
            // 
            btn_GwoEfficiency.Location = new Point(12, 240);
            btn_GwoEfficiency.Name = "btn_GwoEfficiency";
            btn_GwoEfficiency.Size = new Size(325, 49);
            btn_GwoEfficiency.TabIndex = 3;
            btn_GwoEfficiency.Text = "GWO Resource Utilization Efficiency\r\n";
            btn_GwoEfficiency.UseVisualStyleBackColor = true;
            btn_GwoEfficiency.Click += btn_GwoEfficiency_Click;
            // 
            // btn_AutomatonCurve
            // 
            btn_AutomatonCurve.Location = new Point(12, 398);
            btn_AutomatonCurve.Name = "btn_AutomatonCurve";
            btn_AutomatonCurve.Size = new Size(325, 49);
            btn_AutomatonCurve.TabIndex = 4;
            btn_AutomatonCurve.Text = "Automaton Convergence Curve";
            btn_AutomatonCurve.UseVisualStyleBackColor = true;
            btn_AutomatonCurve.Click += btn_AutomatonCurve_Click;
            // 
            // btn_AutomatonEfficiency
            // 
            btn_AutomatonEfficiency.Location = new Point(12, 453);
            btn_AutomatonEfficiency.Name = "btn_AutomatonEfficiency";
            btn_AutomatonEfficiency.Size = new Size(325, 49);
            btn_AutomatonEfficiency.TabIndex = 5;
            btn_AutomatonEfficiency.Text = "Automaton Resource Utilization Efficiency";
            btn_AutomatonEfficiency.UseVisualStyleBackColor = true;
            btn_AutomatonEfficiency.Click += btn_AutomatonEfficiency_Click;
            // 
            // FormReports
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 514);
            Controls.Add(btn_AutomatonEfficiency);
            Controls.Add(btn_AutomatonCurve);
            Controls.Add(btn_GwoEfficiency);
            Controls.Add(btn_GwoCurve);
            Controls.Add(btn_Comparison);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormReports";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reports";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Comparison;
        private Button btn_GwoCurve;
        private Button btn_GwoEfficiency;
        private Button btn_AutomatonCurve;
        private Button btn_AutomatonEfficiency;
    }
}