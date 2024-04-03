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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CookUpCompanion.Forms
{
    public partial class LogIn : Form
    {
        private readonly IUserManager userManager;
        public LogIn(IUserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = tbEmail.Text;
            string password = tbPassword.Text;
            if (username == "" & password == "")
            {
                MessageBox.Show("Enter your username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (password == "")
            {
                MessageBox.Show("Enter your password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (username == "")
            {
                MessageBox.Show("Enter your username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //check the user credential and the role load the mainform
                    User user = userManager.Login(username, password);
                    if (user.RoleId == 3)
                    {
                        Form mainForm = new MainForm(user, this, userManager);
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("You do not have access!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Your login details are incorrect!");
                }
            }


            

        }

        private void lbForgotPassword_Click(object sender, EventArgs e)
        {
            //Form forgotPassword = new ForgotPassword();
            //forgotPassword.Show();
            //this.Hide();
            this.Hide();
            var forgotPassword = new ForgotPassword(userManager);
            forgotPassword.Closed += (s, args) => this.Close();
            forgotPassword.Show();
        }

        private void revealPassword_MouseDown(object sender, MouseEventArgs e)
        {
            tbPassword.PasswordChar = '\0';
        }

        private void revealPassword_MouseUp(object sender, MouseEventArgs e)
        {
            tbPassword.PasswordChar = '●';
        }
    }
}
