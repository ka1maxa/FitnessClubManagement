using System;
using System.Linq;
using FitnessClubManagement.Models;

namespace FitnessClubManagement.Services
{
    public class MembershipManager
    {
        private DataService dataService;

        public event Action<Member> MembershipExpired;

        public MembershipManager(DataService dataService)
        {
            this.dataService = dataService;
        }

    
        public void CheckMemberships()
        {
            var expiredMembers = dataService.Members
                .Where(m => m.Membership != null && m.Membership.IsExpired())
                .ToList();

            foreach (var member in expiredMembers)
            {
                member.IsActive = false;
                MembershipExpired?.Invoke(member);
            }
        }
    }
}
