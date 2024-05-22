using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using CookUp_Companion_Classes;


namespace CookUp_Companion_web.Pages
{
    public class RecipeInfoModel : PageModel
    {
        public Recipe recipe { get; set; }
        public int recipeId { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public int LikePercentage {  get; set; }

        public double Calories = 0;
        public double Fat = 0;
        public double Carbs = 0;
        public double Sugar = 0;
        public double Sodium = 0;
        public double Protein = 0;


        public List<NutritionInfo> NutritionalInformation { get; set; } = new List<NutritionInfo>();

        public List<Comment> Comments { get; set; } = new List<Comment>();
        public int CurrentPage { get; set; } = 1;
        private const int CommentsPerPage = 5;

        [BindProperty]
        public string UserReaction { get; set; }
        /*Comment recipe property*/
        [BindProperty]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Comment is required!")]
        public string UserComment { get; set; }

        public bool IsFavorite { get; set; }

        public string FavoriteIconClass => IsFavorite ? "fa-solid fa-bookmark" : "fa-regular fa-bookmark";

        private readonly IRecipeManager recipeManager;
        private readonly IUserManager userManager;

        const string API_KEY = "9f5b905af59f40b9840e6f89c57f1760";
        const string BASE_URL = "https://api.spoonacular.com/food/ingredients";


        public User _user { get; private set; }
        public RecipeInfoModel(IRecipeManager recipeManager, IUserManager userManager)
        {
            this.userManager = userManager; 
            this.recipeManager = recipeManager;
        }
        public async Task<IActionResult> OnGetAsync(int? id, int page = 1)
        {
            if(!id.HasValue ||  id <= 0 )
            {
                ModelState.AddModelError("error", "id is required");
                return RedirectToPage("/Recipes");
            }
            
            await GetRecipe(Convert.ToInt32(id));
            CurrentPage = page;
            LoadComments(id.GetValueOrDefault(), CurrentPage);
            (Likes, Dislikes) = recipeManager.GetLikesAndDislikes(Convert.ToInt32(id));
            LikePercentage = (int)Math.Round(CalculateLikePercentage(Likes, Dislikes), 0);

            // Retrieve the authenticated user's claims
            var userClaims = HttpContext.User.Claims;
            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);
                IsFavorite = recipeManager.CheckIfFavorite(userManager.GetIdByUsername(_user.Username), Convert.ToInt32(id));
            }
            else
            {
                IsFavorite = false;
            }
            return Page();

        }

        private void LoadComments(int recipeId, int page)
        {
            var newComments = recipeManager.GetCommentsByRecipeId(recipeId, page, CommentsPerPage);
            Comments.AddRange(newComments); // Append new comments to the existing list
        }

        private async Task GetRecipe(int id)
        {
            try
            {
                recipe = recipeManager.GetRecipeById(id);
                
                if(recipe != null && recipe.Ingredients != null)
                {
                    recipeId = id;
                    TempData["recipeId"] = recipeId;
                    foreach (var ingredient in recipe.Ingredients)
                    {
                        var nutrition = await FetchNutritionInfo(ingredient.IngredientId, ingredient.Quantity, ingredient.SelectedUnit);
                        
                    }

                    Calories = Math.Round(Calories, 2);
                    Fat = Math.Round(Fat, 2);
                    Carbs = Math.Round(Carbs, 2);
                    Sugar = Math.Round(Sugar, 2);
                    Sodium = Math.Round(Sodium, 2);
                    Protein = Math.Round(Protein, 2);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERROR", ex.Message);
            }
        }

        private async Task<NutritionInfo> FetchNutritionInfo(int ingredientId, double amount, string unit)
        {
            using var client = new HttpClient();
            string url = $"{BASE_URL}/{ingredientId}/information?apiKey={API_KEY}&amount={amount}&unit={unit}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var dataWrapper = JsonSerializer.Deserialize<NutritionDataWrapper>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (dataWrapper?.Nutrition?.Nutrients != null)
                    {
                        foreach (Nutrient nutrient in dataWrapper.Nutrition.Nutrients)
                        {
                            switch (nutrient.Name)
                            {
                                case "Calories":
                                    Calories += nutrient.Amount;  // Assuming 'Amount' is always in kcal
                                    break;
                                case "Fat":
                                    Fat += nutrient.Amount;  // Assuming 'Amount' is always in grams
                                    break;
                                case "Carbohydrates":
                                    Carbs += nutrient.Amount;  // Assuming 'Amount' is always in grams
                                    break;
                                case "Sugar":
                                    Sugar += nutrient.Amount;  // Assuming 'Amount' is always in grams
                                    break;
                                case "Sodium":
                                    Sodium += nutrient.Amount;
                                    break;
                                case "Protein":
                                    Protein += nutrient.Amount;  // Assuming 'Amount' is always in grams
                                    break;
                            }
                        }
                    }
                    return dataWrapper?.Nutrition;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching nutrition data for ingredient {ingredientId}: {ex.Message}");
            }

            return null;
        }
        //private double ExtractAmount(List<Nutrient> nutrients, string name)
        //{
        //    return nutrients.FirstOrDefault(n => n.Name.Contains(name))?.Amount ?? 0;
        //}
        public class NutritionDataWrapper
        {
            public NutritionInfo Nutrition { get; set; }
        }

