using CookUp_Companion_BusinessLogic.Algoritam;
using CookUp_Companion_BusinessLogic.Manager;
using CookUp_Companion_BusinessLogic.Managers;
using InterfaceDAL;
using InterfacesLL;
using Logic;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MockClasses;

namespace UnitTests.Tests
{
    public class AlgoritmaTest
    {
        private const string MartinEmail = "martin@gmail.com";
        private const string DanielEmail = "daniel@gmail.com";
        private const string NicoleEmail = "nicole@example.com";

        private RecommendedRecipesByOtherUsersLikes algorithm;
        private FakeUserDALManager fakeUserDal;
        private FakeRecipeDal fakeRecipeDal;
        private UserManager userManager;
        private RecipeManager recipeManager;
        private RecipeReviewManager recipeReviewsManager;
        private FakeRecipeReviewsDal fakeRecipeReviewsDal;



        private void SetupTestData()
        {
            CreateUser("Martin", MartinEmail, "martin", "Martin", "Simeonov", 1);
            CreateUser("Daniel", DanielEmail, "daniel", "Daniel", "Gelov", 2);
            CreateUser("Nicole", NicoleEmail, "nicole", "Nicole", "Ivanova", 3);

            // Simulate some users and their liked recipes
            User user1 = userManager.GetUserByEmail(MartinEmail);
            User user2 = userManager.GetUserByEmail(DanielEmail);
            User user3 = userManager.GetUserByEmail(NicoleEmail);

            int user1Id = userManager.GetIdByUsername(user1.Username);
            int user2Id = userManager.GetIdByUsername(user2.Username);
            int user3Id = userManager.GetIdByUsername(user3.Username);


            List<Ingredient> recipe1Ingredients = new List<Ingredient>
            {
                new Ingredient(null, 1, "egg", 2, "large" ),
                new Ingredient(null, 2, "butter", 1, "knob"),
                new Ingredient(null, 3, "cream", 6, "tablespoon")
            };

            List<Ingredient> recipe2Ingredients = new List<Ingredient>
            {
                new Ingredient(null, 2, "butter", 225, "g"),
                new Ingredient(null, 4, "wheat flour", 275, "g"),
                new Ingredient(null, 5, "milk chocolate", 75, "g"),
                new Ingredient(null, 6, "sugar", 110, "g"),
                new Ingredient(null, 7, "cinnamon", 1, "tablespoon")
            };


            List<Ingredient> recipe3Ingredients = new List<Ingredient>
            {
                new Ingredient(null, 2, "butter", 225, "g"),
                new Ingredient(null, 4, "wheat flour", 275, "g"),
                new Ingredient(null, 6, "sugar", 110, "g"),
                new Ingredient(null, 7, "cinnamon", 1, "tablespoon")
            };

            recipeManager.CreateRecipe(new Recipe(null, user1, "Perfect scrambled eggs recipe", "recipeDescription", recipe1Ingredients, "recipeIncrutions", 10, 15));
            string recipe1Name = "Perfect scrambled eggs recipe";
            recipeManager.CreateRecipe(new Recipe(null, user1, "Basic cookies", "recipeDescription", recipe2Ingredients, "recipeIncrutions", 10, 15));
            string recipe2Name = "Basic cookies";
            recipeManager.CreateRecipe(new Recipe(null, user2, "Cinnamon Sugar Cookies", "recipeDescription", recipe3Ingredients, "recipeIncrutions", 10, 15));
            
            string recipe3Name = "Cinnamon Sugar Cookies";

            Recipe recipe1 = recipeManager.GetRecipeByNameAndCreator(recipe1Name, user1.Username);
            Recipe recipe2 = recipeManager.GetRecipeByNameAndCreator(recipe2Name, user1.Username);
            Recipe recipe3 = recipeManager.GetRecipeByNameAndCreator(recipe3Name, user2.Username);

            fakeRecipeReviewsDal.AddRecipe(recipe1);
            fakeRecipeReviewsDal.AddRecipe(recipe2);
            fakeRecipeReviewsDal.AddRecipe(recipe3);

            /*Add them two times to sync the data with FakeRecipeDal*/
            fakeRecipeReviewsDal.AddRecipe(recipe1);
            fakeRecipeReviewsDal.AddRecipe(recipe2);
            fakeRecipeReviewsDal.AddRecipe(recipe3);
            int recipe1Id = recipeManager.GetRecipeID(recipe1);
            int recipe2Id = recipeManager.GetRecipeID(recipe2);
            int recipe3Id = recipeManager.GetRecipeID(recipe3);

            // Simulate recipes liked by Martin
            recipeReviewsManager.AddComment(user1Id, recipe1Id, "like", "somecomment");
            recipeReviewsManager.AddComment(user1Id, recipe2Id, "like", "somecomment");

            // Simulate recipes liked by Daniel
            recipeReviewsManager.AddComment(user2Id, recipe2Id, "like", "somecomment");
            recipeReviewsManager.AddComment(user2Id, recipe3Id, "like", "somecomment");
        }
        private void CreateUser(string username, string email, string password, string firstName, string lastName, int roleId)
        {
            byte[] salt = new byte[16];
            string hashedPassword = null;
            var user = new User(null, username, email, hashedPassword, firstName, lastName, roleId, null);
            user.ChangePasswordSalt(Convert.ToBase64String(salt));
            fakeUserDal.InsertUser(user);
        }
       

