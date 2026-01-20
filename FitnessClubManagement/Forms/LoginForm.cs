using System;
using System.Linq;
using System.Windows.Forms;
using FitnessClubManagement.Enums;
using FitnessClubManagement.Forms;
using FitnessClubManagement.Models;
using FitnessClubManagement.Services;

namespace FitnessClubManagement
{
    public partial class LoginForm : Form
    {
        private DataService _dataService;

        public LoginForm()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;

            _dataService = new DataService();
            _dataService.LoadData();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            AuthService authService = new AuthService();
            User user = authService.Login(username, password);

            if (user == null)
            {
                lblError.Text = "Invalid login";
                return;
            }

            Form dashboard = null;

            if (user.Role == UserRole.Admin)
            {
                dashboard = new AdminForm(_dataService);
            }
            else if (user.Role == UserRole.Trainer)
            {
                var trainer = _dataService.Trainers
                    .FirstOrDefault(t => t.Username == user.Username);

                dashboard = new TrainerForm(_dataService, trainer);
            }
            else if (user.Role == UserRole.Member)
            {
                // ✅ MEMBER რეგისტრაცია
                MemberForm form = new MemberForm(_dataService);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _dataService.Members.Add(form.NewMember);
                    _dataService.SaveMembers(); // ✅ აქ იყო შეცდომა

                    MessageBox.Show("Member data saved!");
                }
                return;
            }

            this.Hide();
            dashboard.FormClosed += (s, a) => this.Close();
            dashboard.Show();
        }
    }
}
