using InterfaceDAL;
using InterfacesLL;
using Logic;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CookUp_Companion_BusinessLogic.Manager
{
    public class UserManager : IUserManager
    {
        private User currentUser;

        IUserDALManager controller;
        public UserManager(IUserDALManager controller)
        {
            this.controller = controller;
        }

        public User Login(string email, string password)
        {
            // Retrieve user from database
            User user = controller.GetUserByEmail(email);
            if (user != null && VerifyPassword(password, user.Password, user.PasswordSalt, 10000))
            {
                currentUser = user;
                return user;
            }

            return null;

        }
        public User CurrentUser()
        {
            return currentUser;
        }


        public bool CreateUser(User user)
        {
            // Generate salt and hash password
            byte[] salt = GenerateSalt();
            string hashedPassword = HashPassword(user.Password, salt, 10000);
            user.ChangePasswordSalt(Convert.ToBase64String(salt));
            user.ChangePassword(hashedPassword);

            return controller.InsertUser(user);
        }

        public bool CheckExistingUsername(string username)
        {
            return controller.CheckExistingUsername(username);
        }
        public bool CheckExistingEmail(string email)
        {
            return controller.CheckExistingEmail(email);
        }
        public User GetUserByEmail(string email)
        {
            return controller.GetUserByEmail(email);
        }
        public bool BannedUser(User banneduser)
        {
            if (controller.IsUserBanned(banneduser) == true)
            {
                return true;
            }
            return false;
        }
        public string GetRole(User user)
        {
            return controller.GetRole(user);
        }
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[16]; // You can adjust the salt length as needed
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public string HashPassword(string password, byte[] salt, int iterations)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return Convert.ToBase64String(pbkdf2.GetBytes(32)); // Generate a 256-bit (32-byte) hash
            }
        }

        private bool VerifyPassword(string password, string hashedPassword, string salt, int iterations)
        {
            // Convert the salt from string to byte array
            byte[] saltBytes = Convert.FromBase64String(salt);

            // Hash the provided password with the stored salt and compare it with the stored hashed password
            string inputHashedPassword = HashPassword(password, saltBytes, iterations);
            return inputHashedPassword == hashedPassword;
        }

        public List<User> GetAllUsers() { return controller.GetAllUsers(); }

        public User GetUserById(int id) { return controller.GetUserById(id); }

        public List<User> GetBySearch(string search) { return controller.GetBySearch(search); }

        public bool UpdateUser(User user) { return controller.UpdateUser(user); }

        public bool UpdateUserPassword(User user, string newPassword)
        {
            byte[] salt = Convert.FromBase64String(user.PasswordSalt);

            string hashedPassword = HashPassword(newPassword, salt, 10000);
            user.ChangePassword(hashedPassword);

            // Update user in the database
            return controller.UpdateUserPassword(user);

        }

        public bool DeleteUser(int id) { return controller.DeleteUser(id); }

        public int GetIdByUsername(string username) { return controller.GetIdByUsername(username); }

        public List<User> GetBannedUsers() { return controller.GetBannedUsers(); }
        public bool BanningUser(User banningUser, User bannedUser, string reason, int banLevel) { return controller.BanUser(banningUser, bannedUser, reason, banLevel); }

        public bool UnbanningUser(int userId) { return controller.UnbanUser(userId); }

        public string GetBanReason(int userID) { return controller.GetBanReason(userID); }

        public List<User> GetUsersBySimilarUsername(string username) { return controller.GetUsersBySimilarUsername(username); }

        public List<User> GetUsersBySimilarEmail(string email) { return controller.GetUsersBySimilarEmail(email); }

        public List<string> AllRoles() { return controller.AllRoles(); }

        public int GetRoleIdByRoleName(string roleName) { return controller.GetRoleIdByRoleName(roleName); }

    }
}