        [Fact]
        public void Recommend_WithCommonInterests_ReturnsRecommendations()
        {
            // Arrange
            fakeUserDal = new FakeUserDALManager();
            fakeRecipeDal = new FakeRecipeDal();
            fakeRecipeReviewsDal = new FakeRecipeReviewsDal();
            userManager = new UserManager(fakeUserDal);
            recipeManager = new RecipeManager(fakeRecipeDal);
            recipeReviewsManager = new RecipeReviewManager(fakeRecipeReviewsDal);
            algorithm = new RecommendedRecipesByOtherUsersLikes(fakeRecipeDal, userManager, recipeReviewsManager);
            SetupTestData();

            string danielEmail = DanielEmail; // Daniel likes Cinnamon Sugar Cookies and Basic Coookie
            User user = userManager.GetUserByEmail(danielEmail);

            // Act
            List<Recipe> result = algorithm.Recommend(user, 1, 10);

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, r => r.RecipeName == "Perfect scrambled eggs recipe"); // Expect recipe liked by Martin
        }

        [Fact]
        public void Recommend_WithNoLikedRecipes_ReturnsTrendingRecipes()
        {
            // Arrange
            fakeUserDal = new FakeUserDALManager();
            fakeRecipeDal = new FakeRecipeDal();
            fakeRecipeReviewsDal = new FakeRecipeReviewsDal();
            userManager = new UserManager(fakeUserDal);
            recipeManager = new RecipeManager(fakeRecipeDal);
            recipeReviewsManager = new RecipeReviewManager(fakeRecipeReviewsDal);
            algorithm = new RecommendedRecipesByOtherUsersLikes(fakeRecipeDal, userManager, recipeReviewsManager);
            SetupTestData();

            User user = userManager.GetUserByEmail(NicoleEmail);

            // Act
            var results = algorithm.Recommend(user, 1, 10);

            // Assert
            Assert.NotEmpty(results); // Assuming some trending recipes exist
        }

