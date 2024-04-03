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
        bool BannedUser(User bannedUser);
        List<User> GetAllUsers();
        User GetUserById(int id);
        List<User> GetBySearch(string search);
        bool UpdateUser(User user);
        bool UpdateUserPassword(User user, string password);
        bool DeleteUser(int id);
        int GetIdByUsername(string username);

        List<User> GetBannedUsers();

        bool BanningUser(User banningUser, User bannedUser, string reason);
        bool UnbanningUser(int userId);
        string GetReason(int userID);

    }
}
