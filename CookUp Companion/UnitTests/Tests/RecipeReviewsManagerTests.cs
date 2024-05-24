using CookUp_Companion_BusinessLogic.Manager;
using CookUp_Companion_BusinessLogic.Managers;
using CookUp_Companion_Classes;
using InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MockClasses;

namespace UnitTests.Tests
{
    public class RecipeReviewsManagerTests
    {
        private RecipeReviewManager recipeReviewsManager;
        private FakeRecipeReviewsDal fakeDal;



        [Fact]
        public void AddComment_WithValidData_ShouldReturnTrue()
        {
            // Arrange
            fakeDal = new FakeRecipeReviewsDal();
            recipeReviewsManager = new RecipeReviewManager(fakeDal);
            int userId = 1;
            int recipeId = 1;
            string userReaction = "like";
            string commentText = "Great recipe!";

            // Act
            bool result = recipeReviewsManager.AddComment(userId, recipeId, userReaction, commentText);

            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void AddComment_WithValidUserAndRecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeReviewsDal();
            recipeReviewsManager = new RecipeReviewManager(fakeDal);
            int userId = 1;
            int recipeId = 1;
            //Act 
            bool isAddedComment = recipeReviewsManager.AddComment(userId, recipeId, "like", "somecomment");

            //Assert
            Assert.True(isAddedComment);
        }
        [Fact]
        public void GetCommentsByRecipeId_WithValidData_ShouldReturnComments()
        {
            // Arrange
            fakeDal = new FakeRecipeReviewsDal();
            recipeReviewsManager = new RecipeReviewManager(fakeDal);
            int userId = 1;
            int recipeId = 1;
            string userReaction = "like";
            string commentText = "Great recipe!";
            recipeReviewsManager.AddComment(userId, recipeId, userReaction, commentText);
            int page = 1;
            int commentsPerPage = 10;

            // Act
            List<Comment> comments = recipeReviewsManager.GetCommentsByRecipeId(recipeId, page, commentsPerPage);

            // Assert
            Assert.Single(comments);
            Assert.Equal(commentText, comments[0].comment);
        }


        [Fact]
        public void GetCommentsByRecipeId_WithNoComments_ShouldReturnEmptyList()
        {
            // Arrange
            fakeDal = new FakeRecipeReviewsDal();
            recipeReviewsManager = new RecipeReviewManager(fakeDal);
            int recipeId = 1;
            int page = 1;
            int commentsPerPage = 10;

            // Act
            List<Comment> comments = recipeReviewsManager.GetCommentsByRecipeId(recipeId, page, commentsPerPage);

            // Assert
            Assert.Empty(comments);
        }

        [Fact]
        public void GetLikesAndDislikes_WithValidData_ShouldReturnCounts()
        {
            // Arrange
            fakeDal = new FakeRecipeReviewsDal();
            recipeReviewsManager = new RecipeReviewManager(fakeDal);
            int userId = 1;
            int recipeId = 1;
            string userReaction = "like";
            string commentText = "Great recipe!";
            recipeReviewsManager.AddComment(userId, recipeId, userReaction, commentText);

            // Act
            var (likes, dislikes) = recipeReviewsManager.GetLikesAndDislikes(recipeId);

            // Assert
            Assert.Equal(1, likes);
            Assert.Equal(0, dislikes);
        }

        [Fact]
        public void GetLikesAndDislikes_WithNoComments_ShouldReturnZeroCounts()
        {
            // Arrange
            fakeDal = new FakeRecipeReviewsDal();
            recipeReviewsManager = new RecipeReviewManager(fakeDal);
            int recipeId = 1;

            // Act
            var (likes, dislikes) = recipeReviewsManager.GetLikesAndDislikes(recipeId);

            // Assert
            Assert.Equal(0, likes);
            Assert.Equal(0, dislikes);
        }
        

        
        [Fact]
        public void GetCommentsByRecipeId_WithValidIds()
        {
            //Arrange
            fakeDal = new FakeRecipeReviewsDal();
            recipeReviewsManager = new RecipeReviewManager(fakeDal);
            int userId = 1;
            int recipeId = 1;
            int page = 1;
            int commentsPerPage = 10;
            string userReaction = "like";
            string commentText = "Great recipe!";
            recipeReviewsManager.AddComment(userId, recipeId, userReaction, commentText);

            //Act
            List<Comment> comments = recipeReviewsManager.GetCommentsByRecipeId(recipeId, page, commentsPerPage);

            //Assert
            Assert.True(comments.Count() > 0);
        }

        [Fact]
        public void GetCommentsByRecipeId_WithInvalidRecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeReviewsDal();
            recipeReviewsManager = new RecipeReviewManager(fakeDal);
            int userId = 1;
            int fakeRecipeId = -1;
            int recipeId = 1;
            int page = 1;
            int commentsPerPage = 10;
            string userReaction = "like";
            string commentText = "Great recipe!";
            recipeReviewsManager.AddComment(userId, recipeId, userReaction, commentText);

            //Act
            List<Comment> comments = recipeReviewsManager.GetCommentsByRecipeId(fakeRecipeId, page, commentsPerPage);

            //Assert
            Assert.False(comments.Count() > 0);
        }

        [Fact]
        public void GetLikesAndDislikes_WithValid_RecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeReviewsDal();
            recipeReviewsManager = new RecipeReviewManager(fakeDal);
            int userId = 1;
            int recipeId = 1;
            string userReaction = "like";
            string commentText = "Great recipe!";
            recipeReviewsManager.AddComment(userId, recipeId, userReaction, commentText);

            //Act
            (int Likes, int Dislikes) = recipeReviewsManager.GetLikesAndDislikes(recipeId);

            //Assert
            Assert.Equal(1, Likes);
            Assert.Equal(0, Dislikes);
        }

        [Fact]
        public void GetLikesAndDislikes_WithUnvalid_RecipeId()
        {
            //Arrange
            fakeDal = new FakeRecipeReviewsDal();
            recipeReviewsManager = new RecipeReviewManager(fakeDal);
            int userId = 1;
            int recipeId = 1;
            int fakeRecipeID = -1;
            string userReaction = "like";
            string commentText = "Great recipe!";
            recipeReviewsManager.AddComment(userId, recipeId, userReaction, commentText);

            // Act
            var (likes, dislikes) = recipeReviewsManager.GetLikesAndDislikes(fakeRecipeID);

            // Assert
            Assert.Equal(0, likes);
            Assert.Equal(0, dislikes);

        }
    }
}
