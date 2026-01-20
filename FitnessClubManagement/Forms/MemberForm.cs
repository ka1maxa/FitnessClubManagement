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
        private Member _editingMember;

        public Member NewMember { get; private set; }

        // ➕ ADD (ახალი Member)
        public MemberForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponent();
            InitCombos();
        }

        // ➕ EDIT (არსებული Member)
        public MemberForm(DataService dataService, Member member)
        {
            _dataService = dataService;
            _editingMember = member;
            InitializeComponent();
            InitCombos();
            FillForm(member);
        }

        private void InitCombos()
        {
            cmbMembership.DataSource = _dataService.Memberships;
            cmbMembership.DisplayMember = "Type";
            cmbMembership.ValueMember = "Id";

            cmbTrainer.DataSource = _dataService.Trainers;
            cmbTrainer.DisplayMember = "FullName";
            cmbTrainer.ValueMember = "Username";

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => Close();
        }

        private void FillForm(Member m)
        {
            txtFullName.Text = m.FullName;
            dtBirth.Value = m.DateOfBirth;
            txtHeight.Text = m.Height.ToString();
            txtWeight.Text = m.Weight.ToString();
            txtPhone.Text = m.PhoneNumber;
            chkIsActive.Checked = m.IsActive;

            if (m.Membership != null)
                cmbMembership.SelectedItem =
                    _dataService.Memberships.FirstOrDefault(x => x.Id == m.Membership.Id);

            if (m.AssignedTrainer != null)
                cmbTrainer.SelectedItem =
                    _dataService.Trainers.FirstOrDefault(t => t.Username == m.AssignedTrainer.Username);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            double height, weight;

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Enter Full Name");
                return;
            }

            if (!double.TryParse(txtHeight.Text, out height))
            {
                MessageBox.Show("Invalid height");
                return;
            }

            if (!double.TryParse(txtWeight.Text, out weight))
            {
                MessageBox.Show("Invalid weight");
                return;
            }

            var membership = cmbMembership.SelectedItem as Membership;
            var trainer = cmbTrainer.SelectedItem as Trainer;

            NewMember = new Member
            {
                FullName = txtFullName.Text,
                DateOfBirth = dtBirth.Value,
                Height = height,
                Weight = weight,
                PhoneNumber = txtPhone.Text,
                IsActive = chkIsActive.Checked,

                Membership = membership,
                MembershipId = membership != null ? membership.Id : 0,

                AssignedTrainer = trainer,
                AssignedTrainerUsername = trainer != null ? trainer.Username : null
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
