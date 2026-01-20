using System;
using FitnessClubManagement.Enums;

namespace FitnessClubManagement.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public MembershipType Type { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddMonths(1);

        public bool IsExpired => DateTime.Now > EndDate;
    }
}
