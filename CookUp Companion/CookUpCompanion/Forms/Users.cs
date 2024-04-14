
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
        private int usersPerPage = 10; // Change this value as needed

        public Users(IUserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            InitializeEventHandlers();
            userSearchBar1.CbTypeOfUser.SelectedIndex = 0;

        }
        // Methods
        private void InitializeEventHandlers()
        {
            // Subscribe to the SelectedIndexChanged event
            userSearchBar1.SelectedIndexChanged += userSearchBar1_SelectedIndexChanged;

            // Subscribe to the search button clicked event
            userSearchBar1.SearchButtonClicked += userSearchBar1_SearchButtonClicked;

            // Subscribe to the pagination control's events
            paginationControl1.PreviousClicked += paginationControl1_btnPrevious_Click;
            paginationControl1.NextClicked += paginationControl1_btnNext_Click;
            paginationControl1.GoToPageClicked += paginationControl1_btnGoToCertainPage_Click;
        }

        private void Users_Load(object sender, EventArgs e)
        {
            populateUsers();
    
            UpdatePageIndexNum();
        }

        public void populateUsers()
        {
            flpUsersInfo.Controls.Clear();
            int startIndex = (currentPage - 1) * usersPerPage;
            List<User> users = userManager.GetAllUsers().Skip(startIndex).Take(usersPerPage).ToList();

            if (ListeUsers(users) == false)
            {
                MessageBox.Show("There are no more users yet");
                userSearchBar1.UpdateUserCount($"Users(0)");
            }

        }

        public void populateBannedUsers()
        {
            flpUsersInfo.Controls.Clear();
            int startIndex = (currentPage - 1) * usersPerPage;
            List<User> users = userManager.GetBannedUsers().Skip(startIndex).Take(usersPerPage).ToList();
            if (ListeUsers(users) == false)
            {
                MessageBox.Show("There are no more banned users yet");
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
                UpdatePageIndexNum();
                if (userSearchBar1.CbTypeOfUser.SelectedItem == "All Users")
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
            UpdatePageIndexNum();
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

        private void UpdatePageIndexNum()
        {
            paginationControl1.PageIndexNum.Value = currentPage;
        }
        private void userSearchBar1_SearchButtonClicked(object sender, string searchText)
        {
            if (userSearchBar1.CbTypeOfUser.SelectedItem == "All Users")
            {
                flpUsersInfo.Controls.Clear();
                int startIndex = (currentPage - 1) * usersPerPage;

                // Search for users by username
                List<User> similarUsernameUsers = userManager.GetUsersBySimilarUsername(searchText);
                List<User> users = new List<User>(similarUsernameUsers);

                // Search for users by email
                List<User> similarEmailUsers = userManager.GetUsersBySimilarEmail(searchText);

                // Add users from email search that are not already in the list
                foreach (var user in similarEmailUsers)
                {
                    if (!similarUsernameUsers.Any(u => u.Username == user.Username))
                    {
                        users.Add(user);
                    }
                }

                if (ListeUsers(users) == false)
                {
                    MessageBox.Show("There are no matches with that username or email in users ");
                    userSearchBar1.UpdateUserCount($"Users(0)");
                }
            }
            else if (userSearchBar1.CbTypeOfUser.SelectedItem == "Banned Users")
            {
                flpUsersInfo.Controls.Clear();
                int startIndex = (currentPage - 1) * usersPerPage;

                // Search for banned users by username
                List<User> similarUsernameUsers = userManager.GetUsersBySimilarUsername(searchText);
                List<User> users = new List<User>(similarUsernameUsers);

                // Search for banned users by email
                List<User> similarEmailUsers = userManager.GetUsersBySimilarEmail(searchText);

                // Add users from email search that are not already in the list
                foreach (var user in similarEmailUsers)
                {
                    if (!similarUsernameUsers.Any(u => u.Username == user.Username))
                    {
                        users.Add(user);
                    }
                }

                if (ListeUsers(users) == false)
                {
                    MessageBox.Show("There are no matches with that username or email in banned users ");
                    userSearchBar1.UpdateUserCount($"Users(0)");
                }

            }

        }

        public bool ListeUsers(List<User> users)
        {
            flpUsersInfo.Controls.Clear();
            int startIndex = (currentPage - 1) * usersPerPage;
            users = users.Skip(startIndex).Take(usersPerPage).ToList();
            if (users.Count > 0)
            {
                foreach (User user in users)
                {

                    UsersInfoControl usersInfoControl = new UsersInfoControl(userManager);

                    // Determine if the user is banned
                    bool isBanned = userManager.BannedUser(user);

                    // Update the ban button text
                    usersInfoControl.UpdateBanButtonText(isBanned);

                    usersInfoControl.UserProfilePicture = user.ProfilePicture;
                    usersInfoControl.UserName = user.Username;
                    usersInfoControl.FirstName = user.FirstName;
                    usersInfoControl.LastName = user.LastName;
                    usersInfoControl.Email = user.Email;
                    usersInfoControl.Role = userManager.GetRole(user);

                    flpUsersInfo.Controls.Add(usersInfoControl);
                }

                userSearchBar1.UpdateUserCount($"Users({users.Count})");

                return true;
            }
            return false;
        }
    }
}
