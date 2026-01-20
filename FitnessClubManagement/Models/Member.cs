using System;
using Newtonsoft.Json;

namespace FitnessClubManagement.Models
{
    public class Member : Person
    {
        public DateTime DateOfBirth { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        [JsonIgnore]
        public Membership Membership { get; set; }
        public int MembershipId { get; set; }

        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; } = true;

        [JsonIgnore]
        public Trainer AssignedTrainer { get; set; }
        public string AssignedTrainerUsername { get; set; }
    }
}
