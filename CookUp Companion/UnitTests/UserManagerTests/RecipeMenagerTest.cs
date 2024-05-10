using CookUp_Companion_BusinessLogic.Manager;
using CookUp_Companion_Classes;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MockClasses;

namespace UnitTests.UserManagerTests
{
    public class RecipeMenagerTest
    {
        
        private RecipeManager recipeManager;
        private FakeRecipeDal fakeDal;

      

        private void SetupFakeData()
        {
            CreateUser("testuser", "testuser@example.com", "testuser123", "Test", "User", 1);
            CreateUser("admin", "admin@example.com", "adminPass123", "Admin", "User", 3);

        }

        private void CreateUser(string username, string email, string password, string firstName, string lastName, int roleId)
        {
            byte[] salt = new byte[16];
            string hashedPassword = null;
            var user = new User(null, username, email, hashedPassword, firstName, lastName, roleId, null);
            user.ChangePasswordSalt(Convert.ToBase64String(salt));
            fakeDal.InsertUser(user);
        }

        private void CreateRecipe(string username, string email, string password, string firstName, string lastName, int roleId)
        {
            User creator = new User(null, "testuser", "testuser@example.com", "testuser123", "Test", "User", 1, null);

            List<Ingredient> recipeIngredients = new List<Ingredient>
            {
                new Ingredient(null, 1, "egg", 2, "large" ),
                new Ingredient(null, 2, "butter", 1, "knob"),
                new Ingredient(null, 3, "cream", 6, "tablespoon")
            };
            // Act
            bool isAdded = recipeManager.CreateRecipe(new Recipe(null, creator, "recipeName", "recipeDescription", recipeIngredients, "recipeIncrutions", 10, 15));
            Recipe newrecipe = recipeManager.GetRecipeByNameAndCreator("recipeName", creator.Username);
            fakeDal.InsertRecipe(newrecipe);
        }
        [Fact]
        public void GetAllIngredients_ShouldReturnTrue_WhenIngredientsDoesNotExist()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int page = 1;
            int pageSize = 10;

            // Act
            List<Ingredient> existingIngredients = recipeManager.GetAllIngredients(page, pageSize);
            bool IsExistingIngredients = existingIngredients.Count() == 0;
            //Assert
            Assert.True(IsExistingIngredients);
        }

        [Fact]
        public void CreateRecipe_ShouldReturnTrue_WhenRecipeIsCreatedSuccessfully()
        {

            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            User creator = new User(null, "testuser", "testuser@example.com", "testuser123", "Test", "User", 1, null);

            List<Ingredient> recipeIngredients = new List<Ingredient>
            {
                new Ingredient(null, 1, "egg", 2, "large" ),
                new Ingredient(null, 2, "butter", 1, "knob"),
                new Ingredient(null, 3, "cream", 6, "tablespoon")
            };
            // Act
            bool result = recipeManager.CreateRecipe(new Recipe(null, creator, "recipeName", "recipeDescription", recipeIngredients, "recipeIncrutions", 10, 15));

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetInputIngredient_ShouldReturnTrue_WhenIngredientExist()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            string ingredientName = "egg";

            // Act
            Ingredient ingredient = recipeManager.GetInputIngredient(ingredientName);

            // Assert
            Assert.True(ingredient != null);

        }

        [Fact]
        public void GetInputIngredient_ShouldReturnTrue_WhenIngredientDoesNotExist()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            string ingredientName = "vanilla";

            // Act
            Ingredient result = recipeManager.GetInputIngredient(ingredientName);

