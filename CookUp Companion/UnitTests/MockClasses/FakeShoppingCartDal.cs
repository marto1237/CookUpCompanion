using CookUp_Companion_BusinessLogic.InterfacesDal;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockClasses
{
    public class FakeShoppingCartDal : IShoppingCartDALManager
    {
        private Dictionary<int, List<Ingredient>> fakeDatabase;

        public FakeShoppingCartDal()
        {
            
            fakeDatabase = new Dictionary<int, List<Ingredient>>();
        }

        public bool CreateCart(int userId)
        {
            if (!fakeDatabase.ContainsKey(userId))
            {
                fakeDatabase[userId] = new List<Ingredient>();
                return true;
            }
            else
            {
                return false;
            }   
        }

        public int GetCartIdByUserId(int userId)
        {
            
            return userId;
        }

        public bool AddIngredientToCart(int cartId, int ingredientId, float quantity, string measurementUnit)
        {
            var ingredient = new Ingredient { IngredientId = ingredientId, IngredientName = $"Ingredient {ingredientId}", Quantity = quantity, SelectedUnit = measurementUnit };
            if (fakeDatabase.ContainsKey(cartId))
            {
                fakeDatabase[cartId].Add(ingredient);
                return true;
            }
            else
            {
                return false;
            }
                
        }

        public List<Ingredient> GetIngredientsInCart(int cartId)
        {
            
            if (fakeDatabase.ContainsKey(cartId))
            {
                return fakeDatabase[cartId];
            }
            else
            {
                return new List<Ingredient>(); 
            }
        }

        public bool RemoveIngredientFromCart(int cartId, int ingredientId, float quantity, string units)
        {
            // Remove the specified ingredient from the specified user's cart in the fake database
            var ingredientToRemove = fakeDatabase[cartId].Find(ingredient => ingredient.IngredientId == ingredientId && ingredient.Quantity == quantity && ingredient.SelectedUnit == units);
            if (ingredientToRemove != null)
            {
                fakeDatabase[cartId].Remove(ingredientToRemove);
                return true;
            }
            else
            {
                return false; 
            }
        }

        public List<Ingredient> GetShoppingCartIngredients(int userId)
        {
            
            if (fakeDatabase.ContainsKey(userId))
            {
                return fakeDatabase[userId];
            }
            else
            {
                return new List<Ingredient>(); 
            }
        }
    }
}