        [Fact]
        public void GetUserLikedRecipes_ShouldReturnsLikedRecipes()
        {
            // Arrange
            fakeUserDal = new FakeUserDALManager();
            fakeRecipeDal = new FakeRecipeDal();
            fakeRecipeReviewsDal = new FakeRecipeReviewsDal();
            userManager = new UserManager(fakeUserDal);
            recipeManager = new RecipeManager(fakeRecipeDal);
            recipeReviewsManager = new RecipeReviewManager(fakeRecipeReviewsDal);
            algorithm = new RecommendedRecipesByOtherUsersLikes(fakeRecipeDal, userManager, recipeReviewsManager);
            SetupTestData();

            string email = MartinEmail;
            User user = userManager.GetUserByEmail(email);
            int userId = userManager.GetIdByUsername(user.Username);

            // Act
            List<Recipe> likedRecipes = algorithm.GetUserLikedRecipes(userId);

            // Assert
            Assert.Equal(2, likedRecipes.Count);

        }

        [Fact]
        public void GetUserLikedRecipes_ShouldReturnsNoRecipes()
        {
            // Arrange
            fakeUserDal = new FakeUserDALManager();
            fakeRecipeDal = new FakeRecipeDal();
            fakeRecipeReviewsDal = new FakeRecipeReviewsDal();
            userManager = new UserManager(fakeUserDal);
            recipeManager = new RecipeManager(fakeRecipeDal);
            recipeReviewsManager = new RecipeReviewManager(fakeRecipeReviewsDal);
            algorithm = new RecommendedRecipesByOtherUsersLikes(fakeRecipeDal, userManager, recipeReviewsManager);
            SetupTestData();

            string email = NicoleEmail;
            User user = userManager.GetUserByEmail(email);
            int userId = userManager.GetIdByUsername(user.Username);

            // Act
            List<Recipe> likedRecipes = algorithm.GetUserLikedRecipes(userId);

            // Assert
            Assert.True(likedRecipes.Count == 0);

        }

        [Fact]
        public void RecommendTrendingRecipesToTheUserWithNoLike_ShouldRecomendRecipe()
        {
            // Arrange
            fakeUserDal = new FakeUserDALManager();
            fakeRecipeDal = new FakeRecipeDal();
            fakeRecipeReviewsDal = new FakeRecipeReviewsDal();
            userManager = new UserManager(fakeUserDal);
            recipeManager = new RecipeManager(fakeRecipeDal);
            recipeReviewsManager = new RecipeReviewManager(fakeRecipeReviewsDal);
            algorithm = new RecommendedRecipesByOtherUsersLikes(fakeRecipeDal, userManager, recipeReviewsManager);
            SetupTestData();

            string email = NicoleEmail;
            User user = userManager.GetUserByEmail(email);
            int userId = userManager.GetIdByUsername(user.Username);
            int pageNum = 1;
            int pageSize = 10;

            // Act
            List<Recipe> recommendRecipes = algorithm.RecommendTrendingRecipes(pageNum, pageSize);

            // Assert
            Assert.True(recommendRecipes.Count > 0);
        }

        [Fact]
        public void RecommendTrendingRecipesToTheUserWithLikes_ShouldRecomendRecipe()
        {
            // Arrange
            fakeUserDal = new FakeUserDALManager();
            fakeRecipeDal = new FakeRecipeDal();
            fakeRecipeReviewsDal = new FakeRecipeReviewsDal();
            userManager = new UserManager(fakeUserDal);
            recipeManager = new RecipeManager(fakeRecipeDal);
            recipeReviewsManager = new RecipeReviewManager(fakeRecipeReviewsDal);
            algorithm = new RecommendedRecipesByOtherUsersLikes(fakeRecipeDal, userManager, recipeReviewsManager);
            SetupTestData();

            string email = DanielEmail;
            User user = userManager.GetUserByEmail(email);
            int userId = userManager.GetIdByUsername(user.Username);
            int pageNum = 1;
            int pageSize = 10;

            // Act
            List<Recipe> recommendRecipes = algorithm.RecommendTrendingRecipes(pageNum, pageSize);

            // Assert
            Assert.True(recommendRecipes.Count > 0);
        }

