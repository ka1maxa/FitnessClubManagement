namespace FitnessClubManagement.Forms
{
    partial class ManagerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvExpired;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvExpired = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpired)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvExpired
            // 
            this.dgvExpired.AllowUserToAddRows = false;
            this.dgvExpired.AllowUserToDeleteRows = false;
            this.dgvExpired.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpired.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExpired.ReadOnly = true;
            this.dgvExpired.Name = "dgvExpired";
            // 
            // ManagerForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvExpired);
            this.Name = "ManagerForm";
            this.Text = "Manager Dashboard";
            this.Load += new System.EventHandler(this.ManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpired)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