            // Assert
            Assert.Null(result);

        }

        [Fact]
        public void GetAllIngredients_ShouldReturnTrue_WhenIngredientsExist()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();

            int page = 1;
            int pageSize = 10;

            // Act
            List<Ingredient> existingIngredients = recipeManager.GetAllIngredients(page, pageSize);

            //Assert
            Assert.NotNull(existingIngredients);
        }

        [Fact]
        public void GetAllIngredientsPageNum_ShouldReturnTrue_WhenValidPageNum()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int pageSize = 10;

            // Act
           int numPages = recipeManager.GetAllIngredientsPageNum(pageSize);

            //Assert
            Assert.Equal(1,numPages);
        }
        [Fact]
        public void GetAllIngredientsPageNum_ShouldReturnTrue_WhenUnvalidPageNum()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int pageSize = -10;

            // Act
            int numPages = recipeManager.GetAllIngredientsPageNum(pageSize);

            //Assert
            Assert.Equal(0, numPages);
        }

        [Fact]

        public void GetIngredientByName_WithValidIngrediensName()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            string ingredientName = "egg";

            // Act
            Ingredient searchIngredient = recipeManager.GetIngredientByName(ingredientName);

            //Assest
            Assert.True(searchIngredient != null);
        }
        [Fact]

        public void GetIngredientByName_WithUnvalidIngrediensName()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            string ingredientName = "notexistinigIngredient";

            // Act
            Ingredient searchIngredient = recipeManager.GetIngredientByName(ingredientName);

            //Assest
            Assert.False(searchIngredient != null);
        }

        [Fact]

        public void GetAllRecipes_WithValidData()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int page = 1;
            int pageSize = 10;
            int recipeNum;
            // Arrange
            User creator = new User(null, "testuser", "testuser@example.com", "testuser123", "Test", "User", 1, null);

            List<Ingredient> recipeIngredients = new List<Ingredient>
            {
                new Ingredient(null, 1, "egg", 2, "large" ),
                new Ingredient(null, 2, "butter", 1, "knob"),
                new Ingredient(null, 3, "cream", 6, "tablespoon")
            };
            // Act
            bool result = recipeManager.CreateRecipe(new Recipe(null, creator, "recipeName", "recipeDescription", recipeIngredients, "recipeIncrutions", 10, 15));

            if (result)
            {
                List<Recipe> allRecipes = recipeManager.GetAllRecipes(page, pageSize);
                recipeNum = allRecipes.Count();
            }
            else
            {
                recipeNum = 0;
            }

            //Assert
            Assert.True(recipeNum > 0);
        }

        [Fact]
        public void GetAllRecipesPageNum_WithValidPagesize()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int pageSize = 1;
            int recipeNum;
            User creator = new User(null, "testuser", "testuser@example.com", "testuser123", "Test", "User", 1, null);

            List<Ingredient> recipeIngredients = new List<Ingredient>
            {
                new Ingredient(null, 1, "egg", 2, "large" ),
                new Ingredient(null, 2, "butter", 1, "knob"),
                new Ingredient(null, 3, "cream", 6, "tablespoon")
            };
            // Act
            bool result = recipeManager.CreateRecipe(new Recipe(null, creator, "recipeName", "recipeDescription", recipeIngredients, "recipeIncrutions", 10, 15));

            if (result)
            {
               
                recipeNum = recipeManager.GetAllRecipesPageNum(pageSize);
            }

            //Act
            recipeNum = recipeManager.GetAllRecipesPageNum(pageSize);

            //Assert
            Assert.True(recipeNum > 0);
        }

        [Fact]
        public void GetAllRecipesPageNum_WithInvalidPagesize()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int pageSize = -1;


            //Act
            int recipeNum = recipeManager.GetAllRecipesPageNum(pageSize);

            //Assert
            Assert.True(recipeNum < 0);
        }

        [Fact]
        public void GetAllIngredientsForRecipeId_WithValidRecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int searchReicpeId = 1;

            //Act
            List<Ingredient> recipeIngredients = recipeManager.GetAllIngredientsForRecipeId(searchReicpeId);

            //Assert
            Assert.True(recipeIngredients.Any());
        }

        [Fact]
        public void GetAllIngredientsForRecipeId_WithInvalidRecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int searchReicpeId = 10;

            //Act
            List<Ingredient> recipeIngredients = recipeManager.GetAllIngredientsForRecipeId(searchReicpeId);

            //Assert
            Assert.True(recipeIngredients.Count() == 0);
        }

        [Fact]
        public void GetRecipeID_WithValidId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            User testUser = new User(null, "testuser", "testuser@example.com", null, "Test", "User", 1, null);
            List<Ingredient> recipeIngredients = new List<Ingredient>
                {
                new Ingredient(null, 1, "egg", 2, "large"),
                new Ingredient(null, 2, "butter", 1, "knob"),
                new Ingredient(null, 3, "cream", 6, "tablespoon")
                };

            Recipe recipe = new Recipe(null, testUser, "recipeName", "recipeDescription", recipeIngredients, "recipeIncrutions", 10, 15);
            fakeDal.InsertRecipe(recipe);
            //Act
            int recipeId = recipeManager.GetRecipeID(recipe);

            //Assert
            Assert.True(recipeId > 0);

        }

        [Fact]
        public void GetRecipeById_WithValidRecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int recipId = 1;

            //Act 
            Recipe recipe = recipeManager.GetRecipeById(recipId);

            //Assert
            Assert.NotNull(recipe);
        }

        [Fact]
        public void GetRecipeById_WithUnvalidRecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int recipId = 99;

            //Act 
            Recipe recipe = recipeManager.GetRecipeById(recipId);

            //Assert
            Assert.Null(recipe);
        }

        [Fact]
        public void AddComment_WithValidUserAndRecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int recipeId = 1;
            //Act 
            bool isAddedComment = recipeManager.AddComment(userId,recipeId, "like", "somecomment");

            //Assert
            Assert.True(isAddedComment);
        }

        [Fact]
        public void AddComment_WithInvalidRecipeAndRecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = -1;
            int recipeId = -1;
            //Act 
            bool isAddedComment = recipeManager.AddComment(userId, recipeId, "like", "somecomment");

            //Assert
            Assert.False(isAddedComment);
        }
        [Fact]
        public void GetCommentsByRecipeId_WithValidIds()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int recipeId = 1;
            int page = 1;
            int commentsPerPage = 10;

            //Act
            List<Comment> comments = recipeManager.GetCommentsByRecipeId(recipeId, page, commentsPerPage);

            //Assert
            Assert.True(comments.Count() > 0);
        }

        [Fact]
        public void GetCommentsByRecipeId_WithInvalidRecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int recipeId = 99;
            int page = 1;
            int commentsPerPage = 10;

            //Act
            List<Comment> comments = recipeManager.GetCommentsByRecipeId(recipeId, page, commentsPerPage);

            //Assert
            Assert.False(comments.Count() > 0);
        }

        [Fact]
        public void GetLikesAndDislikes_WithValid_RecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int recipeId = 1;

            //Act
            (int Likes, int Dislikes) = recipeManager.GetLikesAndDislikes(recipeId);

            //Assert
            Assert.Equal(1, Likes);
            Assert.Equal(1, Dislikes);
        }

        [Fact]
        public void GetLikesAndDislikes_WithUnvalid_RecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int recipeId = 99;

            //Act
            (int Likes, int Dislikes) = recipeManager.GetLikesAndDislikes(recipeId);

            //Assert
            Assert.Equal(0, Likes);
            Assert.Equal(0, Dislikes);
        }

        [Fact]
        public void ToggleFavoriteRecipe_WithValidRecipeAndUserId_Favourite()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int recipeId = 1;

            //Act
            bool toggle =  recipeManager.ToggleFavoriteRecipe(userId, recipeId);

            //Assert
            Assert.True(toggle);
        }

        [Fact]
        public void ToggleFavoriteRecipe_WithValidRecipeAndUserId_Unfavourite()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int recipeId = 1;

            //Act
            bool toggle = recipeManager.ToggleFavoriteRecipe(userId, recipeId);
            toggle = recipeManager.ToggleFavoriteRecipe(userId, recipeId);

            //Assert
            Assert.False(toggle);
        }

        [Fact]
        public void CheckIfFavorite_WhenRecipeIsFavourite()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int recipeId = 1;

            //Act
            bool toggle = recipeManager.ToggleFavoriteRecipe(userId, recipeId);
            bool isFavourite = recipeManager.CheckIfFavorite(userId, recipeId);

            //Assert
            Assert.True(isFavourite);
        }

        [Fact]
        public void CheckIfFavorite_WhenRecipeIsUnfavourite()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int recipeId = 1;

            //Act
            bool toggle = recipeManager.ToggleFavoriteRecipe(userId, recipeId);
            toggle = recipeManager.ToggleFavoriteRecipe(userId, recipeId);
            bool isFavourite = recipeManager.CheckIfFavorite(userId, recipeId);

            //Assert
            Assert.False(isFavourite);
        }

        [Fact]
        public void SearchRecipesByName_WithValidRecipeName()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            string searchRecipeName = "recipeName";
            int page = 1;
            int pageSize = 10;

            //Act
            List<Recipe> searchResult = recipeManager.SearchRecipesByName(searchRecipeName, page, pageSize);

            //Assert
            Assert.Equal(1, searchResult.Count);
        }

        [Fact]
        public void SearchRecipesByName_WithUnvalidRecipeName()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            string searchRecipeName = "somenotexistingNAME";
            int page = 1;
            int pageSize = 10;

            //Act
            List<Recipe> searchResult = recipeManager.SearchRecipesByName(searchRecipeName, page, pageSize);

            //Assert
            Assert.Equal(0, searchResult.Count);
        }

        [Fact]
        public void GetRecipeByNameAndCreator_WithValidNames()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            string searchRecipename = "recipeName";
            string creatorName = "testuser";

            //Act 
            Recipe RecipeMatch = recipeManager.GetRecipeByNameAndCreator(searchRecipename, creatorName);

            //Assert
            Assert.NotNull(RecipeMatch);
        }

        [Fact]
        public void GetRecipeByNameAndCreator_WithInvalidNames()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            string searchRecipename = "fakerecipeName";
            string creatorName = "fakeuser";

            //Act 
            Recipe RecipeMatch = recipeManager.GetRecipeByNameAndCreator(searchRecipename, creatorName);

            //Assert
            Assert.Null(RecipeMatch);
        }

        [Fact]
        public void UpdateRecipe_WithValidData()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            string creator = "testuser";
            string recipeName = "recipeName";
            string newRecipeName = "newRecipeName";
            string newRecipeDescription = "newRecipeDescriotin";
            string newInstructions = "newRecipeInstructions";

            //Act

            bool result = recipeManager.UpdateRecipe(creator, recipeName, newRecipeName, newRecipeDescription, newInstructions);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateRecipe_WithInvalidData()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            string creator = "somenotexistingNAME";
            string recipeName = "fakerecipeName";
            string newRecipeName = "newRecipeName";
            string newRecipeDescription = "newRecipeDescriotin";
            string newInstructions = "newRecipeInstructions";

            //Act

            bool result = recipeManager.UpdateRecipe(creator, recipeName, newRecipeName, newRecipeDescription, newInstructions);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void DeleteRecipe()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            User deleteUser = new User(null, "deleteuser", "deleteuser@example.com", null, "Delete", "User", 1, null);
            fakeDal.InsertUser(deleteUser);
            List<Ingredient> recipeIngredients = new List<Ingredient>
                {
                new Ingredient(null, 1, "egg", 2, "large"),
                new Ingredient(null, 2, "butter", 1, "knob"),
                new Ingredient(null, 3, "cream", 6, "tablespoon")
                };

            Recipe recipe = new Recipe(null, deleteUser, "recipeName", "recipeDescription", recipeIngredients, "recipeIncrutions", 10, 15);
            fakeDal.InsertRecipe(recipe);

            //Act 
           bool result =  recipeManager.DeleteRecipe(recipe);
           
            //Assert
           Assert.True(result);
        }

        [Fact]
        public void GetLikedRecipesByUse_WithValidUserID()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int recipeId = 1;

            //Act 
            bool isAddedComment = recipeManager.AddComment(userId, recipeId, "like", "somecomment");
            List<Recipe> likedRecipes = recipeManager.GetLikedRecipesByUser(userId);

            //Assert
            Assert.True(likedRecipes.Count() > 0);
        }

        [Fact]
        public void GetLikedRecipesByUser_WithInvalidUserID()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int recipeId = 1;

            //Act 
            bool isAddedComment = recipeManager.AddComment(userId, recipeId, "like", "somecomment");
            List<Recipe> likedRecipes = recipeManager.GetLikedRecipesByUser(99);

            //Assert
            Assert.False(likedRecipes.Count() > 0);
        }

        [Fact]
        public void GetLikedRecipes_WithValidUserID()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int page = 1;
            int pageSize = 10;
            int userId = 1;
            int recipeId = 1;

            //Act
            bool isAddedComment = recipeManager.AddComment(userId, recipeId, "like", "somecomment");
            // FAKE userid 99
            List<Recipe> recipes = recipeManager.GetLikedRecipes(page, pageSize, userId);

            //Assert
            Assert.True((recipes.Count() > 0));

        }

        [Fact]
        public void GetLikedRecipes_WithInvalidUserID()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int page = 1;
            int pageSize = 10;
            int userId = 1;
            int recipeId = 1;

            //Act
            bool isAddedComment = recipeManager.AddComment(userId, recipeId, "like", "somecomment");
            // FAKE userid 99
            List<Recipe> recipes = recipeManager.GetLikedRecipes(page, pageSize, 99);

            //Assert
            Assert.False((recipes.Count() > 0));

        }

        [Fact]
        public void RemoveSavedRecipe_WithValidIDS()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int recipeId = 1;

            //Act
            recipeManager.ToggleFavoriteRecipe(userId, recipeId);
            bool IsRemovedRecipeSaved = recipeManager.RemoveSavedRecipe(userId, recipeId);

            //Assert
            Assert.True(IsRemovedRecipeSaved);
        }

        [Fact]
        public void RemoveSavedRecipe_WithInvalidIDS()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int recipeId = 1;

            //Act
            recipeManager.ToggleFavoriteRecipe(userId, recipeId);
            //Fake ids
            bool IsRemovedRecipeSaved = recipeManager.RemoveSavedRecipe(99, 99);

            //Assert
            Assert.False(IsRemovedRecipeSaved);
        }

        [Fact]
        public void GetSavedRecipes_WithValidUserId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int page = 1; 
            int pageSize = 10; 
            int userId = 1;
            int recipeId = 1;

            //Act
            recipeManager.ToggleFavoriteRecipe(userId, recipeId);
            List<Recipe> savedRecipes = recipeManager.GetSavedRecipes(page,pageSize, userId);

            //Assert
            Assert.True(savedRecipes.Count() > 0);
        }

        [Fact]
        public void GetSavedRecipes_WithInvalidUserId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int page = 1;
            int pageSize = 10;
            int userId = 1;
            int recipeId = 1;

            //Act
            recipeManager.ToggleFavoriteRecipe(userId, recipeId);
            //Fake ids
            List<Recipe> savedRecipes = recipeManager.GetSavedRecipes(page, pageSize, 99);

            //Assert
            Assert.False(savedRecipes.Count() > 0);
        }

        [Fact]
        public void GetSaveCount_WithValidRecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int recipeId = 1;

            //Act
            recipeManager.ToggleFavoriteRecipe(userId, recipeId);
            int savedCount = recipeManager.GetSaveCount(recipeId);

            //Assert
            Assert.True(savedCount > 0);
        }

        [Fact]
        public void GetSaveCount_WithInvalidRecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int recipeId = 1;

            //Act
            recipeManager.ToggleFavoriteRecipe(userId, recipeId);
            int savedCount = recipeManager.GetSaveCount(99);

            //Assert
            Assert.False(savedCount > 0);
        }

        [Fact]
        public void GetRecipesCreatedByUser_WithValidUserId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int page = 1;
            int pageSize = 1;
            int userId = 1;

            //Act
            List<Recipe> createdRecipes = recipeManager.GetRecipesCreatedByUser(page,pageSize, userId);

            //Assert
            Assert.True(createdRecipes.Count() > 0);
        }

        [Fact]
        public void GetRecipesCreatedByUser_WithInvalidUserId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int page = 1;
            int pageSize = 1;
            int userId = 1;

            //Act
            List<Recipe> createdRecipes = recipeManager.GetRecipesCreatedByUser(page, pageSize, 99);

            //Assert
            Assert.False(createdRecipes.Count() > 0);
        }

        [Fact]
        public void GetSavedRecipesByUser_WithValidUserId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int recipeId = 1;

            //Act
            recipeManager.ToggleFavoriteRecipe(userId, recipeId);
            List<Recipe> savedRecipes = recipeManager.GetSavedRecipesByUser(userId);

            //Assert
            Assert.True(savedRecipes.Count() > 0);
        }

        [Fact]
        public void GetSavedRecipesByUser_WithInvalidUserId()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int recipeId = 1;

            //Act
            recipeManager.ToggleFavoriteRecipe(userId, recipeId);
            //Fake userid
            List<Recipe> savedRecipes = recipeManager.GetSavedRecipesByUser(99);

            //Assert
            Assert.False(savedRecipes.Count() > 0);
        }

        [Fact]
        public void GetRecipesByNewest()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int page = 1;
            int pageSize = 10;

            //Act 
            List<Recipe> recipes = recipeManager.GetRecipesByNewest(page, pageSize);

            //Assert
            Assert.True((recipes.Count() > 0));
        }

        [Fact]
        public void GetRecipesByOldest()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int page = 1;
            int pageSize = 10;

            //Act 
            List<Recipe> recipes = recipeManager.GetRecipesByOldest(page, pageSize);

            //Assert
            Assert.True((recipes.Count() > 0));
        }

        [Fact]
        public void GetRecipesBySaves()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int page = 1;
            int pageSize = 10;

            //Act 
            List<Recipe> recipes = recipeManager.GetRecipesBySaves(page, pageSize);

            //Assert
            Assert.True((recipes.Count() > 0));
        }
        [Fact]
        public void GetRecipesAlphabetically()
        {
            //Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int page = 1;
            int pageSize = 10;

            //Act 
            List<Recipe> recipes = recipeManager.GetRecipesAlphabetically(page, pageSize);

            //Assert
            Assert.True((recipes.Count() > 0));
        }

        [Fact]
        public void SaveUserDislike_ShouldReturnTrue_WhenDislikeIsNew()
        {
            // Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int ingredientId = 2;  // Assuming ingredient with ID 2 exists

            // Act
            bool result = recipeManager.SaveUserDislike(userId, ingredientId);

            // Assert
            Assert.True(result, "Dislike should be successfully saved when it is new.");
        }

        [Fact]
        public void SaveUserDislike_ShouldReturnFalse_WhenDislikeAlreadyExists()
        {
            // Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int ingredientId = 2;  // Assuming ingredient with ID 2 exists

            // Act
            bool firstAttempt = recipeManager.SaveUserDislike(userId, ingredientId);
            bool secondAttempt = recipeManager.SaveUserDislike(userId, ingredientId);

            // Assert
            Assert.False(secondAttempt, "Dislike should not be saved again if it already exists.");
        }

        [Fact]
        public void RemoveUserDislike_ShouldReturnTrue_WhenDislikeExists()
        {
            // Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int ingredientId = 2;  // Assuming ingredient with ID 2 exists

            // Setup initial dislike
            recipeManager.SaveUserDislike(userId, ingredientId);

            // Act
            bool result = recipeManager.RemoveUserDislike(userId, ingredientId);

            // Assert
            Assert.True(result, "Dislike should be removed successfully if it exists.");
        }

        [Fact]
        public void RemoveUserDislike_ShouldReturnFalse_WhenDislikeDoesNotExist()
        {
            // Arrange
            fakeDal = new FakeRecipeDal();
            recipeManager = new RecipeManager(fakeDal);
            SetupFakeData();
            int userId = 1;
            int ingredientId = 2;  // Assuming ingredient with ID 2 exists, but not disliked initially

            // Act
            bool result = recipeManager.RemoveUserDislike(userId, ingredientId);

            // Assert
            Assert.False(result, "Should return false when trying to remove a dislike that does not exist.");
        }

    }
}
