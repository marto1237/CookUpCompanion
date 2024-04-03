using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookUpCompanion.UserControls
{
    public partial class SettingAccount : UserControl
    {
        public SettingAccount()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            Settings settings = new Settings();
            // Add the Setting to the panel
            Controls.Add(settings);
            settings.Dock = DockStyle.Fill;
        }
    }
}
