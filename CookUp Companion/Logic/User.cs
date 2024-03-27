
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

			PasswordSalt = "";// Initialize the salt
			SetPassword(password); // Hash and salt the password

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
        public void ChangeRole(int roleID)
        {
            RoleId = roleID;
        }

		public void SetPassword(string password)
		{
			// Generate a unique salt
			byte[] salt = GenerateSalt();

			// Hash the password with the salt using PBKDF2 with 10000 iterations
			byte[] hashedPassword = HashPassword(password, salt, 10000); 

			// Convert the hashed password and salt to base64 strings
			string hashedPasswordBase64 = Convert.ToBase64String(hashedPassword);
			string saltBase64 = Convert.ToBase64String(salt);

			// Store the hashed password and salt
			Password = hashedPasswordBase64;
			// Store the salt along with the password
			PasswordSalt = saltBase64;
		}

		private byte[] GenerateSalt()
		{
			byte[] salt = new byte[16]; // You can adjust the salt length as needed
			using (var rng = new RNGCryptoServiceProvider())
			{
				rng.GetBytes(salt);
			}
			return salt;
		}

		private byte[] HashPassword(string password, byte[] salt, int iterations)
		{
			using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
			{
				return pbkdf2.GetBytes(32); // Generate a 256-bit (32-byte) hash
			}
		}
	}
}
