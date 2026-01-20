using System;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessClubManagement.Forms
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvMembers;
        private Panel panelLeft;
        private Panel panelHeader;
        private Panel panelBottom;

        private Label lblTitle;
        private Label lblId;
        private Label lblName;
        private Label lblBirth;
        private Label lblHeight;
        private Label lblWeight;
        private Label lblMembership;
        private Label lblPhoneNumber;

        private TextBox txtId;
        private TextBox txtFullName;
        private TextBox txtHeight;
        private TextBox txtWeight;
        private ComboBox cmbMembership;
        private TextBox txtPhoneNumber;
        private DateTimePicker dtBirth;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvMembers = new DataGridView();
            this.panelLeft = new Panel();
            this.panelHeader = new Panel();
            this.panelBottom = new Panel();

            this.lblTitle = new Label();
            this.lblId = new Label();
            this.lblName = new Label();
            this.lblBirth = new Label();
            this.lblHeight = new Label();
            this.lblWeight = new Label();
            this.lblMembership = new Label();
            this.lblPhoneNumber = new Label();

            this.txtId = new TextBox();
            this.txtFullName = new TextBox();
            this.txtHeight = new TextBox();
            this.txtWeight = new TextBox();
            this.cmbMembership = new ComboBox();
            this.txtPhoneNumber = new TextBox();
            this.dtBirth = new DateTimePicker();

            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // ===== Form =====
            this.ClientSize = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            this.BackColor = Color.FromArgb(18, 18, 18);

            // ===== Header =====
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 60;
            this.panelHeader.BackColor = Color.FromArgb(28, 28, 28);

            this.lblTitle.Text = "ADMIN PANEL";
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Left = 20;
            this.lblTitle.Top = 18;

            this.panelHeader.Controls.Add(this.lblTitle);

            // ===== Left Panel =====
            this.panelLeft.Dock = DockStyle.Left;
            this.panelLeft.Width = 280;
            this.panelLeft.Padding = new Padding(10);
            this.panelLeft.BackColor = Color.FromArgb(28, 28, 28);

            SetupLabel(lblId, "ID", 10);
            SetupTextBox(txtId, 30);

            SetupLabel(lblName, "Full Name", 70);
            SetupTextBox(txtFullName, 90);

            SetupLabel(lblBirth, "Birth Date", 130);
            dtBirth.Top = 150;
            dtBirth.Left = 10;
            dtBirth.Width = 250;
            dtBirth.CalendarForeColor = Color.White;
            dtBirth.CalendarMonthBackground = Color.FromArgb(28, 28, 28);
            dtBirth.CalendarTitleBackColor = Color.FromArgb(28, 28, 28);
            dtBirth.CalendarTitleForeColor = Color.White;

            SetupLabel(lblHeight, "Height (cm)", 190);
            SetupTextBox(txtHeight, 210);

            SetupLabel(lblWeight, "Weight (kg)", 250);
            SetupTextBox(txtWeight, 270);

            SetupLabel(lblMembership, "Membership", 310);
            cmbMembership.Top = 330;
            cmbMembership.Left = 10;
            cmbMembership.Width = 250;
            cmbMembership.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMembership.BackColor = Color.FromArgb(28, 28, 28);
            cmbMembership.ForeColor = Color.White;

            SetupLabel(lblPhoneNumber, "Phone Number", 370);
            SetupTextBox(txtPhoneNumber, 390);

            this.panelLeft.Controls.AddRange(new Control[]
            {
                lblId, txtId,
                lblName, txtFullName,
                lblBirth, dtBirth,
                lblHeight, txtHeight,
                lblWeight, txtWeight,
                lblMembership, cmbMembership,
                lblPhoneNumber, txtPhoneNumber
            });

            // ===== DataGrid =====
            this.dgvMembers.Dock = DockStyle.Fill;
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembers.RowHeadersVisible = false;
            this.dgvMembers.BackgroundColor = Color.FromArgb(28, 28, 28);
            this.dgvMembers.ForeColor = Color.White;
            this.dgvMembers.GridColor = Color.Gray;

            this.dgvMembers.DefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            this.dgvMembers.DefaultCellStyle.ForeColor = Color.White;
            this.dgvMembers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
            this.dgvMembers.DefaultCellStyle.SelectionForeColor = Color.White;

            this.dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
            this.dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvMembers.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
            this.dgvMembers.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            this.dgvMembers.EnableHeadersVisualStyles = false;

            // ===== Bottom Panel =====
            this.panelBottom.Dock = DockStyle.Bottom;
            this.panelBottom.Height = 80;
            this.panelBottom.Padding = new Padding(10);
            this.panelBottom.BackColor = Color.FromArgb(28, 28, 28);

            SetupButton(btnAdd, "➕ Add", 10);
            SetupButton(btnEdit, "✏ Edit", 110);
            SetupButton(btnDelete, "🗑 Delete", 210);

            this.panelBottom.Controls.AddRange(new Control[]
            {
                btnAdd, btnEdit, btnDelete
            });

            // ===== Form Controls =====
            this.Controls.Add(this.dgvMembers);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelHeader);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void SetupLabel(Label l, string text, int top)
        {
            l.Text = text;
            l.Top = top;
            l.Left = 10;
            l.Font = new Font("Segoe UI", 9F);
            l.ForeColor = Color.White;
            l.AutoSize = true;
        }

        private void SetupTextBox(TextBox t, int top)
        {
            t.Top = top;
            t.Left = 10;
            t.Width = 250;
            t.BackColor = Color.FromArgb(28, 28, 28);
            t.ForeColor = Color.White;
            t.BorderStyle = BorderStyle.FixedSingle;
        }

        private void SetupButton(Button b, string text, int left)
        {
            b.Text = text;
            b.Width = 90;
            b.Height = 40;
            b.Left = left;
            b.Top = 20;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = Color.FromArgb(65, 105, 225); // blue button
            b.ForeColor = Color.White;
        }
    }
}
