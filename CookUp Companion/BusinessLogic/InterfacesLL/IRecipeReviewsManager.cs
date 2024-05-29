using CookUp_Companion_Classes;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUp_Companion_BusinessLogic.InterfacesLL
{
    public interface IRecipeReviewsManager
    {
        bool AddComment(int userID, int recipeId, string userReaction, string comment);
        List<Comment> GetCommentsByRecipeId(int recipeID, int page, int commentsPerPage);
        (int Likes, int Dislikes) GetLikesAndDislikes(int recipeId);
        List<Recipe> GetLikedRecipesByUser(int userId);
        List<Recipe> GetLikedRecipes(int page, int pageSize, int userId);
        int GetLikedRecipesPageNum(int pageSize, int userId);
    }
}
