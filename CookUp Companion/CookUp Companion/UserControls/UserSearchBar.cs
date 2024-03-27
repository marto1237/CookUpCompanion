using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookUp_Companion.UserControls
{
    public partial class UserSearchBar : UserControl
    {
        public UserSearchBar()
        {
            InitializeComponent();
        }

        private void UserSearchBar_Load(object sender, EventArgs e)
        {
            tbSearchUser.Text = "Search by username or email";
        }

        private void UserSearchBar_Enter(object sender, EventArgs e)
        {
            if(tbSearchUser.Text == "Search by username or email")
            {
                tbSearchUser.Text = "";
            }
        }

        private void UserSearchBar_Leave(object sender, EventArgs e)
        {
            if (tbSearchUser.Text == "")
            {
                tbSearchUser.Text = "Search by username or email";
            }
        }
    }
}
