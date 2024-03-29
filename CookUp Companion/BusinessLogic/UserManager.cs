using InterfaceDAL;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserManager : IUserManager
    {

        IUserDALManager controller;
        public UserManager(IUserDALManager controller)
        {
            this.controller = controller;
        }

        public User Login(string email, string password)
        {
            return controller.Login(email, password);
        }
        
        public bool CreateUser(User user)
        {
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



    }
}
