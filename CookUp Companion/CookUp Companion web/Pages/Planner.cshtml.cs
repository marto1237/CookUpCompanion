using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace CookUp_Companion_web.Pages
{
    [Authorize]
    public class PlannerModel : PageModel
    {
        public List<Recipe> Recipes;
        public List<int> Likes { get; set; }
        public List<int> Dislikes { get; set; }
        public List<int> SaveCounts { get; set; }

        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public const int PageSize = 24;

        private readonly IRecipeManager recipeManager;
        private readonly IUserManager userManager;

        public User _user { get; private set; }
        private int userId;

        public PlannerModel(IUserManager userManager, IRecipeManager recipeManager)
        {
            this.userManager = userManager;
            this.recipeManager = recipeManager;
        }
        public void OnGet(int? pageNum)
        {
            CurrentPage = pageNum ?? 1;
            GetIngredients(CurrentPage);
            TotalPages = recipeManager.GetAllRecipesPageNum(PageSize);
            

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
                    int recipeID = recipeManager.GetRecipeID(recipe);

                    
                }
            }
            else
            {
                RedirectToPage("/Login");
            }


        }

        public void GetIngredients(int page)
        {
            try
            {
                // Retrieve the authenticated user's claims
                var userClaims = HttpContext.User.Claims;

                var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

                if (userEmailClaim != null)
                {
                    _user = userManager.GetUserByEmail(userEmailClaim.Value);
                    userId = userManager.GetIdByUsername(_user.Username);

                }
                Recipes = recipeManager.GetSavedRecipes(CurrentPage, PageSize, userId);
                TotalPages = recipeManager.GetAllRecipesPageNum(PageSize);
            }
            catch (Exception ex)
            {

                // Add a model error that you can display in the view
                ModelState.AddModelError("", $"Failed to load  saved recipes: {ex.Message}");
                return;
            }


        }

        public int GetRecipeID(Recipe recipe)
        {
            int recipeID = recipeManager.GetRecipeID(recipe);
            if (recipeID != -1)
            {
                return recipeID;
            }
            else
            {
                return 0;
            }
            //Leter when the user click the recipe check if the recipeID is not equal to 0
        }

        public async Task<IActionResult> OnPostSaveRecipeDay(int recipeId, string day)
        {
            var result = true;
            //var userId = _userManager.GetUserId(User); // Ensure you have a method to retrieve the currently logged-in user's ID

            //// Assume you have a method to save the data
            //var result = await _context.SaveRecipeDayAsync(recipeId, day, userId);
            if (result)
            {
                TempData["SuccessMessage"] = "Recipe successfully added to the day!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add recipe.";
            }

            return RedirectToPage(); // Optionally redirect back to the same page or another confirmation page
        }

    }
}
