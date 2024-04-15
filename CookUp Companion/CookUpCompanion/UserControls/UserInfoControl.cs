
using CookUpCompanion.Forms;
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

namespace CookUpCompanion.UserControls
{
    public partial class UsersInfoControl : UserControl
    {
        private readonly IUserManager userManager;
        public UsersInfoControl(IUserManager userManager)
        {
            InitializeComponent();
            MoreOptionsMenuMenu.Visible = false;
            this.userManager = userManager; 
        }



        private void MoreOptions_Click_1(object sender, EventArgs e)
        {
            if (MoreOptionsMenuMenu.Visible == true)
            {
                MoreOptionsMenuMenu.Visible = false;
            }
            else
            {
                MoreOptionsMenuMenu.Visible = true;
            }
        }

        public void UpdateBanButtonText(bool isBanned)
        {
            btnBanUser.Text = isBanned ? "Unban User" : "Ban User";
        }

        #region Properties

        private byte[] _userProfilePicture;
        private string _userName;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _role;

        private void btnMoreInfo_Click(object sender, EventArgs e)
        {
            UserMoreInfo userMoreInfo = new UserMoreInfo(userManager, _userProfilePicture, _userName, _firstName, _lastName , _email, _role);
            userMoreInfo.Show();
        }

        private void btnBanUser_Click(object sender, EventArgs e)
        {
            // Check if the user is banned
            if (userManager.BannedUser(userManager.GetUserByEmail(_email)))
            {
                // If the user is banned, show the UnbanUser form
                UnbanUser unbanUserForm = new UnbanUser(userManager, _email);
                unbanUserForm.Show();
            }
            else
            {
                // If the user is not banned, show the BanUser form
                BanUser banUserForm = new BanUser(userManager, _email, _firstName, _lastName);
                banUserForm.Show();
            }
        }

        private void btnChangeRole_Click(object sender, EventArgs e)
        {
            ChangeRole changeRole = new ChangeRole(userManager, _userName, _email);
            changeRole.Show();
        }

        [Category("UserData")]
        public byte[] UserProfilePicture
        {
            get { return _userProfilePicture; }
            set
            {
                _userProfilePicture = value;
                using (MemoryStream ms = new MemoryStream(value))
                {
                    ProfiliePicture.Image = Image.FromStream(ms);
                }
            }
        }

        [Category("UserData")]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; lbUsername.Text = value; }
        }

        [Category("UserData")]

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; lbFirstname.Text = value; }
        }

        [Category("UserData")]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; lbLastName.Text = value; }
        }

        [Category("UserData")]
        public string Email
        {
            get { return _email; }
            set { _email = value; lbEmail.Text = value; }
        }

        [Category("UserData")]
        public string Role
        {
            get { return _role; }
            set { _role = value; lbRole.Text = value; }
        }


        #endregion
    }
}
