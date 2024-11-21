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
            ((System.ComponentModel.ISupportInitialize)dgv_Allocations).BeginInit();
            SuspendLayout();
            // 
            // dgv_Allocations
            // 
            dgv_Allocations.AllowUserToAddRows = false;
            dgv_Allocations.AllowUserToDeleteRows = false;
            dgv_Allocations.BackgroundColor = SystemColors.ControlLight;
            dgv_Allocations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Allocations.Dock = DockStyle.Fill;
            dgv_Allocations.Location = new Point(0, 0);
            dgv_Allocations.Name = "dgv_Allocations";
            dgv_Allocations.ReadOnly = true;
            dgv_Allocations.Size = new Size(800, 450);
            dgv_Allocations.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)dgv_Allocations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_Allocations;
    }
}