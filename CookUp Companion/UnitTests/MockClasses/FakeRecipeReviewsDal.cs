using CookUp_Companion_BusinessLogic.InterfacesDal;
using CookUp_Companion_Classes;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.MockClasses
{
    public class FakeRecipeReviewsDal : IRecipeReviewsDALManager
    {
        private Dictionary<int, List<Comment>> commentsByRecipeId = new Dictionary<int, List<Comment>>();
        private Dictionary<int, (int Likes, int Dislikes)> likesAndDislikes = new Dictionary<int, (int, int)>();
        private Dictionary<int, List<int>> userLikes = new Dictionary<int, List<int>>();
        private Dictionary<int, List<int>> userDislikes = new Dictionary<int, List<int>>();
        private Dictionary<int, Recipe> recipes = new Dictionary<int, Recipe>();
        private Dictionary<int, User> users = new Dictionary<int, User>();

        private int nextRecipeId = 1;
        private int nextUserId = 1;



        public bool AddComment(int userId, int recipeId, string userReaction, string commentText)
        {
            if (!commentsByRecipeId.ContainsKey(recipeId))
                commentsByRecipeId[recipeId] = new List<Comment>();

            User user = GetUserById(userId);
            DateTime timestamp = DateTime.Now;
            bool isRecipeLike = userReaction == "like";

            commentsByRecipeId[recipeId].Add(new Comment(user, isRecipeLike, commentText, timestamp));

            if (!likesAndDislikes.ContainsKey(recipeId))
                likesAndDislikes[recipeId] = (0, 0);

            var (likes, dislikes) = likesAndDislikes[recipeId];
            if (isRecipeLike)
                likes++;
            else
                dislikes++;

            likesAndDislikes[recipeId] = (likes, dislikes);

            if (isRecipeLike)
            {
                if (!userLikes.ContainsKey(userId))
                    userLikes[userId] = new List<int>();
                if (!userLikes[userId].Contains(recipeId))
                    userLikes[userId].Add(recipeId);
            }

            return true;
        }

        public List<Comment> GetCommentsByRecipeId(int recipeId, int page, int commentsPerPage)
        {
            if (commentsByRecipeId.TryGetValue(recipeId, out var comments))
            {
                return comments.Skip((page - 1) * commentsPerPage).Take(commentsPerPage).ToList();
            }
            return new List<Comment>();
        }

        public (int Likes, int Dislikes) GetLikesAndDislikes(int recipeId)
        {
            if (likesAndDislikes.TryGetValue(recipeId, out var result))
            {
                return result;
            }
            return (0, 0);
        }

        public List<Recipe> GetLikedRecipesByUser(int userId)
        {
            if (!userLikes.ContainsKey(userId))
            {
                return new List<Recipe>();
            }

            List<int> likedRecipeIds = userLikes[userId];
            return likedRecipeIds.Select(id => GetRecipeById(id)).ToList();
        }

        // Helper methods to manage users and recipes directly within this class

        public User GetUserById(int userId)
        {
            if (!users.ContainsKey(userId))
            {
                User user = new User(null, "User" + userId, "user" + userId + "@example.com", null, "FirstName" + userId, "LastName" + userId, 1, null);
                users[userId] = user;
                nextUserId++;
            }
            return users[userId];
        }

        public Recipe GetRecipeById(int recipeId)
        {
            if (recipes.ContainsKey(recipeId))
            {
                return recipes[recipeId];
            }
            return null; // or throw an exception if preferred
        }


        public void AddRecipe(Recipe recipe)
        {
            if (!recipes.ContainsKey(nextRecipeId))
            {
                recipes[nextRecipeId] = recipe;
                nextRecipeId++;
            }
        }

        public List<Recipe> GetLikedRecipes(int page, int pageSize, int userId)
        {
            if (!userLikes.ContainsKey(userId))
            {
                return new List<Recipe>();
            }

            List<int> likedRecipeIds = userLikes[userId];
            return likedRecipeIds.Skip((page - 1) * pageSize).Take(pageSize).Select(id => GetRecipeById(id)).ToList();
        }
        public int GetLikedRecipesPageNum(int pageSize, int userId)
        {
            // Assuming that 'userLikes' holds recipe IDs liked by each user
            int totalLikedRecipes = userLikes.ContainsKey(userId) ? userLikes[userId].Count : 0;
            return (int)Math.Ceiling((double)totalLikedRecipes / pageSize);
        }

        public int GetSavedRecipesPageNum(int pageSize, int userId)
        {
            // Assuming you need to add logic to maintain saved recipes, for now returning zero
            // Add appropriate logic based on how your application handles "saved recipes"
            return 0;
        }

        public int GetCreatedRecipesPageNum(int pageSize, int userId)
        {
            // Assuming 'recipes' holds all recipes and you track the creator, 
            // we'll count recipes created by the user
            int totalSavedRecipes = 0; // Placeholder
            return (int)Math.Ceiling((double)totalSavedRecipes / pageSize);
        }

    }
}
