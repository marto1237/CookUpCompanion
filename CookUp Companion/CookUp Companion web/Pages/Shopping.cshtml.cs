using CookUp_Companion_BusinessLogic.InterfacesLL;
using CookUp_Companion_BusinessLogic.Managers;
using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using System.Security.Claims;

namespace CookUp_Companion_web.Pages
{
    [Authorize]
    
    public class ShoppingModel : PageModel
    {
        [BindProperty]
        public List<Ingredient> Ingredients { get; set; }

        [BindProperty]
        public string newIngredientName { get; set; }   
        public Ingredient ingredientToAdd { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public string Name { get; set; }
        private readonly IRecipeManager recipeManager;
        private readonly IUserManager userManager;
        private readonly IShoppingCartManager shoppingCartManager;
        public User _user { get; private set; }
        private int userId;
        public ShoppingModel(IUserManager userManager, IRecipeManager recipeManager, IShoppingCartManager shoppingCartManager)
        {
            this.userManager = userManager;
            this.recipeManager = recipeManager;
            this.shoppingCartManager = shoppingCartManager;
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
            else
            {
                RedirectToPage("/Login");
            }

             userId = userManager.GetIdByUsername(_user.Username);
            Ingredients = shoppingCartManager.GetShoppingCartIngredients(userId);
            foreach( Ingredient ingredient in Ingredients)
            {
                ingredient.IsSelected = false;
            }
        }

        public async Task<IActionResult> OnPostRemoveSelectedIngredients()
        {
            
            var userClaims = HttpContext.User.Claims;

            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);
                userId = userManager.GetIdByUsername(_user.Username);

                int userCartID = shoppingCartManager.GetCartIdByUserId(userId);

                bool someDeleted = false;
                foreach (var ingredient in Ingredients)
                {
                    if (ingredient.IsSelected)
                    {
                        bool result = shoppingCartManager.RemoveIngredientFromCart(userCartID, ingredient.IngredientId, ingredient.Quantity, ingredient.SelectedUnit);
                        if (result)
                        {
                            someDeleted = true; // Set to true if any deletions succeed
                        }
                    }
                }
                if (someDeleted)
                {
                    TempData["IsSuccess"] = true;
                    TempData["SuccessMessage"] = "Selected ingredients deleted successfully.";
                }
                else
                {
                    TempData["IsError"] = true;
                    TempData["ErrorMessage"] = "Failed to delete selected ingredients.";
                }
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddIngredient()
        {
            
            // Retrieve the authenticated user's claims
            var userClaims = HttpContext.User.Claims;

            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);


            }
            int userId = userManager.GetIdByUsername(_user.Username);

            if (string.IsNullOrEmpty(newIngredientName))
            {
                TempData["ErrorMessage"] = "Input cannot be empty.";
                return Page();
            }
            string[] parts = newIngredientName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 3)
            {
                TempData["ErrorMessage"] = "Please enter the input in 'quantity size name' format.";
                return Page();
            }
            if (!int.TryParse(parts[0], out int quantity))
            {
                TempData["ErrorMessage"] = "Invalid quantity. Please enter a valid number.";
                return Page();
            }

            string selectedUnit = parts[1];
            string name = string.Join(" ", parts.Skip(2));
            Ingredient ingredient = recipeManager.GetIngredientByName(name);
            if (ingredient == null)
            {
                TempData["ErrorMessage"] = $"Ingredient not found: {name}";
                return Page();
            }

            ingredient.ChangeSelectedUnit(selectedUnit);
            ingredient.ChangeQuantity(quantity);

            int userCartID = shoppingCartManager.GetCartIdByUserId(userId);
            bool addResult = shoppingCartManager.AddIngredientToCart(userCartID, ingredient.IngredientId, ingredient.Quantity , ingredient.SelectedUnit);
            if (addResult)
            {
                TempData["SuccessMessage"] = $"Successfully added {quantity} {selectedUnit} of {name}.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add ingredient to cart.";
            }
            if (Ingredients == null)
            {
                TempData["IsError"] = true;
                TempData["ErrorMessage"] = "No ingredients found.";
                return Page();
            }

            return RedirectToPage();
        }
    }
}
