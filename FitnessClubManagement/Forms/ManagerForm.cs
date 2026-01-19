using FitnessClubManagement.Services;
using FitnessClubManagement.Models;
using System;
using System.Windows.Forms;

namespace FitnessClubManagement.Forms
{
    public partial class ManagerForm : Form
    {
        private MembershipManager _membershipManager;
        private Timer expirationTimer;

        public ManagerForm()
        {
            InitializeComponent();

            _membershipManager = new MembershipManager();
            _membershipManager.MembershipExpired += OnMembershipExpired;

            expirationTimer = new Timer();
            expirationTimer.Interval = 60000; 
            expirationTimer.Tick += ExpirationTimer_Tick;
            expirationTimer.Start();
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            LoadExpiredMemberships();
        }

        private void ExpirationTimer_Tick(object sender, EventArgs e)
        {
            _membershipManager.CheckExpirations();
            LoadExpiredMemberships();
        }

        private void LoadExpiredMemberships()
        {
            dgvExpired.DataSource = null;
            dgvExpired.DataSource = _membershipManager.GetExpiredMemberships();
        }

        private void OnMembershipExpired(Membership membership)
        {
            MessageBox.Show(
                $"აბონიმენტი ამოიწურა (Member ID: {membership.MemberId})",
                "გაფრთხილება",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }
    }
}
