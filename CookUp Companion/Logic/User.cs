using Logic;
using System.ComponentModel.DataAnnotations;

namespace CookUp_Companion_web.Models
{
    public class User
    {
        public byte[] ProfilePicture { get; private set; }

        public string Username { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Roles Role { get; private set; }
        public Preference Preferences { get; private set; }

        public User(byte[] profilePicture, string username, string email, string password, string firstName, string lastName, Roles role, Preference preferences)
        {
            ProfilePicture = profilePicture;
            Username = username;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Preferences = preferences;

        }

        public void ChangeProfilePicture(byte[] newProfilePicture)
        {
            ProfilePicture = newProfilePicture;
        }
        public void ChangeEmail(string email)
        {
            Email = email;
        }
        public void ChangePassword(string password)
        {
            Password = password;
        }
        public void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
        }
        public void ChangeLastName(string lastName)
        {
            LastName = lastName;
        }
        public void ChangeRole(Roles role)
        {
            Role = role;
        }
        
    }
}
