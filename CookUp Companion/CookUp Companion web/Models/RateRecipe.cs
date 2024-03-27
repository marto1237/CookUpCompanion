namespace CookUp_Companion_web.Models
{
    public class RateRecipe
    {
        public Recipe Recipe { get; private set; }
        public Users User {  get; private set; }
        public bool Rating { get; private set; }
        public string Comment { get; private set; }
        public DateTime Timestamp { get; private set; }

        public RateRecipe(Recipe recipe, Users user, bool rating, string comment, DateTime timestamp)
        {
            Recipe = recipe;
            User = user;
            Rating = rating;
            Comment = comment;
            Timestamp = timestamp;
        }
    }
}
