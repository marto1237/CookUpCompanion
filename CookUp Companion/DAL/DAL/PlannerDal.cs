using InterfaceDAL;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PlannerDal : Connection , IPlannerDALManager
    {
        IUserManager userManager;
        IRecipeManager recipeManager;
        private readonly string tableName = "WeeklyRecipePlans";
        private string Server_Connection = "Server=mssqlstud.fhict.local;Database=dbi525452_cookup;User Id = dbi525452_cookup; Password=cookup;";
        public PlannerDal(IUserManager userManager, IRecipeManager recipeManager)
        {
            this.userManager = userManager;
            this.recipeManager = recipeManager;
        }

        public bool AddWeeklyPlan(int userId, Dictionary<string, List<int>> weeklyPlan)
        {
            bool isSuccessful = false;
            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                try
                {
                    connection.Open();
                    foreach (var dayPlan in weeklyPlan)
                    {
                        string day = dayPlan.Key;
                        List<int> recipeIds = dayPlan.Value;
                        foreach (var recipeId in recipeIds)
                        {
                            string insertQuery = $"INSERT INTO {tableName} (userId, recipeId, plannedDay) VALUES (@UserId, @RecipeId, @PlannedDay);";
                            SqlCommand command = new SqlCommand(insertQuery, connection);
                            command.Parameters.AddWithValue("@UserId", userId);
                            command.Parameters.AddWithValue("@RecipeId", recipeId);
                            command.Parameters.AddWithValue("@PlannedDay", day);
                            command.ExecuteNonQuery();
                        }
                    }
                    isSuccessful = true;
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }

            return isSuccessful;
        }

        public Dictionary<string, List<Recipe>> GetWeeklyPlan(int userId, DateTime startOfWeek, DateTime endOfWeek)
        {
            Dictionary<string, List<Recipe>> weeklyPlan = new Dictionary<string, List<Recipe>>();
            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                try
                {
                    connection.Open();
                    string query = $@"SELECT recipeId, plannedDay FROM {tableName} 
                              WHERE userId = @UserId 
                              AND plannedDay BETWEEN @StartOfWeek AND @EndOfWeek";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@StartOfWeek", startOfWeek);
                        command.Parameters.AddWithValue("@EndOfWeek", endOfWeek);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string day = reader["plannedDay"].ToString();
                                int recipeId = (int)reader["recipeId"];
                                Recipe recipe = recipeManager.GetRecipeById(recipeId);

                                if (!weeklyPlan.ContainsKey(day))
                                {
                                    weeklyPlan[day] = new List<Recipe>();
                                }
                                weeklyPlan[day].Add(recipe);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            return weeklyPlan;
        }

    }
}
