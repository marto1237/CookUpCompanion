using BusinessLogic;
using CookUpCompanion.UserControls;
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

namespace CookUpCompanion.Forms
{
    public partial class Users : Form
    {
        private readonly IUserManager userManager;

        //pagination
        private int currentPage = 1;
        private int usersPerPage = 1; // Change this value as needed

        public Users(IUserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            userSearchBar1.CbTypeOfUser.SelectedIndex = 0;

            // Subscribe to the SelectedIndexChanged event
            userSearchBar1.SelectedIndexChanged += userSearchBar1_SelectedIndexChanged;

            // Subscribe to the pagination control's events
            paginationControl1.PreviousClicked += paginationControl1_btnPrevious_Click;
            paginationControl1.NextClicked += paginationControl1_btnNext_Click;
            paginationControl1.GoToPageClicked += paginationControl1_btnGoToCertainPage_Click;


        }

        private void Users_Load(object sender, EventArgs e)
        {
            populateUsers();
        }

        public void populateUsers()
        {
            flpUsersInfo.Controls.Clear();
            int startIndex = (currentPage - 1) * usersPerPage;
            List<User> users = userManager.GetAllUsers().Skip(startIndex).Take(usersPerPage).ToList();

            if (users.Count > 0)
            {
                foreach (User user in users)
                {
                    UsersInfoControl usersInfoControl = new UsersInfoControl();

                    usersInfoControl.UserProfilePicture = user.ProfilePicture;
                    usersInfoControl.UserName = user.Username;
                    usersInfoControl.FirstName = user.FirstName;
                    usersInfoControl.LastName = user.LastName;
                    usersInfoControl.Email = user.Email;
                    usersInfoControl.Role = userManager.GetRole(user);

                    flpUsersInfo.Controls.Add(usersInfoControl);
                }

                userSearchBar1.UpdateUserCount($"Users({users.Count})");
            }

        }

        public void populateBannedUsers()
        {
            flpUsersInfo.Controls.Clear();
            int startIndex = (currentPage - 1) * usersPerPage;
            List<User> users = userManager.GetBannedUsers().Skip(startIndex).Take(usersPerPage).ToList();
            if (users.Count > 0)
            {
                foreach (User user in users)
                {
                    UsersInfoControl usersInfoControl = new UsersInfoControl();

                    usersInfoControl.UserProfilePicture = user.ProfilePicture;
                    usersInfoControl.UserName = user.Username;
                    usersInfoControl.FirstName = user.FirstName;
                    usersInfoControl.LastName = user.LastName;
                    usersInfoControl.Email = user.Email;
                    usersInfoControl.Role = userManager.GetRole(user);

                    flpUsersInfo.Controls.Add(usersInfoControl);
                }
                userSearchBar1.UpdateUserCount($"Users({users.Count})");
            }
            else
            {
                MessageBox.Show("There are not banned users yet");
                userSearchBar1.UpdateUserCount($"Users(0)");
            }
        }

        private void userSearchBar1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected index
            int selectedIndex = userSearchBar1.CbTypeOfUser.SelectedIndex;

            // Check which option is selected
            if (selectedIndex == 0) // All Users
            {

                populateUsers();
            }
            else if (selectedIndex == 1) // Banned Users
            {
                populateBannedUsers();
            }


        }

        private void paginationControl1_btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                if(userSearchBar1.CbTypeOfUser.SelectedItem == "All Users")
                {
                    populateUsers();
                }else if (userSearchBar1.CbTypeOfUser.SelectedItem == "Banned Users")
                {
                    populateBannedUsers();
                }
            }
        }

        private void paginationControl1_btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            if (userSearchBar1.CbTypeOfUser.SelectedItem == "All Users")
            {
                populateUsers();
            }
            else if (userSearchBar1.CbTypeOfUser.SelectedItem == "Banned Users")
            {
                populateBannedUsers();
            }
        }

        private void paginationControl1_btnGoToCertainPage_Click(object sender, EventArgs e)
        {
            int pageNumber = Convert.ToInt32(paginationControl1.PageIndexNum.Value);
            currentPage = pageNumber;
            if (userSearchBar1.CbTypeOfUser.SelectedItem == "All Users")
            {
                populateUsers();
            }
            else if (userSearchBar1.CbTypeOfUser.SelectedItem == "Banned Users")
            {
                populateBannedUsers();
            }
        }

    }
}