        [Fact]
        public void RecommendTrendingRecipesToTheUserWithInvalidrPageId_ShouldRecomendRecipe()
        {
            // Arrange
            fakeUserDal = new FakeUserDALManager();
            fakeRecipeDal = new FakeRecipeDal();
            fakeRecipeReviewsDal = new FakeRecipeReviewsDal();
            userManager = new UserManager(fakeUserDal);
            recipeManager = new RecipeManager(fakeRecipeDal);
            recipeReviewsManager = new RecipeReviewManager(fakeRecipeReviewsDal);
            algorithm = new RecommendedRecipesByOtherUsersLikes(fakeRecipeDal, userManager, recipeReviewsManager);
            SetupTestData();

            string email = DanielEmail;
            User user = userManager.GetUserByEmail(email);
            int userId = userManager.GetIdByUsername(user.Username);
            int pageNum = -1;
            int pageSize = -10;

            // Act
            List<Recipe> recommendRecipes = algorithm.RecommendTrendingRecipes(pageNum, pageSize);

            // Assert
            Assert.True(recommendRecipes.Count == 0);
        }

        [Fact]
        public void IsRecipeSimilarWithTheSameRecipe_ShouldReturnTrue()
        {
            // Arrange
            fakeUserDal = new FakeUserDALManager();
            fakeRecipeDal = new FakeRecipeDal();
            fakeRecipeReviewsDal = new FakeRecipeReviewsDal();
            userManager = new UserManager(fakeUserDal);
            recipeManager = new RecipeManager(fakeRecipeDal);
            recipeReviewsManager = new RecipeReviewManager(fakeRecipeReviewsDal);
            algorithm = new RecommendedRecipesByOtherUsersLikes(fakeRecipeDal, userManager, recipeReviewsManager);
            SetupTestData();

            Recipe recipe1 = recipeManager.GetRecipeById(1);
            Recipe recipe2 = recipeManager.GetRecipeById(1);

            // Act
            bool isRecipeSimilar = algorithm.IsRecipeSimilar(recipe1, recipe2);

            // Assert
            Assert.True(isRecipeSimilar);
        }

        [Fact]
        public void IsRecipeSimilarWithDiffRecipes_ShouldReturnFalse()
        {
            // Arrange
            fakeUserDal = new FakeUserDALManager();
            fakeRecipeDal = new FakeRecipeDal();
            fakeRecipeReviewsDal = new FakeRecipeReviewsDal();
            userManager = new UserManager(fakeUserDal);
            recipeManager = new RecipeManager(fakeRecipeDal);
            recipeReviewsManager = new RecipeReviewManager(fakeRecipeReviewsDal);
            algorithm = new RecommendedRecipesByOtherUsersLikes(fakeRecipeDal, userManager, recipeReviewsManager);
            SetupTestData();

            Recipe recipe1 = recipeManager.GetRecipeById(1);
            Recipe recipe2 = recipeManager.GetRecipeById(2);

            // Act
            bool isRecipeSimilar = algorithm.IsRecipeSimilar(recipe1, recipe2);

            // Assert
            Assert.False(isRecipeSimilar);
        }

        [Fact]
        public void GetRecipeCreateDate_ReturnsCorrectCreateDate()
        {
            // Arrange
            fakeUserDal = new FakeUserDALManager();
            fakeRecipeDal = new FakeRecipeDal();
            fakeRecipeReviewsDal = new FakeRecipeReviewsDal();
            userManager = new UserManager(fakeUserDal);
            recipeManager = new RecipeManager(fakeRecipeDal);
            recipeReviewsManager = new RecipeReviewManager(fakeRecipeReviewsDal);
            algorithm = new RecommendedRecipesByOtherUsersLikes(fakeRecipeDal, userManager, recipeReviewsManager);
            SetupTestData();

            int recipeId = 1;  // Make sure this ID is valid in your setup
            DateTime expectedDate = recipeManager.GetRecipeCreateDate(recipeId).Date;

            // Act
            DateTime createDate = algorithm.GetRecipeCreateDate(recipeId).Date;

            // Assert
            Assert.Equal(expectedDate, createDate);
        }

