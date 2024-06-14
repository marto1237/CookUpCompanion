
using CookUp_Companion_BusinessLogic.Manager;
using CookUpCompanion.UserControls;
using DAL;
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
    public partial class MainForm : Form
    {
        private readonly IUserManager userManager;
        private readonly IRecipeManager recipeManager;
        public MainForm(User user, LogIn login, IUserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;

            recipeManager = new RecipeManager(new RecipeDal(userManager));
            // Load user's profile picture
            if (user.ProfilePicture != null && user.ProfilePicture.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(user.ProfilePicture))
                {
                    ProfiliePicture.Image = Image.FromStream(ms);
                }
            }
            btnUsername.Text = user.Username;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserDropMenu.Visible = false;

        }
        private void btnUsername_Click_1(object sender, EventArgs e)
        {
            UserDropMenu.Visible = true;
            if (UserDropMenu.Height == 143)
            {
                UserDropMenu.Height = 0;
            }
            else
            {
                UserDropMenu.Height = 110;
            }

        }
        private void btnProfile_Click(object sender, EventArgs e)
        {
            // Clear the panel
            MainPanel.Controls.Clear();

            // Create an instance of the account UserControl
            AccountControl accountInfo = new AccountControl();

            // Add the UserControl to the panel
            MainPanel.Controls.Add(accountInfo);
            accountInfo.Dock = DockStyle.Fill;
        }

        private void btnSetting_Click_1(object sender, EventArgs e)
        {
            // Clear the panel
            MainPanel.Controls.Clear();

            // Create an instance of the setting
            Settings settings = new Settings();

            // Add the Setting to the panel
            MainPanel.Controls.Add(settings);
            settings.Dock = DockStyle.Fill;
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();

            // Create an instance of the Users form
            Users usersForm = new Users(userManager);
            usersForm.TopLevel = false;

            // Add the Users form to the panel
            MainPanel.Controls.Add(usersForm);
            usersForm.Dock = DockStyle.Fill;

            usersForm.Show();
        }

        private void btnRecipes_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();

            // Create an instance of the Users form
            Recipes recipeForm = new Recipes(recipeManager);
            recipeForm.TopLevel = false;

            // Add the Users form to the panel
            MainPanel.Controls.Add(recipeForm);
            recipeForm.Dock = DockStyle.Fill;

            recipeForm.Show();
        }

        private void UserPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
