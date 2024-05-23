using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL
{
    public interface IUserDALManager
    {
        bool InsertUser(User newUser);

        bool CheckExistingUsername(string username);

        bool CheckExistingEmail(string email);


        User Login(string username, string password);
        (User, bool, string) GetUserAndBanInfo(string email);
        User GetUserByEmail(string email);
        bool IsUserBanned(User bannedUser);

        string GetRole(User user);
        List<User> GetAllUsers();
        User GetUserById(int id);

        List<User> GetBySearch(string search);
        bool UpdateUser(User newUser);
        bool UpdateUserPassword(User user);
        bool DeleteUser(int id);
        int GetIdByUsername(string username);
        bool BanUser(User banningUser, User bannnedUser, string reason, int banLevel);
        List<User> GetBannedUsers();
        bool UnbanUser(int userID);
        string GetBanReason(int userID);

        List<User> GetUsersBySimilarUsername(string username);

        List<User> GetUsersBySimilarEmail(string email);

        List<string> AllRoles();
        int GetRoleIdByRoleName(string roleName);
    }

}
