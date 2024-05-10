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
                var recommendedRecipes = new List<Recipe>();

                foreach (var simUser in similarityScores)
                {
                    // Add recipes liked by the current user but not by the similar user
                    recommendedRecipes.AddRange(simUser.UserRecipesToRecommend);
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

        private bool IsRecipeSimilar(Recipe one, Recipe two)
        {
            // Compare recipes by name and creator as a proxy to unique identification
            return one.RecipeName == two.RecipeName && one.Creator.Username == two.Creator.Username;
        }

        private List<Recipe> GetUserLikedRecipes(int userId)
        {
            return recipeManager.GetLikedRecipesByUser(userId);
        }
    }
}
