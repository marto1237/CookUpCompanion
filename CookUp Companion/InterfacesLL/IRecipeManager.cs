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

	}
}
