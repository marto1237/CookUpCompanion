
using InterfacesLL;
using Logic;
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

namespace CookUpCompanion.Forms
{
    public partial class UnbanUser : Form
    {
        private readonly IUserManager userManager;
        private readonly string email;
        private readonly User user;
        public UnbanUser(IUserManager userManager, string _email)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.email = _email;
            user = userManager.GetUserByEmail(email);
            lbUserUsername.Text = user.Username;
        }

        private void btnUnban_Click(object sender, EventArgs e)
        {
            int userId = userManager.GetIdByUsername(user.Username);
            if (userId != -1) 
            {
                if (userManager.UnbanningUser(userId))
                {
                    MessageBox.Show($"The user {user.Username} has been unbanned succefully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Something went wrong");
                }
            }
            else
            {
                MessageBox.Show("User have not been founded");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
