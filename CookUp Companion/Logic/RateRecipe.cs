using Logic;

namespace Logic
{
    public class RateRecipe
    {
        public Recipe Recipe { get; private set; }
        public User User {  get; private set; }
        public bool Rating { get; private set; }
        public string Comment { get; private set; }
        public DateTime Timestamp { get; private set; }

        public RateRecipe(Recipe recipe, User user, bool rating, string comment, DateTime timestamp)
        {
            Recipe = recipe;
            User = user;
            Rating = rating;
            Comment = comment;
            Timestamp = timestamp;
        }
    }
}
