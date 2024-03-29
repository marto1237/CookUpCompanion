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
        //bool BannedUser(User bannedUser);
        //User CheckUser(string email, string password);

        //List<User> GetAllUsers();

        //User GetUserById(int id);
        //List<User> GetBySearch(string search);
        //bool UpdateUser(User user);
        //void DeleteUser(int id);
        //void BanningUser(User bannedUser, string reason);
        //void UnbanningUser(User user);
        //bool EmailCheck(string email);
        //bool UsernameExists(string username);
        //bool EmailExists(string email);
        //List<User> Search(string search);
        //string GetReason(User banUser);

    }
}
