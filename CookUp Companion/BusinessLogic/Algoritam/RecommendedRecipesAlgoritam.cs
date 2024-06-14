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
        private readonly IRecipeReviewsManager recipeReviewsManager;
        public RecommendedRecipesAlgoritam(IRecipeDALManager recipeManager, IUserManager userManager, IRecipeReviewsManager recipeReviewsManager)
        {
            this.recipeManager = recipeManager;
            this.userManager = userManager;
            this.recipeReviewsManager = recipeReviewsManager;
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

        public List<Recipe> GetUserLikedRecipes(int userId)
        {
            // Assuming there's a way to get all liked recipes by a user's ID
            return recipeReviewsManager.GetLikedRecipesByUser(userId);
        }


        private List<Recipe> GetUserSavedRecipes(int userId)
        {
            return recipeManager.GetSavedRecipesByUser(userId);
        }

        public List<Recipe> RecommendTrendingRecipes(int pageNumber, int pageSize)
        {
            List<Recipe> allRecipes = recipeManager.GetAllRecipes(1, int.MaxValue);
            DateTime referenceDate = DateTime.Now;

            var trendingRecipes = allRecipes
                .OrderByDescending(recipe => CalculateTrendScore(recipe, referenceDate))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return trendingRecipes;
        }

        public bool IsRecipeSimilar(Recipe one, Recipe two)
        {
            return AreRecipesSimilar(one, two);
        }

        public double CalculateTrendScore(Recipe recipe, DateTime referenceDate)
        {
            int recipeID = GetRecipeId(recipe);
            DateTime creationDate = GetRecipeCreateDate(recipeID);
            (int likes, int dislikes) = GetRecipeLikesAndDislikes(recipeID);
            int saveCount = GetRecipeSaveCount(recipeID);

            double daysSinceCreation = (referenceDate - creationDate).TotalDays;
            double likeRatio = likes > 0 ? (double)likes / (likes + dislikes) : 0;
            double trendScore = (likeRatio * saveCount) / daysSinceCreation;

            return trendScore;
        }

        public List<Recipe> CombineRecipesForTrends(int pageNumber, int pageSize)
        {
            List<Recipe> allRecipes = recipeManager.GetAllRecipes(1, int.MaxValue);

            var combinedRecipes = allRecipes
                .OrderByDescending(recipe => CalculateTrendScore(recipe, DateTime.Now))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return combinedRecipes;
        }

        public DateTime GetRecipeCreateDate(int recipeId)
        {
            return recipeManager.GetRecipeCreateDate(recipeId);
        }

        public (int Likes, int Dislikes) GetRecipeLikesAndDislikes(int recipeId)
        {
            return recipeReviewsManager.GetLikesAndDislikes(recipeId);
        }

        public int GetRecipeSaveCount(int recipeId)
        {
            return recipeManager.GetSaveCount(recipeId);
        }

        public int GetRecipeId(Recipe recipe)
        {
            return recipeManager.GetRecipeID(recipe);
        }

        public int GetTotalRecommendedRecipes(User user)
        {
            try
            {
                List<Recipe> allRecipes = recipeManager.GetAllRecipes(1, int.MaxValue);
                int userId = userManager.GetIdByUsername(user.Username);

                List<Recipe> userLikedRecipes = GetUserLikedRecipes(userId);
                List<Recipe> userSavedRecipes = GetUserSavedRecipes(userId);

                HashSet<string> excludedRecipeNames = new HashSet<string>(userLikedRecipes.Select(r => r.RecipeName));
                excludedRecipeNames.UnionWith(userSavedRecipes.Select(r => r.RecipeName));

                List<Recipe> recipesToRecommend = allRecipes.Where(recipe => !excludedRecipeNames.Contains(recipe.RecipeName)).ToList();

                var recommendedRecipes = new HashSet<Recipe>();

                foreach (var recipe in recipesToRecommend)
                {
                    if (IsMatchingUserPreferences(recipe, userLikedRecipes))
                    {
                        recommendedRecipes.Add(recipe);
                    }
                }

                return recommendedRecipes.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating total recommended recipes: {ex.Message}");
                return 0;
            }
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
