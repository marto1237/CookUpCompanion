
using System.Security.Cryptography;
using System.IO;


namespace Logic
{
    public class User
    {
        public byte[] ProfilePicture { get; private set; }

        public string Username { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }
        public string PasswordSalt { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int RoleId { get; private set; }
        public Preference Preferences { get; private set; }

        public User(byte[] profilePicture, string username, string email, string password, string firstName, string lastName, int roleId, Preference preferences)
        {
            ProfilePicture = profilePicture;
            Username = username;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            RoleId = roleId;
            Preferences = preferences;

 

        }

        public void ChangeProfilePicture(byte[] newProfilePicture)
        {
            ProfilePicture = newProfilePicture;
        }
        public void ChangeUsername(string username)
        {
            Username = username;
        }
        public void ChangeEmail(string email)
        {
            Email = email;
        }
        public void ChangePassword(string password)
        {
            Password = password;
        }
        public void ChangePasswordSalt(string salt)
        {
            PasswordSalt = salt;
        }
        public void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
        }
        public void ChangeLastName(string lastName)
        {
            LastName = lastName;
        }
        public void ChangeRole(int roleID)
        {
            RoleId = roleID;
        }

        public void GetSaltForDb(string passwordSalt)
        {
            PasswordSalt = passwordSalt;
        }


        
	}
}
