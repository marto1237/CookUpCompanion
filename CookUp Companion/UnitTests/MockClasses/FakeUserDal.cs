using InterfaceDAL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockClasses
{
    public class FakeUserDALManager : IUserDALManager
    {
        private Dictionary<int, User> users = new Dictionary<int, User>();
        private Dictionary<int, string> bannedUsers = new Dictionary<int, string>(); // Stores user IDs and their ban reasons
        private Dictionary<string, int> roles = new Dictionary<string, int>()
        {
            { "User", 1 },
            { "Moderator", 2 },
            { "Admin", 3 }
        };

        private int nextUserId = 1;

        public bool InsertUser(User newUser)
        {
            users[nextUserId] = newUser;
            nextUserId++;
            return true;
        }

        public bool CheckExistingUsername(string username)
        {
            return users.Values.Any(u => u.Username == username);
        }

        public bool CheckExistingEmail(string email)
        {
            return users.Values.Any(u => u.Email == email);
        }

        public User Login(string username, string password)
        {
            return users.Values.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public User GetUserByEmail(string email)
        {
            return users.Values.FirstOrDefault(u => u.Email == email);
        }

        public bool IsUserBanned(User bannedUser)
        {
            var bannedUserId = users.FirstOrDefault(u => u.Value == bannedUser).Key;
            return bannedUsers.ContainsKey(bannedUserId);
        }

        public bool BanUser(User banningUser, User bannedUser, string reason, int banLevel)
        {
            int bannedUserId = users.FirstOrDefault(u => u.Value == bannedUser).Key;
            if (bannedUserId > 0 && !bannedUsers.ContainsKey(bannedUserId))
            {
                bannedUsers[bannedUserId] = reason;
                return true;
            }
            return false;
        }

        public bool UnbanUser(int userID)
        {
            return bannedUsers.Remove(userID);
        }

        public string GetBanReason(int userID)
        {
            if (bannedUsers.TryGetValue(userID, out string reason))
            {
                return reason;
            }
            return null; // Return null if there is no ban reason found
        }

        public List<User> GetBannedUsers()
        {
            return bannedUsers.Keys.Select(id => users[id]).ToList();
        }

        public List<User> GetUsersBySimilarUsername(string username)
        {
            return users.Values.Where(u => u.Username.Contains(username)).ToList();
        }

        public List<User> GetUsersBySimilarEmail(string email)
        {
            return users.Values.Where(u => u.Email.Contains(email)).ToList();
        }

        public List<string> AllRoles()
        {
            return roles.Keys.ToList();
        }

        public int GetRoleIdByRoleName(string roleName)
        {
            return roles.FirstOrDefault(r => r.Key == roleName).Value;
        }

        public string GetRole(User user)
        {
            return roles.FirstOrDefault(r => r.Value == user.RoleId).Key;
        }

        public User GetUserById(int id)
        {
            users.TryGetValue(id, out User user);
            return user;
        }

        public bool UpdateUser(User user)
        {
            int userId = users.FirstOrDefault(u => u.Value.Email == user.Email).Key;
            if (userId != 0)
            {
                users[userId] = user;
                return true;
            }
            return false;
        }

        public bool UpdateUserPassword(User user, string newPassword)
        {
            int userId = users.FirstOrDefault(u => u.Value.Email == user.Email).Key;
            if (userId != 0)
            {
                User existingUser = users[userId];
                existingUser.ChangePassword(newPassword);
                return true;
            }
            return false;
        }

        public bool DeleteUser(int id)
        {
            return users.Remove(id);
        }
        public List<User> GetAllUsers()
        {
            return users.Values.ToList();
        }

        public bool UpdateUserPassword(User user)
        {
            int userId = GetIdByUsername(user.Username);
            if (userId != 0)
            {
                users[userId].ChangeFirstName(user.FirstName);
                return true;
            }
            return false;
        }
        public int GetIdByUsername(string username)
        {
            var user = users.FirstOrDefault(u => u.Value.Username == username);
            return user.Key; // Returns '0' if the user is not found, which is the default for Key when not found
        }
        public List<User> GetBySearch(string search)
        {
            return users.Values.Where(u => u.Username.Contains(search) || u.FirstName.Contains(search) || u.LastName.Contains(search)).ToList();
        }

        public (User, bool, string) GetUserAndBanInfo(string email)
        {
            User user = users.Values.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                int userId = users.FirstOrDefault(u => u.Value.Email == email).Key;
                bool isBanned = bannedUsers.ContainsKey(userId);
                string banReason = isBanned ? bannedUsers[userId] : null;
                return (user, isBanned, banReason);
            }
            return (null, false, null);
        }
    }
}
