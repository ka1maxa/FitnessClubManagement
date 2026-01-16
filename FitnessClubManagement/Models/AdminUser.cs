using FitnessClubManagement.Enums;

namespace FitnessClubManagement.Models
{
    public class AdminUser : User
    {
        public AdminUser(string username, string password)
            : base(username, password)
        {
            Role = UserRole.Admin;
        }
    }
}
