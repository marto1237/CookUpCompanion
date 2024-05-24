using CookUp_Companion_Classes;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockClasses
{
    public class SharedRecipeRepository
    {
        public Dictionary<int, Recipe> Recipes { get; } = new Dictionary<int, Recipe>();
        public Dictionary<int, List<Comment>> CommentsByRecipeId { get; } = new Dictionary<int, List<Comment>>();
        public Dictionary<int, (int Likes, int Dislikes)> LikesAndDislikes { get; } = new Dictionary<int, (int, int)>();
        public Dictionary<int, List<int>> UserLikes { get; } = new Dictionary<int, List<int>>();
        public Dictionary<int, List<int>> UserDislikes { get; } = new Dictionary<int, List<int>>();
        public Dictionary<int, User> Users { get; } = new Dictionary<int, User>();
        public Dictionary<int, DateTime> RecipeCreationDates { get; } = new Dictionary<int, DateTime>();

        public int NextRecipeId { get; set; } = 1;
        public int NextUserId { get; set; } = 1;
    }

}
