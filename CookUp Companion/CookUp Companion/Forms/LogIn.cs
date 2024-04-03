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

namespace CookUp_Companion.Forms
{
    public partial class LogIn : Form
    {
        private readonly IUserManager userManager;
        public LogIn()
        {
            InitializeComponent();
            this.userManager = userManager;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username;
            //check the user credential and the role load the mainform
            Form mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void lbForgotPassword_Click(object sender, EventArgs e)
        {
            //Form forgotPassword = new ForgotPassword();
            //forgotPassword.Show();
            //this.Hide();
            this.Hide();
            var forgotPassword = new ForgotPassword();
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
