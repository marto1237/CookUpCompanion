using CookUp_Companion_Classes;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL
{
    public interface IRecipeDALManager
    {
        List<Ingredient> GetAllIngredients(int page, int pageSize);
        bool InsertRecipe(Recipe recipe);
        Ingredient GetInputIngredient(string name);
        int GetAllIngredientsPageNum(int pageSize);
        Ingredient GetIngredientByName(string ingredientName);
        List<Recipe> GetAllRecipes(int page, int pageSize);
        int GetAllRecipesPageNum(int pageSize);
        List<Ingredient> GetAllIngredientsForRecipeId(int recipeId);
        int GetRecipeID(Recipe recipe);
        Recipe GetRecipeById(int recipeID);
        bool AddComment(int userID, int recipeId, string userReaction, string comment);
        List<Comment> GetCommentsByRecipeId(int recipeID, int page, int commentsPerPage);
        (int Likes, int Dislikes) GetLikesAndDislikes(int recipeId);
        bool ToggleFavoriteRecipe(int userId, int recipeId);
        bool CheckIfFavorite(int userId, int recipeId);
        List<Recipe> SearchRecipesByName(string searchRecipeName, int page, int pageSize);
        Recipe GetRecipeByNameAndCreator(string recipeName, string creatorName);
        bool UpdateRecipe(string creator, string recipeName, string newRecipeName, string newRecipeDescription, string newInstructions);
        bool DeleteRecipe(Recipe recipe);
    }
}
