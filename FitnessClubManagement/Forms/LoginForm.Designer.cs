using System;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessClubManagement
{
    partial class LoginForm
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblError;
        private Button btnLogin;

        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form settings
            this.BackColor = Color.FromArgb(18, 18, 18);
            this.ClientSize = new Size(700, 480);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Card panel
            Panel panelCard = new Panel()
            {
                Size = new Size(360, 400),
                Location = new Point((this.Width - 360) / 2, (this.Height - 400) / 2),
                BackColor = Color.FromArgb(30, 30, 30)
            };
            this.Controls.Add(panelCard);

            // Title
            Label lblTitle = new Label()
            {
                Text = "FITNESS CLUB",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 70
            };
            panelCard.Controls.Add(lblTitle);

            // Subtitle
            Label lblSubtitle = new Label()
            {
                Text = "Sign in to continue",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 30
            };
            panelCard.Controls.Add(lblSubtitle);

            int inputWidth = 280;
            int inputHeight = 35;
            int marginTop = 120;

            // Username textbox
            txtUsername = new TextBox()
            {
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.Gray,
                BorderStyle = BorderStyle.None,
                Size = new Size(inputWidth, inputHeight),
                Location = new Point((panelCard.Width - inputWidth) / 2, marginTop),
                Text = "Username"
            };
            txtUsername.GotFocus += RemoveText;
            txtUsername.LostFocus += AddText;
            panelCard.Controls.Add(txtUsername);

            Panel underlineUser = new Panel()
            {
                Size = new Size(inputWidth, 2),
                BackColor = Color.Gray,
                Location = new Point(txtUsername.Left, txtUsername.Bottom)
            };
            panelCard.Controls.Add(underlineUser);

            // Password textbox
            txtPassword = new TextBox()
            {
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.Gray,
                BorderStyle = BorderStyle.None,
                Size = new Size(inputWidth, inputHeight),
                Location = new Point((panelCard.Width - inputWidth) / 2, txtUsername.Bottom + 30),
                Text = "Password"
            };
            txtPassword.GotFocus += RemoveText;
            txtPassword.LostFocus += AddText;
            panelCard.Controls.Add(txtPassword);

            Panel underlinePass = new Panel()
            {
                Size = new Size(inputWidth, 2),
                BackColor = Color.Gray,
                Location = new Point(txtPassword.Left, txtPassword.Bottom)
            };
            panelCard.Controls.Add(underlinePass);

            // Login button
            btnLogin = new Button()
            {
                Text = "LOGIN",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(0, 200, 150),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(inputWidth, 40),
                Location = new Point((panelCard.Width - inputWidth) / 2, txtPassword.Bottom + 50)
            };
            btnLogin.FlatAppearance.BorderSize = 0;


            panelCard.Controls.Add(btnLogin);

            // Error label
            lblError = new Label()
            {
                ForeColor = Color.IndianRed,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(panelCard.Width, 20),
                Location = new Point(0, btnLogin.Bottom + 10)
            };
            panelCard.Controls.Add(lblError);

            this.ResumeLayout(false);
        }

        // Placeholder logic
        private void RemoveText(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
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
            TextBox tb = (TextBox)sender;
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
