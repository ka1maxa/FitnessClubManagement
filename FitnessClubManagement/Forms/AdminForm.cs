using System;
using System.Linq;
using System.Windows.Forms;
using FitnessClubManagement.Models;
using FitnessClubManagement.Services;

namespace FitnessClubManagement.Forms
{
    public partial class AdminForm : Form
    {
        private DataService _dataService;

        public AdminForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponent();

            btnAddMember.Click += BtnAddMember_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            dgvMembers.DataSource = null;
            dgvMembers.AutoGenerateColumns = false;
            dgvMembers.Columns.Clear();

            dgvMembers.DataSource = _dataService.Members;

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Full Name", DataPropertyName = "FullName" });
            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "DOB", DataPropertyName = "DateOfBirth" });
            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Height", DataPropertyName = "Height" });
            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Weight", DataPropertyName = "Weight" });
            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Phone", DataPropertyName = "PhoneNumber" });
            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Membership", DataPropertyName = "Membership" });
            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trainer", DataPropertyName = "AssignedTrainer" });
            dgvMembers.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "IsActive", DataPropertyName = "IsActive" });

            dgvMembers.CellFormatting += (s, e) =>
            {
                if (dgvMembers.Columns[e.ColumnIndex].DataPropertyName == "Membership" && e.Value is Membership mem)
                    e.Value = mem != null ? mem.Type.ToString() : "None";

                if (dgvMembers.Columns[e.ColumnIndex].DataPropertyName == "AssignedTrainer" && e.Value is Trainer tr)
                    e.Value = tr != null ? tr.FullName : "";
            };
        }

        private void BtnAddMember_Click(object sender, EventArgs e)
        {
            MemberForm form = new MemberForm(_dataService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _dataService.Members.Add(form.NewMember);
                _dataService.SaveMembers();   // ✅ აქ იყო პრობლემა
                UpdateGrid();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0) return;

            var member = (Member)dgvMembers.SelectedRows[0].DataBoundItem;

            MemberForm form = new MemberForm(_dataService, member);
            if (form.ShowDialog() == DialogResult.OK)
            {
                member.FullName = form.NewMember.FullName;
                member.DateOfBirth = form.NewMember.DateOfBirth;
                member.Height = form.NewMember.Height;
                member.Weight = form.NewMember.Weight;
                member.PhoneNumber = form.NewMember.PhoneNumber;
                member.Membership = form.NewMember.Membership;
                member.MembershipId = form.NewMember.MembershipId;
                member.AssignedTrainer = form.NewMember.AssignedTrainer;
                member.AssignedTrainerUsername = form.NewMember.AssignedTrainerUsername;
                member.IsActive = form.NewMember.IsActive;

                _dataService.SaveMembers();   // ✅ აქაც
                UpdateGrid();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0) return;

            var member = (Member)dgvMembers.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Delete {member.FullName}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _dataService.Members.Remove(member);
                _dataService.SaveMembers();   // ✅ და აქაც
                UpdateGrid();
            }
        }
    }
}
