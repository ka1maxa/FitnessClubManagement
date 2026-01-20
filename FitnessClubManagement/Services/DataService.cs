using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using FitnessClubManagement.Models;
using FitnessClubManagement.Enums;

namespace FitnessClubManagement.Services
{
    public class DataService
    {
        private const string MembersFile = "members.json";
        private const string TrainersFile = "trainers.json";
        private const string MembershipsFile = "memberships.json";

        public List<Member> Members { get; private set; }
        public List<Trainer> Trainers { get; private set; }
        public List<Membership> Memberships { get; private set; }

        public DataService()
        {
            Members = new List<Member>();
            Trainers = new List<Trainer>();
            Memberships = new List<Membership>();
        }

        public void LoadData()
        {
            LoadMemberships();
            LoadTrainers();
            LoadMembers();
        }

        private void LoadMemberships()
        {
            if (!File.Exists(MembershipsFile))
            {
                Memberships = new List<Membership>
                {
                    new Membership { Id = 1, Type = MembershipType.Basic },
                    new Membership { Id = 2, Type = MembershipType.Premium },
                    new Membership { Id = 3, Type = MembershipType.VIP }
                };
                SaveMemberships();
                return;
            }
            Memberships = JsonConvert.DeserializeObject<List<Membership>>(File.ReadAllText(MembershipsFile)) ?? new List<Membership>();
        }

        private void LoadTrainers()
        {
            if (!File.Exists(TrainersFile))
            {
                Trainers = new List<Trainer>();
                return;
            }
            Trainers = JsonConvert.DeserializeObject<List<Trainer>>(File.ReadAllText(TrainersFile)) ?? new List<Trainer>();
        }

        private void LoadMembers()
        {
            if (!File.Exists(MembersFile))
            {
                Members = new List<Member>();
                return;
            }

            Members = JsonConvert.DeserializeObject<List<Member>>(File.ReadAllText(MembersFile)) ?? new List<Member>();

            // rebinding
            foreach (var m in Members)
            {
                m.Membership = Memberships.FirstOrDefault(x => x.Id == m.MembershipId);
                m.AssignedTrainer = Trainers.FirstOrDefault(t => t.Username == m.AssignedTrainerUsername);
            }
        }

        public void SaveMembers()
        {
            foreach (var m in Members)
            {
                m.MembershipId = m.Membership?.Id ?? 0;
                m.AssignedTrainerUsername = m.AssignedTrainer?.Username;
            }

            File.WriteAllText(MembersFile, JsonConvert.SerializeObject(Members, Formatting.Indented));
        }

        public void SaveMemberships()
        {
            File.WriteAllText(MembershipsFile, JsonConvert.SerializeObject(Memberships, Formatting.Indented));
        }

        public void SaveTrainers()
        {
            File.WriteAllText(TrainersFile, JsonConvert.SerializeObject(Trainers, Formatting.Indented));
        }
    }
}
