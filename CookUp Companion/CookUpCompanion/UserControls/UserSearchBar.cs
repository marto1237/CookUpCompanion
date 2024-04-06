using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookUpCompanion.UserControls
{
    public partial class UserSearchBar : UserControl
    {
        // Make the ComboBox public
        public ComboBox CbTypeOfUser => cbTypeOfUser;
        public event EventHandler SelectedIndexChanged;
        public event EventHandler<string> SearchButtonClicked;

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
            if (tbSearchUser.Text == "Search by username or email")
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

        private void cbTypeOfUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }
        public void UpdateUserCount(string newCount)
        {
            lbNumUser.Text = newCount;
        }

        private void pSearchIcon_Click(object sender, EventArgs e)
        {
            string searchUser = tbSearchUser.Text;
            SearchButtonClicked?.Invoke(this, searchUser);
        }
    }
}
