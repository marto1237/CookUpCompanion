using CookUp_Companion_Classes;
using InterfaceDAL;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUp_Companion_BusinessLogic.Manager
{
    public class RecipeManager : IRecipeManager
    {

        IRecipeDALManager controller;

        public RecipeManager(IRecipeDALManager controller)
        {
            this.controller = controller;
        }
        public bool CreateRecipe(Recipe recipe)
        {
            return controller.InsertRecipe(recipe);
        }

        public Ingredient GetInputIngredient(string name) { return controller.GetInputIngredient(name); }

        public List<Ingredient> GetAllIngredients(int page, int pageSize) { return controller.GetAllIngredients(page, pageSize); }

        public int GetAllIngredientsPageNum(int pageSize) { return controller.GetAllIngredientsPageNum(pageSize); }

        public Ingredient GetIngredientByName(string ingredientName) { return controller.GetIngredientByName(ingredientName); }

        public List<Recipe> GetAllRecipes(int page, int pageSize) { return controller.GetAllRecipes(page, pageSize); }
        public int GetAllRecipesPageNum(int pageSize) { return controller.GetAllRecipesPageNum(pageSize); }
        public List<Ingredient> GetAllIngredientsForRecipeId(int recipeId) { return controller.GetAllIngredientsForRecipeId(recipeId); }
        public int GetRecipeID(Recipe recipe) { return controller.GetRecipeID(recipe); }
        public Recipe GetRecipeById(int recipeID) { return controller.GetRecipeById(recipeID); }
        public bool AddComment(int userID, int recipeId, string userReaction, string comment) { return controller.AddComment(userID, recipeId, userReaction, comment); }
        public List<Comment> GetCommentsByRecipeId(int recipeID, int page, int commentsPerPage) { return controller.GetCommentsByRecipeId(recipeID, page, commentsPerPage); }
        public (int Likes, int Dislikes) GetLikesAndDislikes(int recipeId) { return controller.GetLikesAndDislikes(recipeId); }
        public bool ToggleFavoriteRecipe(int userId, int recipeId) { return controller.ToggleFavoriteRecipe(userId, recipeId); }
        public bool CheckIfFavorite(int userId, int recipeId) { return controller.CheckIfFavorite(userId, recipeId); }
    }
}
