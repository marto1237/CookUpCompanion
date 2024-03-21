using CookUp_Companion_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Preference
    {

        public List<Recipe> LikedRecipes { get; private set; }
        public List<Recipe> SavedRecipes { get; private set; }
        public List<Ingredient> DislikedIngredients { get; private set; }

        public Preference()
        {
            LikedRecipes = new List<Recipe>();
            SavedRecipes = new List<Recipe>();
            DislikedIngredients = new List<Ingredient>();
        }

        public void AddLikedRecipe(Recipe recipe)
        {
            LikedRecipes.Add(recipe);
        }

        public void RemoveLikedRecipe(Recipe recipe)
        {
            LikedRecipes.Remove(recipe);
        }

        public void AddSavedRecipe(Recipe recipe)
        {
            SavedRecipes.Add(recipe);
        }

        public void RemoveSavedRecipe(Recipe recipe)
        {
            SavedRecipes.Remove(recipe);
        }

        public void AddDislikedIngredient(Ingredient ingredient)
        {
            DislikedIngredients.Add(ingredient);
        }

        public void RemoveDislikedIngredient(Ingredient ingredient)
        {
            DislikedIngredients.Remove(ingredient);
        }
    }
}
