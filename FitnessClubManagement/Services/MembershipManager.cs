using System;
using System.Collections.Generic;
using System.Linq;
using FitnessClubManagement.Models;

namespace FitnessClubManagement.Services
{
    public class MembershipManager
    {
        private readonly DataService _dataService;

        public event Action<Membership> MembershipExpired;

        public MembershipManager()
        {
            _dataService = new DataService();
            _dataService.LoadData();
        }

        public void CheckExpirations()
        {
            var expired = _dataService.Memberships
                .Where(m => m.EndDate < DateTime.Now && m.IsExpired == false)
                .ToList();

            foreach (var membership in expired)
            {
//                membership.IsExpired = true;
                MembershipExpired?.Invoke(membership);
            }

            if (expired.Any())
            {
                _dataService.SaveMembers();
            }
        }

        public List<Membership> GetExpiredMemberships()
        {
            return _dataService.Memberships
                .Where(m => m.IsExpired)
                .ToList();
        }
    }
}
