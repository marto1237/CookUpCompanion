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
    //public TextBox TbSearchUser => tbSearchRecipe;
    public partial class RecipeSearchBar : UserControl
    {

        public event EventHandler<string> SearchButtonClicked;

        public RecipeSearchBar()
        {
            InitializeComponent();
        }

        private void RecipeSearchBar_Load(object sender, EventArgs e)
        {
            tbSearchRecipe.Text = "Search recipe by name";
        }

        private void tbSearchRecipe_Enter(object sender, EventArgs e)
        {
            if (tbSearchRecipe.Text == "Search recipe by name")
            {
                tbSearchRecipe.Text = "";
            }
        }

        private void tbSearchRecipe_Leave(object sender, EventArgs e)
        {
            if (tbSearchRecipe.Text == "")
            {
                tbSearchRecipe.Text = "Search recipe by name";
            }
        }
        public void UpdateUserCount(string newCount)
        {
            lbNumRecipes.Text = newCount;
        }

        private void pSearchIcon_Click(object sender, EventArgs e)
        {
            string searchRecipe = tbSearchRecipe.Text;
            if (!string.IsNullOrEmpty(searchRecipe) && searchRecipe != "Search recipe by name")
            {
                SearchButtonClicked?.Invoke(this, searchRecipe);  // Trigger the event with the search text
            }
        }

        private void tbSearchRecipe_TextChanged(object sender, EventArgs e)
        {

        }
        public string GetSearchText()
        {
            return tbSearchRecipe.Text;
        }
    }
}
