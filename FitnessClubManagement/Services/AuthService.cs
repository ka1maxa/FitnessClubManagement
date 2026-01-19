using System.Collections.Generic;
using System.Linq;
using FitnessClubManagement.Enums;
using FitnessClubManagement.Models;

namespace FitnessClubManagement.Services
{
    public class AuthService
    {
        private List<User> _users;

        public AuthService()
        {
            _users = new List<User>
            {
                new User { Username = "admin",   Password = "123", Role = UserRole.Admin },
                new User { Username = "manager", Password = "123", Role = UserRole.Manager },
                new User { Username = "trainer", Password = "123", Role = UserRole.Trainer },
                new User { Username = "member",  Password = "123", Role = UserRole.Member }
            };
        }

        public User Login(string username, string password)
        {
            return _users.FirstOrDefault(u =>
                u.Username == username && u.Password == password);
        }
    }
}
