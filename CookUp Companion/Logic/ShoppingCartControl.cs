using CookUp_Companion_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ShoppingCartControl
    {
        public ShoppingCart shoppingCart { get; private set; }

        public ShoppingCartControl(User owner)
        {
            if (owner != null)
            {
                shoppingCart = new ShoppingCart(owner); // Assign to the class field instead of declaring a new variable
            }
            else
            {
                throw new ArgumentNullException(nameof(owner), "Owner cannot be null.");
            }
        }

        public void CreateShoppingCart(User owner)
        {
            shoppingCart = new ShoppingCart(owner);
        }

        public ShoppingCart GetShoppingCart(User owner)
        {
            return shoppingCart;
        }
    }
}
