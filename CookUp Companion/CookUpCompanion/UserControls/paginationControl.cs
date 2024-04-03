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
    public partial class paginationControl : UserControl
    {
        // Make the PageIndexNumtb NumricUpDown public
        public NumericUpDown PageIndexNum => PageIndexNumtb;

        public event EventHandler PreviousClicked;
        public event EventHandler NextClicked;
        public event EventHandler GoToPageClicked;
        public paginationControl()
        {
            InitializeComponent();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // Raise PreviousClicked event
            PreviousClicked?.Invoke(sender, e);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Raise NextClicked event
            NextClicked?.Invoke(sender, e);
        }

        private void btnGoToCertainPage_Click(object sender, EventArgs e)
        {
            // Raise GoToPageClicked event
            GoToPageClicked?.Invoke(sender, e);
        }
    }
}
