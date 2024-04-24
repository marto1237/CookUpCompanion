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
    public class RecommededRecipesAlgoritam : IRecommendedRecipesAlgoritam
    {
        private readonly IRecipeDALManager recipeManager;
        private readonly IUserManager userManager;

        public RecommededRecipesAlgoritam(IRecipeDALManager recipeManager, IUserManager userManager)
        {
            this.recipeManager = recipeManager;
            this.userManager = userManager;
        }

        public List<Recipe> Recommend(User user)
        {
            // Get all recipes to check against user preferences
            List<Recipe> allRecipes = recipeManager.GetAllRecipes(1, int.MaxValue); 
            int userId = userManager.GetIdByUsername(user.Username);
            List<Recipe> userLikedRecipes = GetUserLikedRecipes(userId);
            List<Recipe> userSavedRecipes = GetUserSavedRecipes(userId);

            // Combine liked and saved recipes into a HashSet to avoid duplicates.
            HashSet<string> excludedRecipeNames = new HashSet<string>(userLikedRecipes.Select(r => r.RecipeName));
            excludedRecipeNames.UnionWith(userSavedRecipes.Select(r => r.RecipeName)); // Add saved recipes' names.


            // Filter out recipes that the user has liked or saved from the list of all recipes.
            List<Recipe> recipesToRecommend = allRecipes.Where(recipe => !excludedRecipeNames.Contains(recipe.RecipeName)).ToList();


            var recommendedRecipes = new HashSet<Recipe>();

            foreach (var recipe in recipesToRecommend)
            {
                if (IsMatchingUserPreferences(recipe, userLikedRecipes))
                {
                    recommendedRecipes.Add(recipe);
                }
            }

            return recommendedRecipes.ToList();
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
