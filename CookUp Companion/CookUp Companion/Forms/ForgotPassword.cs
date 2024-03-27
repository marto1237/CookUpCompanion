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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void lbReturnToLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            Form Login = new LogIn();
            Login.Show();
            this.Hide();
        }


    }
}
