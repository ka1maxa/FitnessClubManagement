using FitnessClubManagement.Enums;

namespace FitnessClubManagement.Models
{
    public abstract class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; protected set; }

        protected User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
