using System;
using FitnessClubManagement.Enums;

namespace FitnessClubManagement.Models
{
    public class Member : Person
    {
        public DateTime DateOfBirth { get; set; }
        public double Height { get; set; } // cm
        public double Weight { get; set; } // kg
        public Membership Membership { get; set; }
        public bool IsActive { get; set; }

        public int CalculateAge()
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }

        public double CalculateBMI()
        {
            double heightInMeters = Height / 100;
            return Weight / (heightInMeters * heightInMeters);
        }
    }
}
