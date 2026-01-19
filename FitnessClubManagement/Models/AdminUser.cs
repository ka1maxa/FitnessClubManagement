using FitnessClubManagement.Enums;

namespace FitnessClubManagement.Models
{
    public class AdminUser : User
    {
        public AdminUser(string username, string password)
        {
            Username = username;
            Password = password;
            Role = UserRole.Admin;
        }
    }
}
