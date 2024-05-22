using CookUp_Companion_BusinessLogic.InterfacesLL;
using CookUp_Companion_BusinessLogic.Manager;
using InterfaceDAL;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookUp_Companion_BusinessLogic.Algoritam
{
    public class RecommendedRecipesByOtherUsersLikes : IRecommendedRecipesAlgoritam
    {
        private readonly IRecipeDALManager recipeManager;
        private readonly IUserManager userManager;

        public RecommendedRecipesByOtherUsersLikes(IRecipeDALManager recipeManager, IUserManager userManager)
        {
            this.recipeManager = recipeManager;
            this.userManager = userManager;
        }

        public List<Recipe> Recommend(User user, int pageNumber, int pageSize)
        {
            try
            {
                int userId = userManager.GetIdByUsername(user.Username);
                List<Recipe> userLikedRecipes = GetUserLikedRecipes(userId);
                if (userLikedRecipes.Count == 0)
                {
                    return RecommendTrendingRecipes(pageNumber, pageSize);
                }

                // Get all users' liked recipes, excluding the current user
                Dictionary<User, List<Recipe>> allUsersRecipes = userManager.GetAllUsers()
                    .Where(u => userManager.GetIdByUsername(u.Username) != userId)
                    .ToDictionary(u => u, u => GetUserLikedRecipes(userManager.GetIdByUsername(u.Username)));

                // Calculate similarity scores based on shared liked recipes
                var similarityScores = allUsersRecipes.Select(u => new
                {
                    User = u.Key,
                    SharedLikedRecipesCount = u.Value.Count(r => userLikedRecipes.Any(ur => IsRecipeSimilar(ur, r))),
                    UserRecipesToRecommend = u.Value.Where(r => !userLikedRecipes.Any(ur => IsRecipeSimilar(ur, r))).ToList()
                })
                .OrderByDescending(u => u.SharedLikedRecipesCount)
                .ToList();

                // Recommend recipes from similar users
                HashSet<int> recommendedRecipeIds = new HashSet<int>();
                List<Recipe> recommendedRecipes = new List<Recipe>();

                foreach (var simUser in similarityScores)
                {
                    // Add recipes liked by the current user but not by the similar user
                    foreach (var recipe in simUser.UserRecipesToRecommend)
                    {
                        if (recommendedRecipeIds.Add(GetRecipeId(recipe))) // This checks if the recipe ID was not already added
                        {
                            recommendedRecipes.Add(recipe);
                        }
                    }
                }

                // Skip and take recipes based on pagination
                return recommendedRecipes.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating recommendations: {ex.Message}");
                return new List<Recipe>();
            }
        }

        public bool IsRecipeSimilar(Recipe one, Recipe two)
        {
            // Compare recipes by name and creator as a proxy to unique identification
            return one.RecipeName == two.RecipeName && one.Creator.Username == two.Creator.Username;
        }

        public List<Recipe> GetUserLikedRecipes(int userId)
        {
            return recipeManager.GetLikedRecipesByUser(userId);
        }

        public List<Recipe> RecommendTrendingRecipes(int pageNumber, int pageSize)
        {
            DateTime today = DateTime.Today;
            var combinedRecipes = CombineRecipesForTrends(pageNumber, pageSize);

            var scoredRecipes = combinedRecipes.Select(recipe => new
            {
                Recipe = recipe,
                Score = CalculateTrendScore(recipe, today)
            }).OrderByDescending(sr => sr.Score)
           .Select(sr => sr.Recipe)
           .ToList();
            return scoredRecipes.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Recipe> CombineRecipesForTrends(int pageNumber, int pageSize)
        {
            List<Recipe> popularRecipes = recipeManager.GetRecipesBySaves(pageNumber, pageSize);
            List<Recipe> recentRecipes = recipeManager.GetRecipesByNewest(pageNumber, pageSize);
            return popularRecipes.Concat(recentRecipes)
                .GroupBy(r => GetRecipeId(r))
                .Select(g => g.First())
                .ToList();
        }
        public double CalculateTrendScore(Recipe recipe, DateTime referenceDate) 
        {
            // Updated implementation to use interface methods...
            int recipeID = GetRecipeId(recipe);
            DateTime recipeCreateTime = GetRecipeCreateDate(recipeID);
            var (likes, dislikes) = GetRecipeLikesAndDislikes(recipeID);
            var daysSincePosted = (referenceDate - recipeCreateTime).TotalDays;
            var saveCount = GetRecipeSaveCount(recipeID);
            return (likes + saveCount) / (1 + daysSincePosted);
        }


        public DateTime GetRecipeCreateDate(int recipeId)
        {
            return recipeManager.GetRecipeCreateDate(recipeId);
        }

        public (int Likes, int Dislikes) GetRecipeLikesAndDislikes(int recipeId)
        {
            return recipeManager.GetLikesAndDislikes(recipeId);
        }

        public int GetRecipeSaveCount(int recipeId)
        {
            return recipeManager.GetSaveCount(recipeId);
        }

        public int GetRecipeId(Recipe recipe)
        {
            return recipeManager.GetRecipeID(recipe);
        }

    }
}
