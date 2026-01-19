using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using FitnessClubManagement.Models;

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

        // -------- LOAD --------
        public void LoadData()
        {
            LoadMembers();
            LoadTrainers();
            LoadMemberships();
        }

        private void LoadMembers()
        {
            if (!File.Exists(MembersFile))
            {
                Members = new List<Member>();
                return;
            }

            string json = File.ReadAllText(MembersFile);
            Members = JsonConvert.DeserializeObject<List<Member>>(json)
                      ?? new List<Member>();
        }

        private void LoadTrainers()
        {
            if (!File.Exists(TrainersFile))
            {
                Trainers = new List<Trainer>();
                return;
            }

            string json = File.ReadAllText(TrainersFile);
            Trainers = JsonConvert.DeserializeObject<List<Trainer>>(json)
                       ?? new List<Trainer>();
        }

        private void LoadMemberships()
        {
            if (!File.Exists(MembershipsFile))
            {
                Memberships = new List<Membership>();
                return;
            }

            string json = File.ReadAllText(MembershipsFile);
            Memberships = JsonConvert.DeserializeObject<List<Membership>>(json)
                          ?? new List<Membership>();
        }

        // -------- SAVE --------
        public void SaveData()
        {
            SaveMembers();
            SaveTrainers();
            SaveMemberships();
        }

        private void SaveMembers()
        {
            File.WriteAllText(
                MembersFile,
                JsonConvert.SerializeObject(Members, Formatting.Indented)
            );
        }

        private void SaveTrainers()
        {
            File.WriteAllText(
                TrainersFile,
                JsonConvert.SerializeObject(Trainers, Formatting.Indented)
            );
        }

        private void SaveMemberships()
        {
            File.WriteAllText(
                MembershipsFile,
                JsonConvert.SerializeObject(Memberships, Formatting.Indented)
            );
        }
    }
}
