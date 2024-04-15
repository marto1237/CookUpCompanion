using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace CookUp_Companion_web.Pages
{
    public class RecipeModel : PageModel
    {
        public List<Recipe> Recipes;
        public List<bool> IsFavorite;
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public const int PageSize = 24;

        private readonly IRecipeManager recipeManager;
        private readonly IUserManager userManager;

        public User _user { get; private set; }
        public RecipeModel(IUserManager userManager, IRecipeManager recipeManager)
        {
            this.userManager = userManager;
            this.recipeManager = recipeManager;
        }
        public void OnGet(int? pageNum)
        {
            CurrentPage = pageNum ?? 1;
            GetIngredients(CurrentPage);
            TotalPages = recipeManager.GetAllRecipesPageNum(PageSize);
            IsFavorite = new List<bool>();

            // Retrieve the authenticated user's claims
            var userClaims = HttpContext.User.Claims;

            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);


            }
            if (_user != null)
            {
                int userId = userManager.GetIdByUsername(_user.Username); // Implement this in your UserManager to get the current user's ID
               

                foreach (var recipe in Recipes)
                {
                    bool isNowFavorite = recipeManager.CheckIfFavorite(userId, recipeManager.GetRecipeID(recipe));
                    IsFavorite.Add(recipeManager.CheckIfFavorite(userId, recipeManager.GetRecipeID(recipe)));
                }
            }
            else
            {
                foreach (var recipe in Recipes)
                {
                    IsFavorite.Add(false);
                }
            }

            
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

                // Add a model error that you can display in the view
                ModelState.AddModelError("", $"Failed to load recipes: {ex.Message}"); 
                return;
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
