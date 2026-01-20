using System;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessClubManagement.Forms
{
    partial class MemberForm
    {
        private System.ComponentModel.IContainer components = null;
        internal TextBox txtFullName;
        internal DateTimePicker dtBirth;
        internal TextBox txtHeight;
        internal TextBox txtWeight;
        internal TextBox txtPhone;
        internal ComboBox cmbMembership;
        internal ComboBox cmbTrainer;
        internal CheckBox chkIsActive;
        internal Button btnSave;
        internal Button btnCancel;
        internal Label lblFullName, lblBirth, lblHeight, lblWeight, lblPhone, lblMembership, lblTrainer, lblActive;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            int top = 20;
            int spacing = 35;

            this.txtFullName = new TextBox();
            this.dtBirth = new DateTimePicker();
            this.txtHeight = new TextBox();
            this.txtWeight = new TextBox();
            this.txtPhone = new TextBox();
            this.cmbMembership = new ComboBox();
            this.cmbTrainer = new ComboBox();
            this.chkIsActive = new CheckBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            this.lblFullName = new Label();
            this.lblBirth = new Label();
            this.lblHeight = new Label();
            this.lblWeight = new Label();
            this.lblPhone = new Label();
            this.lblMembership = new Label();
            this.lblTrainer = new Label();
            this.lblActive = new Label();

            // Labels
            lblFullName.Text = "Full Name:"; lblFullName.Top = top; lblFullName.Left = 20; lblFullName.ForeColor = Color.White; top += spacing;
            lblBirth.Text = "Date of Birth:"; lblBirth.Top = top; lblBirth.Left = 20; lblBirth.ForeColor = Color.White; top += spacing;
            lblHeight.Text = "Height (cm):"; lblHeight.Top = top; lblHeight.Left = 20; lblHeight.ForeColor = Color.White; top += spacing;
            lblWeight.Text = "Weight (kg):"; lblWeight.Top = top; lblWeight.Left = 20; lblWeight.ForeColor = Color.White; top += spacing;
            lblPhone.Text = "Phone:"; lblPhone.Top = top; lblPhone.Left = 20; lblPhone.ForeColor = Color.White; top += spacing;
            lblMembership.Text = "Membership:"; lblMembership.Top = top; lblMembership.Left = 20; lblMembership.ForeColor = Color.White; top += spacing;
            lblTrainer.Text = "Trainer:"; lblTrainer.Top = top; lblTrainer.Left = 20; lblTrainer.ForeColor = Color.White; top += spacing;
            lblActive.Text = "Active:"; lblActive.Top = top; lblActive.Left = 20; lblActive.ForeColor = Color.White; top += spacing;

            // Controls
            txtFullName.Top = 20; txtFullName.Left = 130; txtFullName.Width = 200;
            dtBirth.Top = 55; dtBirth.Left = 130; dtBirth.Width = 200;
            txtHeight.Top = 90; txtHeight.Left = 130; txtHeight.Width = 200;
            txtWeight.Top = 125; txtWeight.Left = 130; txtWeight.Width = 200;
            txtPhone.Top = 160; txtPhone.Left = 130; txtPhone.Width = 200;
            cmbMembership.Top = 195; cmbMembership.Left = 130; cmbMembership.Width = 200; cmbMembership.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrainer.Top = 230; cmbTrainer.Left = 130; cmbTrainer.Width = 200; cmbTrainer.DropDownStyle = ComboBoxStyle.DropDownList;
            chkIsActive.Top = 265; chkIsActive.Left = 130; chkIsActive.Width = 20;

            btnSave.Text = "Save"; btnSave.Top = 300; btnSave.Left = 50; btnSave.Width = 100; btnSave.Height = 35; btnSave.BackColor = Color.FromArgb(65, 105, 225); btnSave.ForeColor = Color.White;
            btnCancel.Text = "Cancel"; btnCancel.Top = 300; btnCancel.Left = 170; btnCancel.Width = 100; btnCancel.Height = 35; btnCancel.BackColor = Color.Gray; btnCancel.ForeColor = Color.White;

            this.Controls.AddRange(new Control[] { txtFullName, dtBirth, txtHeight, txtWeight, txtPhone, cmbMembership, cmbTrainer, chkIsActive,
                btnSave, btnCancel,
                lblFullName, lblBirth, lblHeight, lblWeight, lblPhone, lblMembership, lblTrainer, lblActive
            });

            this.BackColor = Color.FromArgb(18, 18, 18);
            this.ClientSize = new Size(380, 380);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Text = "Member Form";
        }
    }
}
