using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookUp_Companion.Forms
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
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

        
    }
}
