using System;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessClubManagement.Forms
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        internal DataGridView dgvMembers;
        internal Button btnAddMember;
        internal Button btnEdit;
        internal Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvMembers = new DataGridView();
            this.btnAddMember = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();

            this.SuspendLayout();

            // ===== DataGridView =====
            this.dgvMembers.Dock = DockStyle.Top;
            this.dgvMembers.Height = 400;
            this.dgvMembers.BackgroundColor = Color.FromArgb(28, 28, 28);
            this.dgvMembers.ForeColor = Color.White;
            this.dgvMembers.DefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            this.dgvMembers.DefaultCellStyle.ForeColor = Color.White;
            this.dgvMembers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
            this.dgvMembers.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            this.dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvMembers.EnableHeadersVisualStyles = false;
            this.dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.RowHeadersVisible = false;

            // ===== Add Member Button =====
            this.btnAddMember.Text = "➕ Add Member";
            this.btnAddMember.Width = 150;
            this.btnAddMember.Height = 40;
            this.btnAddMember.Top = 410;
            this.btnAddMember.Left = 10;
            this.btnAddMember.FlatStyle = FlatStyle.Flat;
            this.btnAddMember.FlatAppearance.BorderSize = 0;
            this.btnAddMember.BackColor = Color.FromArgb(65, 105, 225);
            this.btnAddMember.ForeColor = Color.White;

            // ===== Edit Button =====
            this.btnEdit.Text = "✏ Edit";
            this.btnEdit.Width = 150;
            this.btnEdit.Height = 40;
            this.btnEdit.Top = 410;
            this.btnEdit.Left = 170;
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.BackColor = Color.FromArgb(65, 105, 225);
            this.btnEdit.ForeColor = Color.White;

            // ===== Delete Button =====
            this.btnDelete.Text = "🗑 Delete";
            this.btnDelete.Width = 150;
            this.btnDelete.Height = 40;
            this.btnDelete.Top = 410;
            this.btnDelete.Left = 330;
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.BackColor = Color.FromArgb(65, 105, 225);
            this.btnDelete.ForeColor = Color.White;

            // ===== Form =====
            this.ClientSize = new Size(800, 480);
            this.BackColor = Color.FromArgb(18, 18, 18);
            this.Controls.Add(this.dgvMembers);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";

            this.ResumeLayout(false);
        }
    }
}
