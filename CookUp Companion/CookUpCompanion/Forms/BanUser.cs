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
    public partial class BanUser : Form
    {
        private readonly IUserManager userManager;
        private readonly string email;
        private int banLevel;

        public BanUser(IUserManager userManager, string email, string firstName, string lastame)
        {
            InitializeComponent();
            this.email = email;
            this.userManager = userManager;
            lbUserNames.Text = $"{firstName} {lastame}";
        }

        private void rbInappropriateBehavior_CheckedChanged(object sender, EventArgs e)
        {
            banLevel = 1;
        }

        private void rbContentBan_CheckedChanged(object sender, EventArgs e)
        {
            banLevel = 2;
        }

        private void rBAccountSuspension_CheckedChanged(object sender, EventArgs e)
        {
            banLevel = 3;
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            User banningUser = userManager.CurrentUser();
            User bannedUser = userManager.GetUserByEmail(email);
            string reason = rtbReason.Text;

            bool success = userManager.BanningUser(banningUser, bannedUser, reason, banLevel);
            if (success)
            {
                MessageBox.Show("User banned successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to ban user.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
