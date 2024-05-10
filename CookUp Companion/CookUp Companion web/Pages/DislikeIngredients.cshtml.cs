using CookUp_Companion_BusinessLogic.Manager;
using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace CookUp_Companion_web.Pages
{
    public class DislikeIngredientsModel : PageModel
    {
        List<Ingredient> dislikedIngredients;
        public User _user { get; private set; }
        private int userId;

        private readonly IRecipeManager recipeManager;
        private readonly IUserManager userManager;
        public DislikeIngredientsModel(IRecipeManager recipeManager, IUserManager userManager)
        {

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
            if (_user != null)
            {
                int userId = userManager.GetIdByUsername(_user.Username); // Implement this in your UserManager to get the current user's ID

                dislikedIngredients = recipeManager.GetUserDislikes(userId);
                
            }
        }

        public void AddNewDislike()
        {

        }

        public void ListIngredientsWithSimilarName()
        {

        }
    }
}
