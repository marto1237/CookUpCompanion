using CookUp_Companion_BusinessLogic.Manager;
using CookUp_Companion_Classes;
using InterfaceDAL;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockClasses
{
    public class FakeRecipeDal : IRecipeDALManager
    {
        private Dictionary<int, Recipe> recipes = new Dictionary<int, Recipe>();
        private Dictionary<int, List<Comment>> commentsByRecipeId = new Dictionary<int, List<Comment>>();
        private Dictionary<int, (int Likes, int Dislikes)> likesAndDislikes = new Dictionary<int, (int, int)>();
        private Dictionary<int, List<int>> savedRecipesByUser = new Dictionary<int, List<int>>();
        private Dictionary<int, List<int>> userLikes = new Dictionary<int, List<int>>();
        private List<Ingredient> AllIngredients = new List<Ingredient>();
        private Dictionary<int, User> users = new Dictionary<int, User>();
        private Dictionary<int, DateTime> recipeCreationDates = new Dictionary<int, DateTime>();
        private Dictionary<int, List<int>> userDislikes = new Dictionary<int, List<int>>();


        private int nextRecipeId = 1;
        private int nextUserId = 1;

        public FakeRecipeDal()
        {
            // Initialize default data
            InitializeDefaultUsers();
            InitializeDefaultRecipes();
            InitializeDefaultComments();
            // Pre-populate some ingredients for testing
            AllIngredients.AddRange(new List <Ingredient> {
                new Ingredient(null, 1, "egg", 2, "large"),
                new Ingredient(null, 2, "flour", 500, "grams"),
                new Ingredient(null, 3, "sugar", 250, "grams"),
                new Ingredient(null, 4, "butter", 100, "grams"),
                new Ingredient(null, 5, "chocolate chips", 100, "grams"),
                new Ingredient(null, 6, "cinnamon", 1, "tablesppon")
                });
        }

        private void InitializeDefaultUsers()
        {
            InsertUser(new User(null, "testuser", "testuser@example.com", null, "Test", "User", 1, null));
            InsertUser(new User(null, "admin", "admin@example.com", null, "Admin", "User", 3, null));
            InsertUser(new User(null, "newUser", "newUser@example.com", null, "New", "User", 2, null));
        }

        private void InitializeDefaultRecipes()
        {
            User testUser= users[1];
            User adminUser = users[2];
            User newUser = users[3];
            List <Ingredient> recipeIngredients = new List<Ingredient>
                {
                new Ingredient(null, 1, "egg", 2, "large"),
                new Ingredient(null, 2, "butter", 1, "knob"),
                new Ingredient(null, 3, "cream", 6, "tablespoon")
                };

            Recipe recipe = new Recipe(null, testUser, "recipeName", "recipeDescription", recipeIngredients, "recipeIncrutions", 10, 15);
            InsertRecipe(recipe);

            List<Ingredient> recipeIngredients2 = new List<Ingredient>
            {
                new Ingredient(null, 2, "flour", 300, "grams"),
                new Ingredient(null, 3, "sugar", 150, "grams"),
                new Ingredient(null, 5, "chocolate chips", 100, "grams")
            };

            Recipe recipe2 = new Recipe(null, adminUser, "Chocolate Chip Cookies", "Easy and quick chocolate chip cookies.", recipeIngredients2, "recipeIncrutions", 15, 175);
            InsertRecipe(recipe2);

            List<Ingredient> recipeIngredients3 = new List<Ingredient>
            {
                new Ingredient(null, 2, "flour", 300, "grams"),
                new Ingredient(null, 3, "sugar", 150, "grams"),
                new Ingredient(null, 5, "chocolate chips", 100, "grams")
            };

            Recipe recipe3 = new Recipe(null, newUser, "Cinnamon Sugar Cookies", "Easy and quick  cookies.", recipeIngredients3, "recipeIncrutions", 20, 15);
            InsertRecipe(recipe3);
        }

        private void InitializeDefaultComments()
        {
            User testUser = users[1];
            User adminUser = users[2];
            User newUser = users[3];

            List<Comment> comments = new List<Comment>
            {
                new Comment(testUser, true, "liked the test", DateTime.Now),
                new Comment(newUser, false, "didnt like the texture", DateTime.Now)
            };
            
            InsertComments(comments);
        }

        public bool InsertUser (User user)
        {
            users[nextUserId] = user;
            nextUserId++;
            return true;
        }
        public List<Ingredient> GetAllIngredients(int page, int pageSize)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            return ingredients;
        }
        public bool InsertRecipe(Recipe recipe)
        {
            recipes[nextRecipeId] = recipe;
            recipeCreationDates[nextRecipeId] = DateTime.Now;
            nextRecipeId++;

            return true;
        }
        public bool InsertComments(List<Comment> comments)
        {

            commentsByRecipeId[1] = comments;
            return true;
        }

        public Ingredient GetInputIngredient(string ingredientName)
        {
            Ingredient ingredient = AllIngredients.FirstOrDefault(i => i.IngredientName == ingredientName);
            return ingredient;
        }

        public int GetAllIngredientsPageNum(int pageSize)
        {
            return (int)Math.Ceiling(AllIngredients.Count / (double)pageSize);
        }
        public Recipe GetRecipeById(int recipeId)
        {
            if (recipes.ContainsKey(recipeId))
            {
                return recipes[recipeId];
            }
            return null;
        }
        public Ingredient GetIngredientByName(string ingredientName)
        {
            Ingredient ingredient = AllIngredients.FirstOrDefault(i => i.IngredientName == ingredientName);
            return ingredient;
        }
        public List<Recipe> GetAllRecipes(int page, int pageSize)
        {
            // Return paginated list of recipes
            return recipes.Values.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public int GetAllRecipesPageNum(int pageSize)
        {
            return (int)Math.Ceiling(recipes.Count / (double)pageSize);
        }
        
        public bool AddComment(int userId, int recipeId, string userReaction, string commentText)
        {
            if (!users.ContainsKey(userId))
            {
                return false;  // User must exist
            }
            if (!recipes.ContainsKey(recipeId))
            {
                return false;  // Recipe must exist
            }

            if (!commentsByRecipeId.ContainsKey(recipeId))
                commentsByRecipeId[recipeId] = new List<Comment>();

            User user = users[userId];
            DateTime timestamp = DateTime.Now;
            bool isRecipeLike = userReaction == "like";
            if (!userLikes.ContainsKey(userId))
            {
                userLikes[userId] = new List<int>();
                userLikes[userId].Add(recipeId);
            }
            userLikes[userId].Add(recipeId);
            commentsByRecipeId[recipeId].Add(new Comment(user, isRecipeLike, commentText, timestamp));
            return true;
        }

        public List<Comment> GetCommentsByRecipeId(int recipeId, int page, int commentsPerPage)
        {
            if (commentsByRecipeId.TryGetValue(recipeId, out var comments))
            {
                return comments.Skip((page - 1) * commentsPerPage).Take(commentsPerPage).ToList();
            }
            else
            {
                return new List<Comment>();
            }
        }

        public (int Likes, int Dislikes) GetLikesAndDislikes(int recipeId)
        {
            if (commentsByRecipeId.TryGetValue(recipeId, out var comments))
            {
                int likes = comments.Count(comment => comment.userReaction == true);
                int dislikes = comments.Count(comment => comment.userReaction == false);
                return (likes, dislikes);
            }
            return (0, 0);
        }

        public bool ToggleFavoriteRecipe(int userId, int recipeId)
        {
            if (!savedRecipesByUser.ContainsKey(userId))
                savedRecipesByUser[userId] = new List<int>();

            if (savedRecipesByUser[userId].Contains(recipeId))
            {
                savedRecipesByUser[userId].Remove(recipeId);
                return false; // Indicating the recipe was un-favorited
            }
            else
            {
                savedRecipesByUser[userId].Add(recipeId);
                return true; // Indicating the recipe was favorited
            }
        }

        public bool CheckIfFavorite(int userId, int recipeId)
        {
            return savedRecipesByUser.TryGetValue(userId, out var recipes) && recipes.Contains(recipeId);
        }

        
        public List<Recipe> SearchRecipesByName(string searchRecipeName, int page, int pageSize)
        {
            return recipes.Values
                .Where(r => r.RecipeName.Contains(searchRecipeName, StringComparison.OrdinalIgnoreCase))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Recipe GetRecipeByNameAndCreator(string recipeName, string creatorName)
        {
            return recipes.Values.FirstOrDefault(r => r.RecipeName == recipeName && r.Creator.Username == creatorName);
        }

        public bool UpdateRecipe(int recipeId, Recipe updatedRecipe)
        {
            if (recipes.ContainsKey(recipeId))
            {
                recipes[recipeId] = updatedRecipe;
                return true;
            }
            return false;
        }
        public bool DeleteRecipe(Recipe recipe)
        {
            int recipeID = recipes.FirstOrDefault(rec => rec.Value == recipe).Key;
            return recipes.Remove(recipeID);
        }
       

        public List<Recipe> GetLikedRecipes(int page, int pageSize, int userId)
        {
            if (!userLikes.ContainsKey(userId))
            {
                return new List<Recipe>();
            }
                List<int> likedRecipeIds = userLikes[userId];
            // Convert recipe IDs to Recipe objects
            return likedRecipeIds.Select(id => recipes[id]).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public bool RemoveSavedRecipe(int userId, int recipeId)
        {
            if (savedRecipesByUser.ContainsKey(userId) && savedRecipesByUser[userId].Contains(recipeId))
            {
                savedRecipesByUser[userId].Remove(recipeId);
                return true;  // Indicate successful removal
            }
            return false;
        }
        public List<Recipe> GetSavedRecipes(int page, int pageSize, int userId)
        {
            if (savedRecipesByUser.ContainsKey(userId))
            {
                List<int> savedRecipeIds = savedRecipesByUser[userId];
                List<Recipe> savedRecipes = savedRecipeIds.Select(id => recipes[id]).Skip((page - 1) * pageSize)
                                    .Take(pageSize).ToList();
                return savedRecipes;
            }
            return new List<Recipe>();
        }
        public int GetSaveCount(int recipeId)
        {
            return savedRecipesByUser.Values.Count(savedList => savedList.Contains(recipeId));
        }

        public List<Recipe> GetRecipesAlphabetically(int page, int pageSize)
        {
            List<Recipe> orderedRecipes = recipes.Values.OrderBy(r => r.RecipeName).ToList();

            return orderedRecipes.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Recipe> GetRecipesByNewest(int page, int pageSize)
        {
            List<Recipe> newestRecipes = recipes.Keys.OrderByDescending(id => recipeCreationDates[id]).Select(id => recipes[id])
                               .Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return newestRecipes;
        }
        public List<Recipe> GetRecipesByOldest(int page, int pageSize)
        {
            List<Recipe> oldestRecipes = recipes.Keys.OrderBy(id => recipeCreationDates[id]).Select(id => recipes[id])
                               .Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return oldestRecipes;
        }
        public List<Recipe> GetRecipesByRating(int page, int pageSize)
        {
            List<Recipe> ratedRecipes = recipes.Where(r => likesAndDislikes.ContainsKey(r.Key))
            .Select(r => new {
                Recipe = r.Value,
                Rating = likesAndDislikes[r.Key].Likes - likesAndDislikes[r.Key].Dislikes})
                .OrderByDescending(r => r.Rating)  // Sorting by rating in descending order
                .Select(r => r.Recipe)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return ratedRecipes;
        }
        public List<Recipe> GetRecipesBySaves(int page, int pageSize)
        {
            return recipes.Values.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Recipe> GetRecipesCreatedByUser(int page, int pageSize, int userId)
        {

            if (users.TryGetValue(userId, out User user))
            {
                
                return recipes.Values.Where(recipe => recipe.Creator == user)
                  .Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
            return new List<Recipe>();  
        }
        public List<Recipe> GetLikedRecipesByUser(int userId)
        {
            // Check if the user has liked any recipes and return those recipes
            if (!userLikes.ContainsKey(userId))
            {
                userLikes[userId] = new List<int>();
            }
            List<int> likedRecipeIds = userLikes[userId];
            List<Recipe> likedRecipes = new List<Recipe>();
            foreach (int id in likedRecipeIds)
            {
                Recipe recipe = GetRecipeById(id);
                likedRecipes.Add(recipe);
            }

            return likedRecipes;


        }
        public List<Recipe> GetSavedRecipesByUser(int userId)
        {
            if (savedRecipesByUser.TryGetValue(userId, out var recipeIds))
            {
                return recipeIds.Select(id => recipes[id]).ToList();
            }
            return new List<Recipe>();
        }
        
        public List<Ingredient> GetAllIngredientsForRecipeId(int recipeId)
        {
            Recipe recipe = GetRecipeById(recipeId);
            if (recipe == null)
            {
                return new List<Ingredient>();
                
            }
            else
            {
                List<Ingredient> recipeIngredients = recipe.Ingredients;
                return recipeIngredients;
            }
        }

        public int GetRecipeID(Recipe recipe)
        {
            return recipes.FirstOrDefault(x => x.Value == recipe).Key;
        }
                
        public bool UpdateRecipe(string creatorUsername, string recipeName, string newRecipeName, string newRecipeDescription, string newInstructions)
        {
            // Find the user by username directly from the dictionary
            var userEntry = users.Values.FirstOrDefault(user => user.Username == creatorUsername);
            if (userEntry != null)
            {
                // Find the recipe by the original name and the user who created it
                Recipe recipeToUpdate = recipes.Values.FirstOrDefault(r => r.RecipeName == recipeName && r.Creator.Username == creatorUsername);
                if (recipeToUpdate != null)
                {
                    // Update the recipe details
                    recipeToUpdate.UpdateRecipeName(newRecipeName);
                    recipeToUpdate.UpdateDescription(newRecipeDescription);
                    recipeToUpdate.UpdateInstruction(newInstructions);
                    return true;
                }
            }
            return false;
            
        }

		public Ingredient GetIngredientById(int ingredientId)
		{
			// Simulate fetching an ingredient by ID from the preloaded list
			return AllIngredients.FirstOrDefault(ingredient => ingredient.IngredientId == ingredientId);
		}
        public int GetIngredientIdByName(string ingredientName)
        {
            return AllIngredients.FirstOrDefault(ingredient => ingredient.IngredientName == ingredientName).IngredientId;
        }
        public bool SaveUserDislike(int userId, int ingredientId)
        {
            if (!userDislikes.ContainsKey(userId))
            {
                userDislikes[userId] = new List<int>();
            }

            if (!userDislikes[userId].Contains(ingredientId))
            {
                userDislikes[userId].Add(ingredientId);
                return true;
            }

            return false;
        }
        public bool RemoveUserDislike(int userId, int ingredientId)
        {
            if (userDislikes.ContainsKey(userId) && userDislikes[userId].Contains(ingredientId))
            {
                userDislikes[userId].Remove(ingredientId);
                return true;
            }

            return false;
        }
        public List<Ingredient> GetUserDislikes(int userId)
        {
            List<Ingredient> dislikes = new List<Ingredient>();
            if (userDislikes.ContainsKey(userId))
            {
                foreach (int ingredientId in userDislikes[userId])
                {
                    Ingredient ingredient = GetIngredientById(ingredientId);
                    if (ingredient != null)
                    {
                        dislikes.Add(ingredient);
                    }
                }
            }
            return dislikes;
        }
        public DateTime GetRecipeCreateDate(int recipeID)
        {
            return DateTime.Now;
        }
    }
}
