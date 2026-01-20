using FitnessClubManagement.Models;
using FitnessClubManagement.Services;
using FitnessClubManagement.Enums;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FitnessClubManagement.Forms
{
    public partial class AdminForm : Form
    {
        private DataService _dataService;

        public AdminForm()
        {
            InitializeComponent();

            _dataService = new DataService();
            _dataService.LoadData();

            dgvMembers.DataSource = _dataService.Members.ToList();

            // Button events
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;

            dgvMembers.SelectionChanged += DgvMembers_SelectionChanged;

            // Membership ComboBox binding
            cmbMembership.DataSource = Enum.GetValues(typeof(MembershipType));
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Invalid ID!");
                return;
            }

            if (_dataService.Members.Any(x => x.Id == id))
            {
                MessageBox.Show("Member with this ID already exists!");
                return;
            }

            Member m = new Member
            {
                Id = id,
                FullName = txtFullName.Text,
                Height = double.TryParse(txtHeight.Text, out double h) ? h : 0,
                Weight = double.TryParse(txtWeight.Text, out double w) ? w : 0,
                DateOfBirth = dtBirth.Value,
                Membership = new Membership
                {
                    Type = (MembershipType)cmbMembership.SelectedItem
                },
                PhoneNumber = txtPhoneNumber.Text, // ✅ ეს უკვე არსებობს
                IsActive = true
            };

            _dataService.Members.Add(m);
            UpdateGrid();
            ClearInputs();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) return;

            var member = _dataService.Members.FirstOrDefault(x => x.Id == id);
            if (member == null)
            {
                MessageBox.Show("Member not found!");
                return;
            }

            member.FullName = txtFullName.Text;
            member.Height = double.TryParse(txtHeight.Text, out double h) ? h : member.Height;
            member.Weight = double.TryParse(txtWeight.Text, out double w) ? w : member.Weight;
            member.DateOfBirth = dtBirth.Value;

            if (member.Membership == null)
                member.Membership = new Membership();

            member.Membership.Type = (MembershipType)cmbMembership.SelectedItem;
            member.PhoneNumber = txtPhoneNumber.Text;

            UpdateGrid();
            ClearInputs();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0) return;

            if (dgvMembers.SelectedRows[0].DataBoundItem is Member m)
            {
                _dataService.Members.Remove(m);
                UpdateGrid();
                ClearInputs();
            }
        }

        private void DgvMembers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0) return;

            if (dgvMembers.SelectedRows[0].DataBoundItem is Member m)
            {
                txtId.Text = m.Id.ToString();
                txtFullName.Text = m.FullName;
                txtHeight.Text = m.Height.ToString();
                txtWeight.Text = m.Weight.ToString();
                dtBirth.Value = m.DateOfBirth;

                if (m.Membership != null)
                    cmbMembership.SelectedItem = m.Membership.Type;

                txtPhoneNumber.Text = m.PhoneNumber;
            }
        }

        private void UpdateGrid()
        {
            _dataService.SaveData();
            dgvMembers.DataSource = null;
            dgvMembers.DataSource = _dataService.Members.ToList();
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtFullName.Clear();
            txtHeight.Clear();
            txtWeight.Clear();
            dtBirth.Value = DateTime.Now;
            cmbMembership.SelectedIndex = 0;
            txtPhoneNumber.Clear();
        }
    }
}
