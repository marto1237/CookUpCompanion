using CookUp_Companion.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookUp_Companion.Forms
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();

            var userInfoControl = new UsersInfoControl();
            // Add the UserInfoControl to the panel
            flpUsersInfo.Controls.Add(userInfoControl);

            populateUsers();
            
        }

        public void populateUsers()
        {
            UsersInfoControl[] listRecipes = new UsersInfoControl[20];

            for (int i = 0; i < listRecipes.Length; i++)
            {
                UsersInfoControl recipeControl = new UsersInfoControl();

                flpUsersInfo.Controls.Add(recipeControl);
            }
        }

    }
}
