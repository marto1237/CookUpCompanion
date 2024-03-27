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


            
        public bool CreateUser(User user)
        {
            return controller.InsertUser(user);
        }



    }
}