        public class NutritionInfo
        {
            public List<Nutrient> Nutrients { get; set; }
        }

        public class Nutrient
        {
            public string Name { get; set; }
            public double Amount { get; set; }
            public string Unit { get; set; }
        }



        public async Task<IActionResult> OnPostCommentAsync()
        {
            recipeId = (int)TempData["recipeId"];
            if (!User.Identity.IsAuthenticated)
            {
                // Redirects to the login page if the user is not authenticated
                return RedirectToPage("/Login");
            }

            if (!ModelState.IsValid)
            {
                TempData["CommentStatus"] = "Failed to post comment due to validation errors.";
                return RedirectToPage("RecipeInfo", new { id = recipeId });
            }


            

            if (recipeId <= 0)
            {
                // Log error or set an error message
                ModelState.AddModelError("error", "Recipe ID must be loaded to post a comment.");
                return Page();
            }
            // Handle the reaction (like or dislike)
            Console.WriteLine($"Reaction: {UserReaction}");  // Logging the reaction for debugging
            // Handle the comment
            Console.WriteLine($"Comment: {UserComment}");  // Logging the comment for debugging

            // Extract user data from claims

            // Retrieve the authenticated user's claims
            var userClaims = HttpContext.User.Claims;

            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var userNameClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            var roleClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);


            }
            else
            {
                return RedirectToPage("/Login");
            }
            // Here you would add your logic to save these details to your database or process them as needed
            try
            {
                // Assuming the AddComment method exists and handles the comment saving
                
                bool IsCommnetAdded =  recipeManager.AddComment(userManager.GetIdByUsername(_user.Username), recipeId, UserReaction, UserComment);

                if (IsCommnetAdded)
                {
                    // Simulate successful save
                    TempData["CommentStatus"] = "Your comment has been successfully posted!";
                }
                else
                {
                    TempData["CommentStatus"] = "Failed to post comment ";
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error posting comment: {ex.Message}");
                return Page();
            }
            


            return RedirectToPage("RecipeInfo", new { id = recipeId });  // Redirect to the same page to see the updated comments
        }

        public double CalculateLikePercentage(int likes, int dislikes)
        {
            if (likes + dislikes == 0) return 0; // Avoid division by zero
            return (double)likes / (likes + dislikes) * 100;
        }

        public IActionResult OnPostToggleFavorite(int recipeId)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Login");
            }
            // Retrieve the authenticated user's claims
            var userClaims = HttpContext.User.Claims;

            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var userNameClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            var roleClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);


            }
            if (_user != null)
            {
                int userId = userManager.GetIdByUsername(_user.Username); // Implement this in your UserManager to get the current user's ID
                bool isNowFavorite = recipeManager.ToggleFavoriteRecipe(userId, recipeId);
                TempData["FavoriteUpdated"] = isNowFavorite ? "Added to favorites" : "Removed from favorites";
            }


            return RedirectToPage(new { id = recipeId });
        }
    }
}
