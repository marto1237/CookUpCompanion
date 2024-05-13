using InterfaceDAL;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockClasses
{
    public class FakePlannerDal : IPlannerDALManager
    {
        private Dictionary<int, Dictionary<string, List<Recipe>>> fakeDatabase;
        private Dictionary<int, User> users;
        private Dictionary<int, Recipe> recipes;

        public FakePlannerDal()
        {
            fakeDatabase = new Dictionary<int, Dictionary<string, List<Recipe>>>();
            users = new Dictionary<int, User>();
            recipes = new Dictionary<int, Recipe>();

            InitializeDefaultUsersAndRecipes();
        }

        private void InitializeDefaultUsersAndRecipes()
        {
            // Example users
            users[1] = new User(null, "user1", "user1@example.com", "hashed_password", "User", "One", 1, null);
            users[2] = new User(null, "user2", "user2@example.com", "hashed_password", "User", "Two", 2, null);

            // Example recipes
            List<Ingredient> ingredients = new List<Ingredient> {
                new Ingredient(null, 1, "Sugar", 100, "grams"),
                new Ingredient(null, 2, "Flour", 200, "grams")
            };

            recipes[1] = new Recipe(null, users[1], "Chocolate Cake", "Delicious chocolate cake", ingredients, "Mix ingredients", 90, 15);
            recipes[2] = new Recipe(null, users[2], "Banana Bread", "Healthy banana bread", ingredients, "Bake at 180C", 60, 20);
        }

        public bool AddWeeklyPlan(int userId, Dictionary<string, List<int>> weeklyPlan)
        {
            if (!fakeDatabase.ContainsKey(userId) && users.ContainsKey(userId))
            {
                fakeDatabase[userId] = new Dictionary<string, List<Recipe>>();
            }
            else
            {
                return false;
            }    

            foreach (var day in weeklyPlan.Keys)
            {
                fakeDatabase[userId][day] = weeklyPlan[day].Select(id => recipes[id]).ToList();
            }
            return true;
        }

        public Dictionary<string, List<Recipe>> GetWeeklyPlan(int userId, DateTime startOfWeek, DateTime endOfWeek)
        {
            if (fakeDatabase.ContainsKey(userId))
            {
                return fakeDatabase[userId];
            }
            return new Dictionary<string, List<Recipe>>();
        }
    }
}
