using System;
using System.Linq;
using System.Windows.Forms;
using FitnessClubManagement.Models;
using FitnessClubManagement.Services;

namespace FitnessClubManagement.Forms
{
    public partial class MemberForm : Form
    {
        private DataService _dataService;
        public Member NewMember { get; private set; }

        public MemberForm(DataService dataService, Member member = null)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            InitializeComponent();

            cmbMembership.DataSource = _dataService.Memberships.ToList();
            cmbMembership.DisplayMember = "Type";
            cmbMembership.ValueMember = "Id";

            cmbTrainer.DataSource = _dataService.Trainers.ToList();
            cmbTrainer.DisplayMember = "FullName";
            cmbTrainer.ValueMember = "Username";

            if (member != null)
            {
                txtFullName.Text = member.FullName;
                dtBirth.Value = member.DateOfBirth;
                txtHeight.Text = member.Height.ToString();
                txtWeight.Text = member.Weight.ToString();
                txtPhone.Text = member.PhoneNumber;

                cmbMembership.SelectedItem = _dataService.Memberships.FirstOrDefault(m => m.Id == member.MembershipId);
                cmbTrainer.SelectedItem = _dataService.Trainers.FirstOrDefault(t => t.Username == member.AssignedTrainerUsername);

                chkIsActive.Checked = member.IsActive;
            }

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Enter Full Name");
                return;
            }

            if (!double.TryParse(txtHeight.Text, out double h) || h <= 0)
            {
                MessageBox.Show("Enter valid Height");
                return;
            }

            if (!double.TryParse(txtWeight.Text, out double w) || w <= 0)
            {
                MessageBox.Show("Enter valid Weight");
                return;
            }

            NewMember = new Member
            {
                FullName = txtFullName.Text,
                DateOfBirth = dtBirth.Value,
                Height = h,
                Weight = w,
                PhoneNumber = txtPhone.Text,
                Membership = cmbMembership.SelectedItem as Membership,
                AssignedTrainer = cmbTrainer.SelectedItem as Trainer,
                IsActive = chkIsActive.Checked
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
