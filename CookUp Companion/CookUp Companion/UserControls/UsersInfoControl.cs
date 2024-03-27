using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookUp_Companion.UserControls
{
    public partial class UsersInfoControl : UserControl
    {
        public UsersInfoControl()
        {
            InitializeComponent();
            MoreOptionsMenuMenu.Visible = false;
        }



        private void MoreOptions_Click_1(object sender, EventArgs e)
        {
            if (MoreOptionsMenuMenu.Visible == true)
            {
                MoreOptionsMenuMenu.Visible = false;
            }
            else
            {
                MoreOptionsMenuMenu.Visible = true;
            }
        }
    }
}