        [Fact]
        public void CombineRecipesForTrends_ReturnsUniqueRecipes()
        {
            // Arrange
            fakeUserDal = new FakeUserDALManager();
            fakeRecipeDal = new FakeRecipeDal();
            fakeRecipeReviewsDal = new FakeRecipeReviewsDal();
            userManager = new UserManager(fakeUserDal);
            recipeManager = new RecipeManager(fakeRecipeDal);
            recipeReviewsManager = new RecipeReviewManager(fakeRecipeReviewsDal);
            algorithm = new RecommendedRecipesByOtherUsersLikes(fakeRecipeDal, userManager, recipeReviewsManager);
            SetupTestData();

            // Act
            var combinedRecipes = algorithm.CombineRecipesForTrends(1, 10);

            // Assert
            var uniqueRecipeIds = new HashSet<int>(combinedRecipes.Select(r => algorithm.GetRecipeId(r)));
            Assert.Equal(combinedRecipes.Count, uniqueRecipeIds.Count);
        }

        [Fact]
        public void GetRecipeCreateDate_ReturnsCorrectDate()
        {
            // Arrange
            fakeUserDal = new FakeUserDALManager();
            fakeRecipeDal = new FakeRecipeDal();
            fakeRecipeReviewsDal = new FakeRecipeReviewsDal();
            userManager = new UserManager(fakeUserDal);
            recipeManager = new RecipeManager(fakeRecipeDal);
            recipeReviewsManager = new RecipeReviewManager(fakeRecipeReviewsDal);
            algorithm = new RecommendedRecipesByOtherUsersLikes(fakeRecipeDal, userManager, recipeReviewsManager);
            SetupTestData();
            int recipeId = 1;
            DateTime expectedDate = recipeManager.GetRecipeCreateDate(recipeId).Date;

            // Act
            DateTime createDate = algorithm.GetRecipeCreateDate(recipeId).Date;

            // Assert
            Assert.Equal(expectedDate, createDate);
        }

        [Fact]
        public void GetRecipeLikesAndDislikes_ReturnsCorrectCounts()
        {
            // Arrange
            fakeUserDal = new FakeUserDALManager();
            fakeRecipeDal = new FakeRecipeDal();
            fakeRecipeReviewsDal = new FakeRecipeReviewsDal();
            userManager = new UserManager(fakeUserDal);
            recipeManager = new RecipeManager(fakeRecipeDal);
            recipeReviewsManager = new RecipeReviewManager(fakeRecipeReviewsDal);
            algorithm = new RecommendedRecipesByOtherUsersLikes(fakeRecipeDal, userManager, recipeReviewsManager);
            SetupTestData();
            int recipeId = 4;

            // Act
            var (likes, dislikes) = algorithm.GetRecipeLikesAndDislikes(recipeId);

            // Assert
            Assert.Equal(1, likes);
            Assert.Equal(0, dislikes);
        }

        [Fact]
        public void GetRecipeLikesAndDislikes_ReturnsZerosForNewRecipe()
        {
            // Arrange
            fakeUserDal = new FakeUserDALManager();
            fakeRecipeDal = new FakeRecipeDal();
            fakeRecipeReviewsDal = new FakeRecipeReviewsDal();
            userManager = new UserManager(fakeUserDal);
            recipeManager = new RecipeManager(fakeRecipeDal);
            recipeReviewsManager = new RecipeReviewManager(fakeRecipeReviewsDal);
            algorithm = new RecommendedRecipesByOtherUsersLikes(fakeRecipeDal, userManager, recipeReviewsManager);
            SetupTestData();
            int newRecipeId = 10; // Assuming this is a new recipe with no interactions

            // Act
            var (likes, dislikes) = algorithm.GetRecipeLikesAndDislikes(newRecipeId);

            // Assert
            Assert.Equal(0, likes);
            Assert.Equal(0, dislikes);
        }

    }
}

