namespace Logic
{
    public class Recipe
    {
        public byte[] Picture { get; private set; }
        public User Creator { get; private set; }
        public string RecipeName { get; private set; }
        public string Description { get; private set; }
        public List<Ingredient> Ingredients { get; private set; }
        public string Instructions { get; private set; }
        public int CookingTime { get; private set; }
        public int PreparationTime { get; private set; }
        public int Views { get; private set; }
        public List<RateRecipe> Ratings { get; private set; }

        public Recipe(byte[] picture, User creator, string recipeName, string description, List<Ingredient> ingredients, string instructions, int cookingTime, int preparationTime)
        {
            Picture = picture;
            Creator = creator;
            RecipeName = recipeName;
            Description = description;
            Ingredients = ingredients;
            Instructions = instructions;
            CookingTime = cookingTime;
            PreparationTime = preparationTime;
            Views = 0;
            Ratings = new List<RateRecipe>();
            
        }

        public void UpdateRecipePicture(byte[] picture)
        {
            Picture = picture;
        }
        public void UpdateRecipeName(string name)
        {
            RecipeName = name;
        }
        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
        }
        public void UpdateIngredients(List<Ingredient> newIngredients)
        {
            Ingredients = newIngredients;
        }
        public void UpdateInstruction(string newInstructions)
        {
            Instructions = newInstructions;
        }
        public void UpdateCookingTime(int newCookingTime)
        {
            CookingTime = newCookingTime;
        }
        public void UpdatePreparationTime(int newPreparationTime)
        {
            PreparationTime = newPreparationTime;
        }
        
        public void AddRating(RateRecipe rating)
        {
            Ratings.Add(rating);
        }
        public void IncrementViews()
        {
            Views++;
        }
    }
}
