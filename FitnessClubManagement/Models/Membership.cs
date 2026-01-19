using System;

namespace FitnessClubManagement.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public int MemberId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsExpired { get; set; }
    }
}
