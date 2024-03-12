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
    public partial class AccountControl : UserControl
    {
        public AccountControl()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.Anchor = AnchorStyles.None;
            // Set up scrollbar properties
            vScrollBar1.Minimum = 0;
            vScrollBar1.Maximum = pAccount.VerticalScroll.Maximum;
            vScrollBar1.LargeChange = pAccount.VerticalScroll.LargeChange;

            // Handle Scroll event
            vScrollBar1.Scroll += vScrollBar1_Scroll;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Adjust the vertical scroll of the Panel
            pAccount.VerticalScroll.Value = e.NewValue;
        }

        private void btnEditPrifile_Click(object sender, EventArgs e)
        {
            pAccount.Controls.Clear();
            // Create an instance of the editProfileControl
            EditProfile profile = new EditProfile();
            // Add the UserControl to the panel
            pAccount.Controls.Add(profile);
            profile.Dock = DockStyle.Fill;
            

        }
    }
}
