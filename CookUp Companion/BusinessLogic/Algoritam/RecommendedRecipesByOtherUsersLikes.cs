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
        private readonly IRecipeReviewsManager recipeReviewsManager;

        public RecommendedRecipesByOtherUsersLikes(IRecipeDALManager recipeManager, IUserManager userManager, IRecipeReviewsManager recipeReviewsManager)
        {
            this.recipeManager = recipeManager;
            this.userManager = userManager;
            this.recipeReviewsManager = recipeReviewsManager;
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
                Dictionary<User, List<Recipe>> allUsersRecipes = GetAllUsersRecipes(userId);

                // Calculate similarity scores based on shared liked recipes
                var similarityScores = CalculateSimilarityScores(userLikedRecipes, allUsersRecipes);

                List<Recipe> recommendedRecipes = GetRecommendedRecipesFromScores(similarityScores, userLikedRecipes);

                return PaginateRecommendedRecipes(recommendedRecipes, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating recommendations: {ex.Message}");
                return new List<Recipe>();
            }
        }

        public int GetTotalRecommendedRecipes(User user)
        {
            try
            {
                int userId = userManager.GetIdByUsername(user.Username);
                List<Recipe> userLikedRecipes = GetUserLikedRecipes(userId);
                if (userLikedRecipes.Count == 0)
                {
                    return RecommendTrendingRecipes(1, int.MaxValue).Count;
                }

                Dictionary<User, List<Recipe>> allUsersRecipes = GetAllUsersRecipes(userId);
                var similarityScores = CalculateSimilarityScores(userLikedRecipes, allUsersRecipes);
                List<Recipe> recommendedRecipes = GetRecommendedRecipesFromScores(similarityScores, userLikedRecipes);

                return recommendedRecipes.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating total recommended recipes: {ex.Message}");
                return 0;
            }
        }
        private Dictionary<User, List<Recipe>> GetAllUsersRecipes(int userId)
        {
            return userManager.GetAllUsers()
                .Where(u => userManager.GetIdByUsername(u.Username) != userId)
                .ToDictionary(u => u, u => GetUserLikedRecipes(userManager.GetIdByUsername(u.Username)));
        }

        private List<(User User, int SharedLikedRecipesCount, List<Recipe> UserRecipesToRecommend)> CalculateSimilarityScores(
        List<Recipe> userLikedRecipes, Dictionary<User, List<Recipe>> allUsersRecipes)
        {
            return allUsersRecipes.Select(u => new
            {
                User = u.Key,
                SharedLikedRecipesCount = u.Value.Count(r => userLikedRecipes.Any(ur => IsRecipeSimilar(ur, r))),
                UserRecipesToRecommend = u.Value.Where(r => !userLikedRecipes.Any(ur => IsRecipeSimilar(ur, r))).ToList()
            })
            .OrderByDescending(u => u.SharedLikedRecipesCount)
            .Select(u => (u.User, u.SharedLikedRecipesCount, u.UserRecipesToRecommend))
            .ToList();
        }

        private List<Recipe> GetRecommendedRecipesFromScores(
        List<(User User, int SharedLikedRecipesCount, List<Recipe> UserRecipesToRecommend)> similarityScores, List<Recipe> userLikedRecipes)
        {
            HashSet<int> recommendedRecipeIds = new HashSet<int>();
            List<Recipe> recommendedRecipes = new List<Recipe>();

            foreach (var simUser in similarityScores)
            {
                foreach (var recipe in simUser.UserRecipesToRecommend)
                {
                    if (recommendedRecipeIds.Add(GetRecipeId(recipe)))
                    {
                        recommendedRecipes.Add(recipe);
                    }
                }
            }
            return recommendedRecipes;
        }

        private List<Recipe> PaginateRecommendedRecipes(List<Recipe> recommendedRecipes, int pageNumber, int pageSize)
        {
            return recommendedRecipes.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        public bool IsRecipeSimilar(Recipe one, Recipe two)
        {
            // Compare recipes by name and creator as a proxy to unique identification
            return one.RecipeName == two.RecipeName && one.Creator.Username == two.Creator.Username;
        }

        public List<Recipe> GetUserLikedRecipes(int userId)
        {
            return recipeReviewsManager.GetLikedRecipesByUser(userId);
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

    }
}
