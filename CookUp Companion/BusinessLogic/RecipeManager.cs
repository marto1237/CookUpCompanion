using InterfaceDAL;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUp_Companion_BusinessLogic
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
	}
}
