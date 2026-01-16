using FitnessClubManagement.Enums;

namespace FitnessClubManagement.Models
{
    public class Trainer : Person
    {
        public TrainerSpecialization Specialization { get; set; }
        public int ExperienceYears { get; set; }
        public decimal Salary { get; set; }
    }
}
