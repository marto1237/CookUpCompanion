﻿using CookUp_Companion_Classes;
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
        public List<Recipe> SearchRecipesByName(string searchRecipeName, int page, int pageSize) { return controller.SearchRecipesByName(searchRecipeName, page, pageSize); }
        public Recipe GetRecipeByNameAndCreator(string recipeName, string creatorName) { return controller.GetRecipeByNameAndCreator(recipeName, creatorName); }
        public bool UpdateRecipe(string creator, string recipeName, string newRecipeName, string newRecipeDescription, string newInstructions)
        { return controller.UpdateRecipe(creator, recipeName, newRecipeName, newRecipeDescription, newInstructions); }
        public bool DeleteRecipe(Recipe recipe) { return controller.DeleteRecipe(recipe); }
        public List<Recipe> GetLikedRecipesByUser(int userId) { return controller.GetLikedRecipesByUser(userId); }
        public List<Recipe> GetLikedRecipes(int page, int pageSize, int userId) { return controller.GetLikedRecipes(page, pageSize, userId); }
        public bool RemoveSavedRecipe(int userId, int recipeId) { return controller.RemoveSavedRecipe(userId, recipeId); }
        public List<Recipe> GetSavedRecipes(int page, int pageSize, int userId) { return  controller.GetSavedRecipes(page, pageSize, userId); } 
        public int GetSaveCount(int recipeId) { return controller.GetSaveCount(recipeId); }
        public List<Recipe> GetRecipesAlphabetically(int page, int pageSize) { return controller.GetRecipesAlphabetically(page, pageSize); }
        public List<Recipe> GetRecipesByNewest(int page, int pageSize) { return controller.GetRecipesByNewest(page, pageSize); }
        public List<Recipe> GetRecipesByOldest(int page, int pageSize) { return controller.GetRecipesByOldest(page, pageSize); }
        public List<Recipe> GetRecipesByRating(int page, int pageSize) { return controller.GetRecipesByRating(page, pageSize); }
        public List<Recipe> GetRecipesBySaves(int page, int pageSize) {  return controller.GetRecipesBySaves(page, pageSize); }
        public List<Recipe> GetRecipesCreatedByUser(int page, int pageSize, int userId) {  return controller.GetRecipesCreatedByUser(page, pageSize, userId); }
    }
}
