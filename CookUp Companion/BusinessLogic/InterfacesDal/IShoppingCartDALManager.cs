using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUp_Companion_BusinessLogic.InterfacesDal
{
    public interface IShoppingCartDALManager
    {
        public bool AddIngredientToCart(int cartId, int ingredientId, float quantity, string measurementUnit);
        public bool CreateCart(int userId);
        public int GetCartIdByUserId(int userId);
        List<Ingredient> GetShoppingCartIngredients(int userId);
        bool RemoveIngredientFromCart(int cartId, int ingredientId, float quantity, string units);
    }
}
