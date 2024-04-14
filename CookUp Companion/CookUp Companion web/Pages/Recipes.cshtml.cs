using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookUp_Companion_web.Pages
{
    public class RecipeModel : PageModel
    {
        public List<Recipe> Recipes;
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public const int PageSize = 24;

        private readonly IRecipeManager recipeManager;
        public RecipeModel(IRecipeManager recipeManager)
        {

            this.recipeManager = recipeManager;
        }
        public void OnGet(int? pageNum)
        {
            CurrentPage = pageNum ?? 1;
            GetIngredients(CurrentPage);
        }

        public void GetIngredients(int page)
        {
            try
            {
                Recipes = recipeManager.GetAllRecipes(CurrentPage, PageSize);
                TotalPages = recipeManager.GetAllRecipesPageNum(PageSize);
            }
            catch (Exception ex)
            {

            }


        }
        public int GetRecipeID(Recipe recipe)
        {
            int recipeID = recipeManager.GetRecipeID(recipe);
            if (recipeID  != -1)
            {
                return recipeID;
            }
            else
            {
                return 0;
            }
            //Leter when the user click the recipe check if the recipeID is not equal to 0
        }
    }
}
