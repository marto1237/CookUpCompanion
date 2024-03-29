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
        User GetUserByEmail(string email);

        //List<User> GetAll();
        //User GetUserById(int id);

        //bool UpdateUser(User newUser);
        //void DeleteUser(int id);
        //void BanUser(User banUser, string reason);
        //void UnbanUser(User bannedUser);
        //bool IsUserBanned(User bannedUser);
        //bool ExistingUsername(string username);
        //bool ExistingEmail(string email);
        //List<User> GetSearch(string search);
        //public string GetBanReason(User banUser);
    }

}
