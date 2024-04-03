using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfacesLL;
using Logic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CookUpCompanion.Forms
{
    public partial class ForgotPassword : Form
    {
        private readonly IUserManager userManager;
        public ForgotPassword(IUserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
        }

        private void lbReturnToLogin_Click(object sender, EventArgs e)
        {
            Form Login = new LogIn(userManager);
            Login.Show();
            this.Hide();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            string newPassword = tbNewPassword.Text;
            string confirmNewPassword = tbConfirmPassword.Text;

            if (email == "" ||  newPassword == "" || confirmNewPassword == "")
            {
                MessageBox.Show("Enter your email and the new password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("Make sure that the new password and the confirm password matches", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //check if there is user with that email
                    User user = userManager.GetUserByEmail(email);
                    if (user!= null)
                    {
                        user.ChangePassword(newPassword);
                        if (userManager.UpdateUserPassword(user, newPassword))
                        {
                            userManager.UpdateUser(user);
                        MessageBox.Show("Your password has been succesfully changed !");
                        }
                        
                        
                    }
                    else
                    {
                        MessageBox.Show("There is no user with that email !");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Your login details are incorrect!");
                }
            }

        }


    }
}
