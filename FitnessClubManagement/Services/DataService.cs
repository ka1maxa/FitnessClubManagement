using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using FitnessClubManagement.Models;
using System.Xml;

namespace FitnessClubManagement.Services
{
    public class DataService
    {
        private const string MembersFile = "members.json";
        private const string TrainersFile = "trainers.json";

        public List<Member> Members { get; private set; }
        public List<Trainer> Trainers { get; private set; }

        public DataService()
        {
            Members = new List<Member>();
            Trainers = new List<Trainer>();
        }

        // ---------------- LOAD ----------------

        public void LoadData()
        {
            LoadMembers();
            LoadTrainers();
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

        // ---------------- SAVE ----------------

        public void SaveData()
        {
            SaveMembers();
            SaveTrainers();
        }

        private void SaveMembers()
        {
            string json = JsonConvert.SerializeObject(Members, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(MembersFile, json);
        }

        private void SaveTrainers()
        {
            string json = JsonConvert.SerializeObject(Trainers, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(TrainersFile, json);
        }
    }
}
