using CookUp_Companion_BusinessLogic.Manager;
using CookUpCompanion.UserControls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CookUpCompanion.Forms
{
    public partial class RecipeMoreInfo : Form
    {
        private readonly IRecipeManager recipeManager;
        private readonly string recipeName;
        private readonly string creatorName;
        private readonly Recipe recipe;
        public RecipeMoreInfo(IRecipeManager recipeManager , string recipeName, string creatorName)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;
            this.recipeName = recipeName;
            this.creatorName = creatorName;

            recipe = recipeManager.GetRecipeByNameAndCreator(recipeName, creatorName);
            using (MemoryStream ms = new MemoryStream(recipe.Picture))
            {
                pbRecipePicture.Image = Image.FromStream(ms);
            }
            lbCreator.Text = recipe.Creator.Username;
            lbRecipeName.Text = recipe.RecipeName;
            rtbDescription.Text = recipe.Description;
            rtbInstructions.Text = recipe.Instructions;

            foreach(Ingredient ingredient in recipe.Ingredients)
            {
                IngredientInfo ingredientInfo = new IngredientInfo();

                ingredientInfo.IngredientPicture = ingredient.IngredientPicture;
                ingredientInfo.IngredienteName = ingredient.IngredientName;
                ingredientInfo.IngredientUnitQuantity = Convert.ToInt32(ingredient.Quantity);
                ingredientInfo.Unit =ingredient.SelectedUnit;

                flpIngredients.Controls.Add(ingredientInfo);
            }

        }
    }
}
