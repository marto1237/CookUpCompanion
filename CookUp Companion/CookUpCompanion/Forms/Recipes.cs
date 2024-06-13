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
using RecipeControl = CookUpCompanion.UserControls.RecipeControl;

namespace CookUpCompanion.Forms
{
    public partial class Recipes : Form
    {
        private readonly IUserManager userManager;
        private readonly IRecipeManager recipeManager;

        // Pagination
        private int currentPage = 1;
        private int recipesPerPage = 10; // Change this value as needed

        public Recipes(IRecipeManager recipeManager)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;
            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            // Subscribe to the search button clicked event
            recipeSearchBar1.SearchButtonClicked += recipeSearchBar1_SearchButtonClicked;

            // Subscribe to the pagination control's events
            paginationControl1.PreviousClicked += paginationControl1_btnPrevious_Click;
            paginationControl1.NextClicked += paginationControl1_btnNext_Click;
            paginationControl1.GoToPageClicked += paginationControl1_btnGoToCertainPage_Click;
        }

        public void PopulateRecipes()
        {
            flpRecipesInfo.Controls.Clear();
            int startIndex = (currentPage - 1) * recipesPerPage;
            List<Recipe> recipes = recipeManager.GetAllRecipes(currentPage, recipesPerPage);

            if (!ListRecipes(recipes))
            {
                MessageBox.Show("There are no recipes yet");
                recipeSearchBar1.UpdateUserCount("Recipes (0)");
            }
        }

        private void PopulateRecipesBasedOnSearch(string searchText, int currentPage, int recipesPerPage)
        {
            List<Recipe> searchedRecipes = recipeManager.SearchRecipesByName(searchText, currentPage, recipesPerPage);

            if (!ListRecipes(searchedRecipes))
            {
                MessageBox.Show("No recipes found matching the search criteria.");
                recipeSearchBar1.UpdateUserCount("Recipes (0)");
            }
        }

        public bool ListRecipes(List<Recipe> recipes)
        {
            flpRecipesInfo.Controls.Clear();

            if (recipes.Count > 0)
            {
                foreach (Recipe recipe in recipes)
                {
                    RecipeControl recipeControl = new RecipeControl(recipeManager);

                    recipeControl.RecipePicture = recipe.Picture;
                    recipeControl.RecipeName = recipe.RecipeName;
                    recipeControl.Creator = recipe.Creator.Username;
                    recipeControl.PrepTime = recipe.PreparationTime;
                    recipeControl.CookTime = recipe.CookingTime;

                    flpRecipesInfo.Controls.Add(recipeControl);
                }
                RecipeControl emptyControl = new RecipeControl(recipeManager)
                {
                    Width = flpRecipesInfo.ClientSize.Width - flpRecipesInfo.Margin.Horizontal,
                    Height = 150 // Adjust to match the height of other RecipeControls
                };

                recipeSearchBar1.UpdateUserCount($"Recipes ({recipes.Count})");

                return true;
            }
            return false;
        }

        private void Recipes_Load(object sender, EventArgs e)
        {
            PopulateRecipes();
            UpdatePageIndexNum();
        }

        private void UpdatePageIndexNum()
        {
            paginationControl1.PageIndexNum.Value = currentPage;
        }

        private void paginationControl1_btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                UpdatePageIndexNum();
                string searchText = recipeSearchBar1.GetSearchText();
                if (!string.IsNullOrEmpty(searchText) && searchText != "Search recipe by name")
                {
                    PopulateRecipesBasedOnSearch(searchText, currentPage, recipesPerPage);
                }
                else
                {
                    PopulateRecipes();
                }
            }
        }

        private void recipeSearchBar1_SearchButtonClicked(object sender, string searchText)
        {
            currentPage = 1;
            PopulateRecipesBasedOnSearch(searchText, currentPage, recipesPerPage);
        }

        private void paginationControl1_btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            UpdatePageIndexNum();
            string searchText = recipeSearchBar1.GetSearchText();
            if (!string.IsNullOrEmpty(searchText) && searchText != "Search recipe by name")
            {
                PopulateRecipesBasedOnSearch(searchText, currentPage, recipesPerPage);
            }
            else
            {
                PopulateRecipes();
            }
        }

        private void paginationControl1_btnGoToCertainPage_Click(object sender, EventArgs e)
        {
            int pageNumber = Convert.ToInt32(paginationControl1.PageIndexNum.Value);
            currentPage = pageNumber;
            string searchText = recipeSearchBar1.GetSearchText();
            if (!string.IsNullOrEmpty(searchText) && searchText != "Search recipe by name")
            {
                PopulateRecipesBasedOnSearch(searchText, currentPage, recipesPerPage);
            }
            else
            {
                PopulateRecipes();
            }
        }
    }
}
