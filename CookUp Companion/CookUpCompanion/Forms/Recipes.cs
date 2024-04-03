using CookUpCompanion.UserControls;
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
    public partial class Recipes : Form
    {
        public Recipes()
        {
            InitializeComponent();

            RecipeSearchBar recipeSearchBar = new RecipeSearchBar();
            // Add the UserInfoControl to the panel
            flowLayoutPanel1.Controls.Add(recipeSearchBar);

            var recipeControl = new RecipeControl();
            // Add the UserInfoControl to the panel
            flowLayoutPanel1.Controls.Add(recipeControl);


            populateRecipes();
        }

        public void populateRecipes()
        {
            RecipeControl[] listRecipes = new RecipeControl[20];

            for (int i = 0; i < listRecipes.Length; i++)
            {
                RecipeControl recipeControl = new RecipeControl();

                flowLayoutPanel1.Controls.Add(recipeControl);
            }
        }
    }
}
