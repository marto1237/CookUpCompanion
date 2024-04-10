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

	}
}
