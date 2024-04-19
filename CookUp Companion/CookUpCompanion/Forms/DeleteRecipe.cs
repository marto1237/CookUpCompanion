using CookUp_Companion_BusinessLogic.Manager;
using CookUpCompanion.UserControls;
using InterfacesLL;
using Logic;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class DeleteRecipe : Form
    {
        private readonly IRecipeManager recipeManager;
        private readonly string recipeName;
        private readonly string creatorName;
        private readonly Recipe recipe;
        public DeleteRecipe(IRecipeManager recipeManager, string recipeName, string creatorName)
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
            LBtbRecipeName .Text = recipe.RecipeName;
            lbDescription.Text = recipe.Description;
            lbInstructions.Text = recipe.Instructions;

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                IngredientInfo ingredientInfo = new IngredientInfo();

                ingredientInfo.IngredientPicture = ingredient.IngredientPicture;
                ingredientInfo.IngredienteName = ingredient.IngredientName;
                ingredientInfo.IngredientUnitQuantity = Convert.ToInt32(ingredient.Quantity);
                ingredientInfo.Unit = ingredient.SelectedUnit;

                flpIngredients.Controls.Add(ingredientInfo);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteRecipe_Click(object sender, EventArgs e)
        {
            int recipeID = recipeManager.GetRecipeID(recipe);
            if (recipeID != -1)
            {
                if (recipeManager.DeleteRecipe(recipe))
                {
                    MessageBox.Show($"The recipe {recipe.RecipeName} has been unbanned succefully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Something went wrong");
                }
            }
            else
            {
                MessageBox.Show("Reicpe have not been founded");
            }
        }
    }
}
