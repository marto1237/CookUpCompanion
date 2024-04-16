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

        //pagination
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

        public void populateRecipes()
        {
            flpRecipesInfo.Controls.Clear();
            int startIndex = (currentPage - 1) * recipesPerPage;
            List<Recipe> recipes = recipeManager.GetAllRecipes(startIndex, recipesPerPage);

            if (!ListRecipes(recipes))
            {
                MessageBox.Show("There are no recipes yet");
                recipeSearchBar1.UpdateUserCount($"Recipes (0)");
            }


        }

        private void populateRecipesBasedOnSearch(string searchText, int currentPage, int recipesPerPage)
        {
            // Implementation to filter and display recipes based on search text
            List<Recipe> searchedRecipes = recipeManager.SearchRecipesByName(searchText, currentPage, recipesPerPage);

            if (!ListRecipes(searchedRecipes))
            {
                MessageBox.Show("No recipes found matching the search criteria.");
                recipeSearchBar1.UpdateUserCount("Recipes (0)");
            }
            //ListRecipes(filteredRecipes);
        }
        public bool ListRecipes(List<Recipe> recipes)
        {
            flpRecipesInfo.Controls.Clear();
            int startIndex = (currentPage - 1) * recipesPerPage;
            recipes = recipes.Skip(startIndex).Take(recipesPerPage).ToList();
            if (recipes.Count > 0)
            {
                foreach (Recipe recipe in recipes)
                {

                    RecipeControl recipeControl = new RecipeControl();


                    recipeControl.RecipePicture = recipe.Picture;
                    recipeControl.RecipeName = recipe.RecipeName;
                    recipeControl.Creator = recipe.Creator.Username;
                    recipeControl.PrepTime = recipe.PreparationTime;
                    recipeControl.CookTime = recipe.CookingTime;

                    flpRecipesInfo.Controls.Add(recipeControl);
                }

                recipeSearchBar1.UpdateUserCount($"Recipes({recipes.Count})");

                return true;
            }
            return false;
        }
        

        private void Recipes_Load(object sender, EventArgs e)
        {
            populateRecipes();
            UpdatePageIndexNum();
        }
        private void UpdatePageIndexNum()
        {
            paginationControl1.PageIndexNum.Value = currentPage;
        }
        private void paginationControl1_btnPrevious_Click(object sender, EventArgs e)
        {
            currentPage--;
            UpdatePageIndexNum();
            string searchText = recipeSearchBar1.GetSearchText();
            if (!string.IsNullOrEmpty(searchText) && searchText != "Search recipe by name")
            {
                populateRecipesBasedOnSearch(searchText, currentPage, recipesPerPage);
            }
            else
            {
                populateRecipes();
            }
        }
        private void recipeSearchBar1_SearchButtonClicked(object sender, string searchText)
        {
            currentPage = 1;
            populateRecipesBasedOnSearch(searchText, currentPage, recipesPerPage);

        }
 
        private void paginationControl1_btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            UpdatePageIndexNum();
            string searchText = recipeSearchBar1.GetSearchText(); 
            if (!string.IsNullOrEmpty(searchText) && searchText != "Search recipe by name")
            {
                populateRecipesBasedOnSearch(searchText, currentPage, recipesPerPage);
            }
            else
            {
                populateRecipes();
            }
        }

        private void paginationControl1_btnGoToCertainPage_Click(object sender, EventArgs e)
        {
            int pageNumber = Convert.ToInt32(paginationControl1.PageIndexNum.Value);
            currentPage = pageNumber;
            string searchText = recipeSearchBar1.GetSearchText();
            if (!string.IsNullOrEmpty(searchText) && searchText != "Search recipe by name")
            {
                populateRecipesBasedOnSearch(searchText, currentPage, recipesPerPage);
            }
            else
            {
                populateRecipes();
            }
        }
    }
}
