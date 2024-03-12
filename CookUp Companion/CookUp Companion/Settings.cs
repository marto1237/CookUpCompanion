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
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            AccountControl account = new AccountControl();
            // Add the Account to the panel
            Controls.Add(account);
            account.Dock = DockStyle.Fill;
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            SettingAccount settingaccount = new SettingAccount();
            //Add the SettingAccount to the panel 
            Controls.Add(settingaccount);
            settingaccount.Dock = DockStyle.Fill;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            EditProfile editProfile = new EditProfile();
            //Add the editProfile to the panel
            Controls.Add(editProfile);
            editProfile.Dock = DockStyle.Fill;
        }
    }
}
