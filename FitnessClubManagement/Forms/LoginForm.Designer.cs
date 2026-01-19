using System;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessClubManagement
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelCard;
        private Label lblTitle;
        private Label lblSubtitle;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Panel underlineUser;
        private Panel underlinePass;
        private Button btnLogin;
        private Label lblError;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelCard = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.txtUsername = new TextBox();
            this.underlineUser = new Panel();
            this.txtPassword = new TextBox();
            this.underlinePass = new Panel();
            this.btnLogin = new Button();
            this.lblError = new Label();

            this.panelCard.SuspendLayout();
            this.SuspendLayout();

            // ===== FORM =====
            this.BackColor = Color.FromArgb(18, 18, 18);
            this.ClientSize = new Size(700, 480);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "LoginForm";

            // ===== PANEL CARD =====
            this.panelCard.BackColor = Color.FromArgb(28, 28, 28);
            this.panelCard.Size = new Size(380, 420);
            this.panelCard.Location = new Point(
                (this.ClientSize.Width - this.panelCard.Width) / 2,
                (this.ClientSize.Height - this.panelCard.Height) / 2
            );

            // ===== TITLE =====
            this.lblTitle.Text = "Welcome Back";
            this.lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(60, 40);

            // ===== SUBTITLE =====
            this.lblSubtitle.Text = "Login to your account";
            this.lblSubtitle.Font = new Font("Segoe UI", 10);
            this.lblSubtitle.ForeColor = Color.Gray;
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new Point(90, 85);

            // ===== USERNAME =====
            this.txtUsername.Text = "Username";
            this.txtUsername.ForeColor = Color.Gray;
            this.txtUsername.Font = new Font("Segoe UI", 11);
            this.txtUsername.BorderStyle = BorderStyle.None;
            this.txtUsername.BackColor = this.panelCard.BackColor;
            this.txtUsername.Location = new Point(40, 140);
            this.txtUsername.Width = 300;
            this.txtUsername.Enter += RemoveText;
            this.txtUsername.Leave += AddText;

            // ===== USERNAME UNDERLINE =====
            this.underlineUser.BackColor = Color.Gray;
            this.underlineUser.Size = new Size(300, 2);
            this.underlineUser.Location = new Point(40, 165);

            // ===== PASSWORD =====
            this.txtPassword.Text = "Password";
            this.txtPassword.ForeColor = Color.Gray;
            this.txtPassword.Font = new Font("Segoe UI", 11);
            this.txtPassword.BorderStyle = BorderStyle.None;
            this.txtPassword.BackColor = this.panelCard.BackColor;
            this.txtPassword.Location = new Point(40, 200);
            this.txtPassword.Width = 300;
            this.txtPassword.Enter += RemoveText;
            this.txtPassword.Leave += AddText;

            // ===== PASSWORD UNDERLINE =====
            this.underlinePass.BackColor = Color.Gray;
            this.underlinePass.Size = new Size(300, 2);
            this.underlinePass.Location = new Point(40, 225);

            // ===== LOGIN BUTTON =====
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnLogin.Size = new Size(300, 42);
            this.btnLogin.Location = new Point(40, 270);
            this.btnLogin.BackColor = Color.FromArgb(65, 105, 225); // Royal Blue
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;

            // ===== ERROR LABEL =====
            this.lblError.Text = "";
            this.lblError.ForeColor = Color.IndianRed;
            this.lblError.Font = new Font("Segoe UI", 9);
            this.lblError.AutoSize = true;
            this.lblError.Location = new Point(40, 325);

            // ===== ADD CONTROLS =====
            this.panelCard.Controls.Add(this.lblTitle);
            this.panelCard.Controls.Add(this.lblSubtitle);
            this.panelCard.Controls.Add(this.txtUsername);
            this.panelCard.Controls.Add(this.underlineUser);
            this.panelCard.Controls.Add(this.txtPassword);
            this.panelCard.Controls.Add(this.underlinePass);
            this.panelCard.Controls.Add(this.btnLogin);
            this.panelCard.Controls.Add(this.lblError);

            this.Controls.Add(this.panelCard);

            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);
        }

        // ===== PLACEHOLDER METHODS (USED BY DESIGNER EVENTS) =====
        private void RemoveText(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb.Text == "Username" || tb.Text == "Password")
            {
                tb.Text = "";
                tb.ForeColor = Color.White;

                if (tb == txtPassword)
                    tb.UseSystemPasswordChar = true;
            }
        }

        private void AddText(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.ForeColor = Color.Gray;

                if (tb == txtUsername)
                    tb.Text = "Username";
                else
                {
                    tb.UseSystemPasswordChar = false;
                    tb.Text = "Password";
                }
            }
        }
    }
}
