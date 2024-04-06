using BusinessLogic;
using InterfacesLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CookUpCompanion.Forms
{
    public partial class UserMoreInfo : Form
    {
        private readonly IUserManager userManager;
        public UserMoreInfo(IUserManager userManager, byte[] userProfilePicture, string userName, string firstName, string lastName, string email, string role)
        {
            InitializeComponent();
            this.userManager = userManager;
            using (MemoryStream ms = new MemoryStream(userProfilePicture))
            {
                pbUserProfile.Image = Image.FromStream(ms);
            }
            lbUsername.Text = userName;
            lbFirstName.Text = firstName;
            lbLastName.Text = lastName;
            lbUserEmail.Text = email;
            lbUserRole.Text = role;
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        { 

            int userID = userManager.GetIdByUsername(lbUsername.Text);
            bool IsAccounDeleted = userManager.DeleteUser(userID);
            if (IsAccounDeleted)
            {
                MessageBox.Show("User have been deleted successfully");
            }
            else
            {
                MessageBox.Show("Something when wrong");
            }
        }

        private void lbUserRecipes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lbUserComments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
