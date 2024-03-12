using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookUp_Companion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserDropMenu.Visible = false;
            ProfiliePicture.Visible = false;

        }
        private void btnUsername_Click_1(object sender, EventArgs e)
        {
            if (UserDropMenu.Height == 155)
            {
                UserDropMenu.Height = 38;
            }
            else
            {
                UserDropMenu.Height = 155;
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
            UserDropMenu.Visible = false;
            ProfiliePicture.Visible = false;
            btnLogin.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Visible = false;
            ProfiliePicture.Visible = true;
            UserDropMenu.Height = 38;
            UserDropMenu.Visible=true;
        }
    }


}
