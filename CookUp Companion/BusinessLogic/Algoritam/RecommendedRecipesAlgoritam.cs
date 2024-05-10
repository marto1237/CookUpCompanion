using CookUp_Companion_BusinessLogic.InterfacesLL;
using InterfaceDAL;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUp_Companion_BusinessLogic.Algoritam
{
    public class RecommendedRecipesAlgoritam : IRecommendedRecipesAlgoritam
    {
        private readonly IRecipeDALManager recipeManager;
        private readonly IUserManager userManager;

        public RecommendedRecipesAlgoritam(IRecipeDALManager recipeManager, IUserManager userManager)
        {
            this.recipeManager = recipeManager;
            this.userManager = userManager;
        }

        public List<Recipe> Recommend(User user, int pageNumber, int pageSize)
        {
            try
            {
                // Get all recipes to check against user preferences
                List<Recipe> allRecipes = recipeManager.GetAllRecipes(1, int.MaxValue);
                int userId = userManager.GetIdByUsername(user.Username);

                // Get the current user's liked and saved recipes
                List<Recipe> userLikedRecipes = GetUserLikedRecipes(userId);
                List<Recipe> userSavedRecipes = GetUserSavedRecipes(userId);

                // Create a set of recipes that the current user should exclude from recommendations
                HashSet<string> excludedRecipeNames = new HashSet<string>(userLikedRecipes.Select(r => r.RecipeName));
                excludedRecipeNames.UnionWith(userSavedRecipes.Select(r => r.RecipeName)); // Add saved recipes' names.


                // Filter out excluded recipes and prioritize recommendations based on collaborative filtering
                List<Recipe> recipesToRecommend = allRecipes.Where(recipe => !excludedRecipeNames.Contains(recipe.RecipeName)).ToList();


                var recommendedRecipes = new HashSet<Recipe>();

                foreach (var recipe in recipesToRecommend)
                {
                    if (IsMatchingUserPreferences(recipe, userLikedRecipes))
                    {
                        recommendedRecipes.Add(recipe);
                    }
                }

                return recommendedRecipes.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating recommendations: {ex.Message}");
                return new List<Recipe>();
            }
        }

        private List<Recipe> GetUserLikedRecipes(int userId)
        {
            // Assuming there's a way to get all liked recipes by a user's ID
            return recipeManager.GetLikedRecipesByUser(userId);
        }

        private List<Recipe> GetUserSavedRecipes(int userId)
        {
            return recipeManager.GetSavedRecipesByUser(userId);
        }

        private bool AreRecipesSimilar(Recipe one, Recipe two)
        {
            // Check similarity based on ingredients
            // Example: checking if they share more than half of their ingredients
            var sharedIngredients = one.Ingredients.Select(i => i.IngredientName).Intersect(two.Ingredients.Select(i => i.IngredientName)).Count();
            return sharedIngredients > one.Ingredients.Count / 2;
        }


        private bool IsMatchingUserPreferences(Recipe recipe, List<Recipe> likedRecipes)
        {
            // Check if any liked recipe shares similar ingredients or other attributes
            return likedRecipes.Any(likedRecipe => 
            AreRecipesSimilar(recipe, likedRecipe));
        }


    }
}
