using FitnessClubManagement.Enums;

namespace FitnessClubManagement.Models
{
    public class Trainer : Person
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public TrainerSpecialization Specialization { get; set; }
        public int ExperienceYears { get; set; }
        public decimal Salary { get; set; }
    }
}
