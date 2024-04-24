using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace CookUp_Companion_web.Pages
{
    [Authorize]
    
    public class ShoppingModel : PageModel
    {
        public List<Ingredient> Ingredients;
        private readonly IRecipeManager recipeManager;
        private readonly IUserManager userManager;

        public User _user { get; private set; }
        private int userId;
        public ShoppingModel(IUserManager userManager, IRecipeManager recipeManager)
        {
            this.userManager = userManager;
            this.recipeManager = recipeManager;
        }
        public void OnGet()
        {

            // Retrieve the authenticated user's claims
            var userClaims = HttpContext.User.Claims;

            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);


            }

             userId = userManager.GetIdByUsername(_user.Username);

        }

        public async Task<IActionResult> OnPostRemoveIngredient(int ingredientId)
        {
            // Retrieve the authenticated user's claims
            var userClaims = HttpContext.User.Claims;

            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);


            }
            //int userId = userManager.GetIdByUsername(_user.Username);

            //bool result = recipeManager.RemoveSavedRecipe(userId, recipeId);
            //if (result)
            //{
            //    TempData["SuccessMessage"] = "Recipe deleted successfully.";
            //}
            //else
            //{
            //    TempData["ErrorMessage"] = "Failed to delete the recipe.";
            //}
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddIngredient(int ingredientId)
        {
            // Retrieve the authenticated user's claims
            var userClaims = HttpContext.User.Claims;

            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);


            }
            //int userId = userManager.GetIdByUsername(_user.Username);

            //bool result = recipeManager.RemoveSavedRecipe(userId, recipeId);
            //if (result)
            //{
            //    TempData["SuccessMessage"] = "Recipe deleted successfully.";
            //}
            //else
            //{
            //    TempData["ErrorMessage"] = "Failed to delete the recipe.";
            //}
            return RedirectToPage();
        }
    }
}
