using CookUpCompanion.UserControls;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CookUpCompanion.Forms
{
    public partial class Users : Form
    {
        private readonly IUserManager userManager;

        // Pagination
        private int currentPage = 1;
        private int usersPerPage = 2; // Change this value as needed

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
            PopulateUsers();
            UpdatePageIndexNum();
        }

        public void PopulateUsers()
        {
            flpUsersInfo.Controls.Clear();
            int startIndex = (currentPage - 1) * usersPerPage;
            List<User> users = userManager.GetAllUsers().Skip(startIndex).Take(usersPerPage).ToList();

            if (!ListUsers(users))
            {
                MessageBox.Show("There are no more users yet");
                userSearchBar1.UpdateUserCount($"Users(0)");
            }
        }

        public void PopulateBannedUsers()
        {
            flpUsersInfo.Controls.Clear();
            int startIndex = (currentPage - 1) * usersPerPage;
            List<User> users = userManager.GetBannedUsers().Skip(startIndex).Take(usersPerPage).ToList();
            if (!ListUsers(users))
            {
                MessageBox.Show("There are no more banned users yet");
                userSearchBar1.UpdateUserCount($"Users(0)");
            }
        }

        private void userSearchBar1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = userSearchBar1.CbTypeOfUser.SelectedIndex;

            if (selectedIndex == 0) // All Users
            {
                PopulateUsers();
            }
            else if (selectedIndex == 1) // Banned Users
            {
                PopulateBannedUsers();
            }
        }

        private void paginationControl1_btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                UpdatePageIndexNum();
                if (userSearchBar1.CbTypeOfUser.SelectedItem.ToString() == "All Users")
                {
                    PopulateUsers();
                }
                else if (userSearchBar1.CbTypeOfUser.SelectedItem.ToString() == "Banned Users")
                {
                    PopulateBannedUsers();
                }
            }
        }

        private void paginationControl1_btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            UpdatePageIndexNum();
            if (userSearchBar1.CbTypeOfUser.SelectedItem.ToString() == "All Users")
            {
                PopulateUsers();
            }
            else if (userSearchBar1.CbTypeOfUser.SelectedItem.ToString() == "Banned Users")
            {
                PopulateBannedUsers();
            }
        }

        private void paginationControl1_btnGoToCertainPage_Click(object sender, EventArgs e)
        {
            int pageNumber = Convert.ToInt32(paginationControl1.PageIndexNum.Value);
            currentPage = pageNumber;
            if (userSearchBar1.CbTypeOfUser.SelectedItem.ToString() == "All Users")
            {
                PopulateUsers();
            }
            else if (userSearchBar1.CbTypeOfUser.SelectedItem.ToString() == "Banned Users")
            {
                PopulateBannedUsers();
            }
        }

        private void UpdatePageIndexNum()
        {
            paginationControl1.PageIndexNum.Value = currentPage;
        }

        private void userSearchBar1_SearchButtonClicked(object sender, string searchText)
        {
            if (userSearchBar1.CbTypeOfUser.SelectedItem.ToString() == "All Users")
            {
                flpUsersInfo.Controls.Clear();
                int startIndex = (currentPage - 1) * usersPerPage;

                List<User> similarUsernameUsers = userManager.GetUsersBySimilarUsername(searchText);
                List<User> users = new List<User>(similarUsernameUsers);

                List<User> similarEmailUsers = userManager.GetUsersBySimilarEmail(searchText);

                foreach (var user in similarEmailUsers)
                {
                    if (!similarUsernameUsers.Any(u => u.Username == user.Username))
                    {
                        users.Add(user);
                    }
                }

                if (!ListUsers(users))
                {
                    MessageBox.Show("There are no matches with that username or email in users");
                    userSearchBar1.UpdateUserCount($"Users(0)");
                }
            }
            else if (userSearchBar1.CbTypeOfUser.SelectedItem.ToString() == "Banned Users")
            {
                flpUsersInfo.Controls.Clear();
                int startIndex = (currentPage - 1) * usersPerPage;

                List<User> similarUsernameUsers = userManager.GetUsersBySimilarUsername(searchText);
                List<User> users = new List<User>(similarUsernameUsers);

                List<User> similarEmailUsers = userManager.GetUsersBySimilarEmail(searchText);

                foreach (var user in similarEmailUsers)
                {
                    if (!similarUsernameUsers.Any(u => u.Username == user.Username))
                    {
                        users.Add(user);
                    }
                }

                if (!ListUsers(users))
                {
                    MessageBox.Show("There are no matches with that username or email in banned users");
                    userSearchBar1.UpdateUserCount($"Users(0)");
                }
            }
        }

        public bool ListUsers(List<User> users)
        {
            flpUsersInfo.Controls.Clear();

            if (users.Count > 0)
            {
                foreach (User user in users)
                {
                    UsersInfoControl usersInfoControl = new UsersInfoControl(userManager);

                    bool isBanned = userManager.BannedUser(user);

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
