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

    public partial class ChangeRole : Form
    {
        private readonly IUserManager userManager;
        private readonly string username;
        private readonly string email;
        private readonly string originalRole;
        private User user;
        public ChangeRole(IUserManager userManager, string username, string email)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.username = username;
            this.email = email;
            cbRoles.DataSource = userManager.AllRoles();
            user = userManager.GetUserByEmail(email);
            originalRole = userManager.GetRole(user);
            cbRoles.SelectedItem = originalRole;
            lbUsername.Text = username;
            this.email = email;
        }

        private void btnUpdateRole_Click(object sender, EventArgs e)
        {
            if (cbRoles.SelectedItem != null && cbRoles.SelectedItem != originalRole) 
            {
                string selectedRoleName = cbRoles.SelectedItem.ToString();
                int roleId = userManager.GetRoleIdByRoleName(selectedRoleName);
                user.ChangeRole(roleId);
                userManager.UpdateUser(user);
                MessageBox.Show("Yeas");
            }
        }
    }
}
