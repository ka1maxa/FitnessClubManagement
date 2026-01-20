using System;
using System.Windows.Forms;
using FitnessClubManagement.Enums;
using FitnessClubManagement.Forms;
using FitnessClubManagement.Models;
using FitnessClubManagement.Services;

namespace FitnessClubManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent(); // initialize design
            btnLogin.Click += BtnLogin_Click; // attach login functionality
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Prevent placeholder values from being sent
            if (username == "Username" || password == "Password" || username == "" || password == "")
            {
                lblError.Text = "Please enter your username and password.";
                return;
            }

            AuthService authService = new AuthService();
            User user = authService.Login(username, password);

            if (user == null)
            {
                lblError.Text = "Invalid username or password";
                return;
            }

            Form dashboard = null;

            // Switch based on Enum UserRole
            switch (user.Role)
            {
                case UserRole.Admin:
                    dashboard = new AdminForm();
                    break;
                case UserRole.Manager:
                    dashboard = new ManagerForm();
                    break;
                case UserRole.Trainer:
                    dashboard = new TrainerForm();
                    break;
                case UserRole.Member:
                    dashboard = new MemberForm();
                    break;
                default:
                    lblError.Text = "Unknown role!";
                    return;
            }

            if (dashboard != null)
            {
                this.Hide();
                dashboard.FormClosed += (s, args) => this.Close();
                dashboard.Show();
            }
        }
    }
}
