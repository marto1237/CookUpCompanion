using CookUp_Companion_BusinessLogic.InterfacesDal;
using CookUp_Companion_BusinessLogic.InterfacesLL;
using CookUp_Companion_Classes;
using InterfaceDAL;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUp_Companion_BusinessLogic.Managers
{
    public class RecipeReviewManager : IRecipeReviewsManager
    {

        IRecipeReviewsDALManager controller;

        public RecipeReviewManager(IRecipeReviewsDALManager controller)
        {
            this.controller = controller;
        }
    
        public bool AddComment(int userID, int recipeId, string userReaction, string comment) { return controller.AddComment(userID, recipeId, userReaction, comment); }
        public List<Comment> GetCommentsByRecipeId(int recipeID, int page, int commentsPerPage) { return controller.GetCommentsByRecipeId(recipeID, page, commentsPerPage); }
        public (int Likes, int Dislikes) GetLikesAndDislikes(int recipeId) { return controller.GetLikesAndDislikes(recipeId); }

        public List<Recipe> GetLikedRecipesByUser(int userId) { return controller.GetLikedRecipesByUser(userId); }
        public List<Recipe> GetLikedRecipes(int page, int pageSize, int userId) { return controller.GetLikedRecipes(page, pageSize, userId); }
    }
}
