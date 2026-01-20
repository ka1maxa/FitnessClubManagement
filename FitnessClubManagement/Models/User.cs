using FitnessClubManagement.Enums;

namespace FitnessClubManagement.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public FitnessClubManagement.Enums.UserRole Role { get; set; }
    }
}
