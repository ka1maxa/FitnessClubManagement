using System;
using FitnessClubManagement.Enums;

namespace FitnessClubManagement.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public MembershipType Type { get; set; }  // Enum property

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddMonths(1);

        // Automatically calculates if the membership is expired
        public bool IsExpired => DateTime.Now > EndDate;

        // ✅ NEVER do: membership.IsExpired = true; <- this will cause compile error
        // Instead, adjust EndDate to mark it expired if needed:
        // membership.EndDate = DateTime.Now.AddDays(-1);
    }
}
