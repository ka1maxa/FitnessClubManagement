using System;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessClubManagement.Forms
{
    partial class TrainerForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTrainerName;
        private DataGridView dgvMembers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            // ===== Label =====
            lblTrainerName = new Label();
            lblTrainerName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTrainerName.ForeColor = Color.White;
            lblTrainerName.Top = 20;
            lblTrainerName.Left = 20;
            lblTrainerName.AutoSize = true;

            // ===== DataGridView =====
            dgvMembers = new DataGridView();
            dgvMembers.Top = 60;
            dgvMembers.Left = 20;
            dgvMembers.Width = 740;
            dgvMembers.Height = 400;
            dgvMembers.BackgroundColor = Color.FromArgb(28, 28, 28);
            dgvMembers.ForeColor = Color.White;
            dgvMembers.DefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            dgvMembers.DefaultCellStyle.ForeColor = Color.White;
            dgvMembers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
            dgvMembers.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMembers.EnableHeadersVisualStyles = false;
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.RowHeadersVisible = false;
            dgvMembers.ReadOnly = true;

            // ===== Form =====
            this.ClientSize = new Size(800, 480);
            this.BackColor = Color.FromArgb(18, 18, 18);
            this.Controls.Add(lblTrainerName);
            this.Controls.Add(dgvMembers);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Trainer Dashboard";

            this.ResumeLayout(false);
        }
    }
}
