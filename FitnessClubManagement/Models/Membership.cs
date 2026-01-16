using System;
using FitnessClubManagement.Enums;

namespace FitnessClubManagement.Models
{
    public class Membership
    {
        public MembershipType Type { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsExpired()
        {
            return DateTime.Now > EndDate;
        }
    }
}
