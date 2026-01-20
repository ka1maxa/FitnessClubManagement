using System;
using System.Linq;
using System.Windows.Forms;
using FitnessClubManagement.Models;
using FitnessClubManagement.Services;

namespace FitnessClubManagement.Forms
{
    public partial class TrainerForm : Form
    {
        private DataService _dataService;
        private Trainer _currentTrainer;

        public TrainerForm(DataService dataService, Trainer trainer)
        {
            if (dataService == null) throw new ArgumentNullException(nameof(dataService));
            if (trainer == null) throw new ArgumentNullException(nameof(trainer));

            _dataService = dataService;
            _currentTrainer = trainer;

            InitializeComponent();

            lblTrainerName.Text = $"Trainer: {_currentTrainer.FullName}";
            LoadMembersForTrainer();
        }

        private void LoadMembersForTrainer()
        {
            if (_dataService.Members == null) return;

            var membersForThisTrainer = _dataService.Members
                .Where(m => m.AssignedTrainer != null && m.AssignedTrainer.Username == _currentTrainer.Username)
                .Select(m => new
                {
                    m.FullName,
                    m.DateOfBirth,
                    m.Height,
                    m.Weight,
                    m.PhoneNumber,
                    Membership = m.Membership?.Type.ToString() ?? "None",
                    m.IsActive
                })
                .ToList();

            dgvMembers.DataSource = membersForThisTrainer;
        }
    }
}
