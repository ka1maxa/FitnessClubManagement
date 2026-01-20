using System;
using FitnessClubManagement.Enums;

namespace FitnessClubManagement.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public MembershipType Type { get; set; }  // NEW: Enum property

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsExpired { get; set; }
    }
}
