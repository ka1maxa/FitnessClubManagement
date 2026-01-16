using System.Collections.Generic;
using System.Linq;
using FitnessClubManagement.Models;

namespace FitnessClubManagement.Services
{
    public class AuthService
    {
        private List<User> users = new List<User>();

        public AuthService()
        {
            users.Add(new AdminUser("admin", "1234"));
        }

        public User Login(string username, string password)
        {
            return users.FirstOrDefault(u =>
                u.Username == username && u.Password == password);
        }
    }
}
