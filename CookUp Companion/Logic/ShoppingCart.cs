using CookUp_Companion_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ShoppingCart
    {
        public List<Ingredient> Items { get; private set; } 
        public User Owner { get; private set; }

        public ShoppingCart(User user) 
        {
            Owner = user;
            Items = new List<Ingredient>();
        }

        public User GetOwner(User user)
        {
            return Owner;
        }

        public List<Ingredient> GetItems()
        {
              return Items;
        }
    }
}
