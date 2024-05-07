using CookUp_Companion_BusinessLogic.InterfacesDal;
using CookUp_Companion_BusinessLogic.InterfacesLL;
using CookUp_Companion_BusinessLogic.Manager;
using InterfaceDAL;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUp_Companion_BusinessLogic.Managers
{
    public class ShoppingCartManager : IShoppingCartManager
    {
        private User currentUser;
        private IUserManager userManager;
        

        IShoppingCartDALManager shoppingDal;
        public ShoppingCartManager(IShoppingCartDALManager shoppingDal, IUserManager userManager)
        {
            this.shoppingDal = shoppingDal;
            this.userManager = userManager;
        }
      
        

        public bool CreateCart(int userId) { return shoppingDal.CreateCart(userId); }
        public bool AddIngredientToCart(int cartId, int ingredientId, float quantity, string measurementUnit) { return  shoppingDal.AddIngredientToCart(cartId, ingredientId, quantity, measurementUnit); }
        public int GetCartIdByUserId(int userId) { return shoppingDal.GetCartIdByUserId(userId) ; }
        public List<Ingredient> GetShoppingCartIngredients(int userId) { return shoppingDal.GetShoppingCartIngredients(userId) ; }
        public bool RemoveIngredientFromCart(int cartId, int ingredientId, float quantity, string units) {  return shoppingDal.RemoveIngredientFromCart(cartId,ingredientId, quantity, units); }

    }
}
