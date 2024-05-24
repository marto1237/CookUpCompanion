using CookUp_Companion_BusinessLogic.InterfacesDal;
using CookUp_Companion_BusinessLogic.Manager;
using CookUp_Companion_Classes;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class RecipeReviewDal : Connection, IRecipeReviewsDALManager
    {
        IUserManager userManager;
        IRecipeManager recipeManager;
        private string Server_Connection = "Server=mssqlstud.fhict.local;Database=dbi525452_cookup;User Id = dbi525452_cookup; Password=cookup;";
        public RecipeReviewDal(IUserManager userManager, IRecipeManager recipeManager)
        {
            this.userManager = userManager;
            this.recipeManager = recipeManager;
        }
        public bool AddComment(int userID, int recipeId, string userReaction, string comment)
        {
            bool isRecipeLike = userReaction == "like";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"INSERT INTO UserRating (userID, recipeID, rating, comment, timestamp)
                                    VALUES (@userID, @recipeID, @rating, @comment, @timestamp)";


                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@userID", userID);
                    command.Parameters.AddWithValue("@recipeID", recipeId);
                    command.Parameters.AddWithValue("@rating", isRecipeLike);
                    command.Parameters.AddWithValue("@comment", comment);
                    command.Parameters.AddWithValue("@timestamp", DateTime.Now);

                    int result = command.ExecuteNonQuery();  // Executes the command

                    return result > 0;
                }
                catch (Exception e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public List<Comment> GetCommentsByRecipeId(int recipeID, int page, int commentsPerPage)
        {
            List<Comment> comments = new List<Comment>();
            // Calculate the starting point of the comments to fetch
            int startRow = (page - 1) * commentsPerPage;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT * FROM UserRating WHERE  recipeID = @RecipeId 
                                    ORDER BY timestamp DESC
                                    OFFSET @StartRow ROWS
                                    FETCH NEXT @CommentsPerPage ROWS ONLY;";


                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@RecipeId", recipeID);
                    command.Parameters.AddWithValue("@StartRow", startRow);
                    command.Parameters.AddWithValue("@CommentsPerPage", commentsPerPage);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Comment comment = new Comment(
                            userManager.GetUserById((int)reader["userID"]),
                            (bool)reader["rating"],
                            (string)reader["comment"],
                            (DateTime)reader["timestamp"]
                            );
                        comments.Add(comment);
                    }

                    return comments;
                }
                catch (Exception e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return comments;
                }
            }
        }

        public (int Likes, int Dislikes) GetLikesAndDislikes(int recipeId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT
                                    SUM(CASE WHEN rating = 1 THEN 1 ELSE 0 END) AS Likes,
                                    SUM(CASE WHEN rating = 0 THEN 1 ELSE 0 END) AS Dislikes
                                    FROM UserRating
                                    WHERE recipeID = @RecipeId;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RecipeId", recipeId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int likes = reader["Likes"] != DBNull.Value ? Convert.ToInt32(reader["Likes"]) : 0;
                                int dislikes = reader["Dislikes"] != DBNull.Value ? Convert.ToInt32(reader["Dislikes"]) : 0;
                                return (likes, dislikes);
                            }
                        }
                    }

                }
                catch (Exception e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return (0, 0);
                }
            }
            return (0, 0);
        }
        public List<Recipe> GetLikedRecipesByUser(int userId)
        {
            List<Recipe> likedRecipes = new List<Recipe>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = @"
                SELECT r.recipeID, r.recipeName, r.recipePicture, r.creator, r.description, r.cookingInstructions, r.preparationTime, r.cookingTime, r.dateCreated
                FROM Recipes r
                JOIN UserRating ur ON r.recipeID = ur.recipeID
                WHERE ur.userID = @UserId AND ur.rating = 1";  // 1 represents 'true' for liked recipes

                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Recipe recipe = new Recipe(
                                    (byte[])reader["recipePicture"],
                                    userManager.GetUserById((int)reader["creator"]),
                                    reader["recipeName"].ToString(),
                                    reader["description"].ToString(),
                                    recipeManager.GetAllIngredientsForRecipeId((int)reader["recipeID"]),
                                    reader["cookingInstructions"].ToString(),
                                    (int)reader["cookingTime"],
                                    (int)reader["preparationTime"]
                                    );

                                likedRecipes.Add(recipe);
                            }
                        }
                    }
                    return likedRecipes;
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return likedRecipes;
                }
            }
        }
        public List<Recipe> GetLikedRecipes(int page, int pageSize, int userId)
        {
            List<Recipe> likedRecipes = new List<Recipe>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();
                    int offset = Math.Max(0, (Math.Max(page, 1) - 1) * pageSize);

                    string query = $@"
                        SELECT r.recipeID, r.recipeName, r.recipePicture, r.creator, r.description, r.cookingInstructions, r.preparationTime, r.cookingTime, r.dateCreated
                        FROM Recipes r
                        JOIN UserRating ur ON r.recipeID = ur.recipeID
                        WHERE ur.userID = @UserId AND ur.rating = 1
                        ORDER BY r.recipeID
                        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@UserId", userId);

                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int recipeId = (int)reader["recipeID"];
                        List<Ingredient> ingredients = recipeManager.GetAllIngredientsForRecipeId(recipeId);

                        Recipe recipe = new Recipe(
                            (byte[])reader["recipePicture"],
                            userManager.GetUserById((int)reader["creator"]),
                            reader["recipeName"].ToString(),
                            reader["description"].ToString(),
                            ingredients,
                            reader["cookingInstructions"].ToString(),
                            (int)reader["cookingTime"],
                            (int)reader["preparationTime"]
                         );

                        likedRecipes.Add(recipe);
                    }
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);

                }

            }

            return likedRecipes;
        }
    }
}
