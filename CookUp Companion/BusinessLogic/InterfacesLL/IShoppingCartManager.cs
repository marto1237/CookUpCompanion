using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUp_Companion_BusinessLogic.InterfacesLL
{
    public interface IShoppingCartManager
    {
        bool AddIngredientToCart(int cartId, int ingredientId, float quantity, string measurementUnit);
        bool CreateCart(int userId);
        int GetCartIdByUserId(int userId);
        List<Ingredient> GetShoppingCartIngredients(int userId);
        bool RemoveIngredientFromCart(int cartId, int ingredientId, float quantity, string units);
    }
}
