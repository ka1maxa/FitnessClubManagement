using FitnessClubManagement.Enums;
using FitnessClubManagement.Models;
using FitnessClubManagement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessClubManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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
