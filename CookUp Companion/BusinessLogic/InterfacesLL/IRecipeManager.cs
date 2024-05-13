using CookUp_Companion_Classes;
using Logic;

namespace InterfacesLL
{
    public interface IRecipeManager
    {
        List<Ingredient> GetAllIngredients(int page, int pageSize);
        Ingredient GetInputIngredient(string name);
        bool CreateRecipe(Recipe recipe);
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
        List<Recipe> GetLikedRecipesByUser(int userId);
        List<Recipe> GetLikedRecipes(int page, int pageSize, int userId);
        bool RemoveSavedRecipe(int userId, int recipeId);
        List<Recipe> GetSavedRecipes(int page, int pageSize, int userId);
        int GetSaveCount(int recipeId);
        List<Recipe> GetRecipesAlphabetically(int page, int pageSize);
        List<Recipe> GetRecipesByNewest(int page, int pageSize);
        List<Recipe> GetRecipesByOldest(int page, int pageSize);
        List<Recipe> GetRecipesByRating(int page, int pageSize);
        List<Recipe> GetRecipesBySaves(int page, int pageSize);
        List<Recipe> GetRecipesCreatedByUser(int page, int pageSize, int userId);
        List<Recipe> GetSavedRecipesByUser(int userId);
        Ingredient GetIngredientById(int ingredientId);
        int GetIngredientIdByName(string ingredientName);
        bool SaveUserDislike(int userId, int ingredientId);
        List<Ingredient> GetUserDislikes(int userId);
        bool RemoveUserDislike(int userId, int ingredientId);
        DateTime GetRecipeCreateDate(int recipeID);

    }
}
