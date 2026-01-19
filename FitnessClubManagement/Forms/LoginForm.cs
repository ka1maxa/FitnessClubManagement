using FitnessClubManagement.Enums;
using FitnessClubManagement.Forms;
using FitnessClubManagement.Models;
using FitnessClubManagement.Services;
using System;
using System.Windows.Forms;

namespace FitnessClubManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            btnLogin.Click += btnLogin_Click; // attach click event
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            AuthService authService = new AuthService();
            User user = authService.Login(txtUsername.Text, txtPassword.Text);

            if (user == null)
            {
                lblError.Text = "Invalid username or password";
                return;
            }

            Form dashboard = null;

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
