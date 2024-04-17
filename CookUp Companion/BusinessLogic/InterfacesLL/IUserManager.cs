using Logic;

namespace InterfacesLL
{
    public interface IUserManager
    {
        bool CreateUser(User user);
        bool CheckExistingUsername(string username);
        bool CheckExistingEmail(string email);
        User Login(string email, string password);
        User GetUserByEmail(string email);
        string GetRole(User user);
        User CurrentUser();
        bool BannedUser(User bannedUser);
        List<User> GetAllUsers();
        User GetUserById(int id);
        List<User> GetBySearch(string search);
        bool UpdateUser(User user);
        bool UpdateUserPassword(User user, string password);
        bool DeleteUser(int id);
        int GetIdByUsername(string username);
        List<User> GetBannedUsers();
        string GetBanReason(int userID);
        bool BanningUser(User banningUser, User bannedUser, string reason, int banLevel);
        bool UnbanningUser(int userId);
        List<User> GetUsersBySimilarEmail(string email);
        List<User> GetUsersBySimilarUsername(string username);
        List<string> AllRoles();
        int GetRoleIdByRoleName(string roleName);
        

    }
}
