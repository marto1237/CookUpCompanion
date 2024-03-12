using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookUp_Companion
{
    public partial class EditProfile : UserControl
    {
        public EditProfile()
        {
            InitializeComponent();
        }


        private void tbFirstName_Click(object sender, EventArgs e)
        {
            if (tbFirstName.Text == "First Name")
            {
                tbFirstName.Text = "";
            }
            
        }

        private void tbFamillyName_Click(object sender, EventArgs e)
        {
            if(tbFamillyName.Text == "FamillyName")
            {
                tbFamillyName.Text = "";
            }
        }

        private void tbUsername_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "Username")
            {
                tbUsername.Text = "";
            }
        }

        private void rtbBio_Click(object sender, EventArgs e)
        {
            if (rtbBio.Text == "Bio")
            {
                rtbBio.Text = "";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            AccountControl account = new AccountControl();
            // Add the UserControl to the panel
            Controls.Add(account);
            account.Dock = DockStyle.Fill;

        }
    }
}
