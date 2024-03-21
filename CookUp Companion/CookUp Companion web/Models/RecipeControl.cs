namespace CookUp_Companion_web.Models
{
    public class RecipeControl
    {
        public List<Recipe> recipes { get; private set; }

        public RecipeControl()
        {
            recipes = new List<Recipe>();
        }

        public void RateRecipe(Recipe recipe, User user, bool rating, string comment, DateTime timestamp)
        {
            RateRecipe newRate = new RateRecipe(recipe, user, rating, comment, timestamp);
            recipe.AddRating(newRate);
        }
        public void CreateRecipe(byte[] picture, User creator, string recipeName, string description, List<Ingredient> ingredients, string instructions, int cookingTime, int preparationTime)
        {
            Recipe newRecipe = new Recipe(picture, creator, recipeName, description, ingredients, instructions, cookingTime, preparationTime);
            recipes.Add(newRecipe);
        }

        public void UpdateRecipe(Recipe recipe,string newRecipeName, string newDescription, List<Ingredient> newIngredients, string newInstruction, int newCookingTime, int newPreparationTime)
        {
            recipe.UpdateRecipeName(newRecipeName);
            recipe.UpdateDescription(newDescription);
            recipe.UpdateIngredients(newIngredients);
            recipe.UpdateInstruction(newInstruction);
            recipe.UpdateCookingTime(newCookingTime);
            recipe.UpdatePreparationTime(newPreparationTime);

        }
        public List<Recipe> GetRecipesByName(string recipeName) 
        {
            return recipes.FindAll(r => r.RecipeName == recipeName);
        }

        public List<Recipe> GetRecipesByUser(User user)
        {
            return recipes.FindAll(r => r.Creator == user);
        }

        public List<Recipe> GetTopRatedRecipes()
        {
            //Add more funtion to get the the rate percent foreach recipe and later on  return the recipe starting with the ones with the highest liked precent
            return recipes;
        }
        public void ViewRecipe(Recipe recipe)
        {
            recipe.IncrementViews();
        }

        public List<Recipe> GetMostViewedRecipes()
        {
            //Add more funtion to get the the views foreach recipe and later on  return the recipe starting with the ones with the highest views
            return recipes;
        }

        public List<Recipe> GetRecentlyAddedRecipes()
        {
            //Add more funtion to get the newest public recipes first 
            return recipes;
        }
    }
}
