using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace CookUp_Companion.Models
{
    public class UserControl
    {
        UserControl() { }

        public void SignUp(byte[] profilePicture, string username, string email, string password, string firstName, string lastName, Roles role)
        {
            User newUser = new User(profilePicture, username, email, password, firstName, lastName, role);
        }

        public bool LogIn(string email, string password)
        {
            // Check credentials and perform login
            return true;
        }

        public void PromoteUser(string email) 
        {
            
        }
        public void DemoteUser(string email)
        {

        }

        public void DeleteUser(string email)
        {

        }
        public bool ChangePassword(string email ,string newpassword) 
        {
            //Connect it to the database
            return true;
        }


    }
}
