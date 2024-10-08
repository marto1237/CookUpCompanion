﻿using CookUp_Companion_Classes;
using InterfaceDAL;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class RecipeDal : Connection, IRecipeDALManager
    {
        IUserManager userManager;
        private readonly string tableName = "Recipes";
        private string Server_Connection = "Server=mssqlstud.fhict.local;Database=dbi525452_cookup;User Id = dbi525452_cookup; Password=cookup;";
        public RecipeDal(IUserManager userManager)
        { this.userManager = userManager; }


        public Ingredient GetInputIngredient(string name)
        {
            Ingredient ingredient = null;

            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();

                string query = "SELECT * FROM Ingredient WHERE name = @name";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@name", name);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ingredient = new Ingredient(
                            (byte[])reader["ingredientPicture"],
                            (int)reader["ingredientID"],
                            (string)reader["name"],
                            (string)reader["possibleUnits"],
                            0 //Default value for the units

                            );
                    }
                }

            }

            return ingredient;
        }
        public bool InsertRecipe(Recipe recipe)
        {
            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();

                // Step 1: Insert into Recipes table
                string insertRecipeQuery = $"INSERT INTO {tableName} (recipeName, recipePicture,creator, description, cookingInstructions, preparationTime, cookingTime) " +
                                           "VALUES (@RecipeName,@RecipePicture,@Creator, @Description, @Instructions, @PrepTime, @CookTime); " +
                                           "SELECT SCOPE_IDENTITY();"; // Retrieve the generated ID

                SqlCommand insertRecipeCommand = new SqlCommand(insertRecipeQuery, connection);
                insertRecipeCommand.Parameters.AddWithValue("@RecipeName", recipe.RecipeName);
                insertRecipeCommand.Parameters.AddWithValue("@RecipePicture", recipe.Picture);
                insertRecipeCommand.Parameters.AddWithValue("@Creator", userManager.GetIdByUsername(recipe.Creator.Username));
                insertRecipeCommand.Parameters.AddWithValue("@Description", recipe.Description);
                insertRecipeCommand.Parameters.AddWithValue("@Instructions", recipe.Instructions);
                insertRecipeCommand.Parameters.AddWithValue("@PrepTime", recipe.PreparationTime);
                insertRecipeCommand.Parameters.AddWithValue("@CookTime", recipe.CookingTime);

                int recipeId = Convert.ToInt32(insertRecipeCommand.ExecuteScalar());

                // Step 2: Insert into RecipeIngredients table
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    string insertIngredientQuery = "INSERT INTO RecipeIngredients (recipeID, ingredientID, quantity, measurementUnit) " +
                                                    "VALUES (@RecipeID, @IngredientID, @Quantity, @MeasurementUnit);";

                    SqlCommand insertIngredientCommand = new SqlCommand(insertIngredientQuery, connection);
                    insertIngredientCommand.Parameters.AddWithValue("@RecipeID", recipeId);
                    insertIngredientCommand.Parameters.AddWithValue("@IngredientID", ingredient.IngredientId);
                    insertIngredientCommand.Parameters.AddWithValue("@Quantity", ingredient.Quantity);
                    insertIngredientCommand.Parameters.AddWithValue("@MeasurementUnit", ingredient.SelectedUnit);

                    insertIngredientCommand.ExecuteNonQuery();
                }
            }
            return true;
        }

        public List<Ingredient> GetAllIngredients(int page, int pageSize)
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM Ingredient ORDER BY ingredientID OFFSET {(page - 1) * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Ingredient ingredient = new Ingredient(
                                 (byte[])reader["ingredientPicture"],
                                 (int)reader["ingredientID"],
                                 (string)reader["name"],
                                 (string)reader["possibleUnits"],
                                 0



                         );

                        ingredients.Add(ingredient);
                    }
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);


                }

            }

            return ingredients;
        }
        public int GetAllIngredientsPageNum(int pageSize)
        {
            int pages = 0;
            int totalIngredients = 0;
            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                try
                {
                    connection.Open();

                    string countQuery = "SELECT COUNT(*) FROM Ingredient";
                    SqlCommand countCommand = new SqlCommand(countQuery, connection);
                    totalIngredients = (int)countCommand.ExecuteScalar();
                    pages = (int)Math.Ceiling((double)totalIngredients / pageSize);
                }

                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }


            return pages;

        }

        public Ingredient GetIngredientByName(string ingredientName)
        {
            Ingredient ingredient = null;

            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT * FROM Ingredient WHERE name = @Name";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Name", ingredientName);


                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ingredient = new Ingredient(
                                 (byte[])reader["ingredientPicture"],
                                 (int)reader["ingredientID"],
                                 (string)reader["name"],
                                 (string)reader["possibleUnits"],
                                 0



                         );


                    }
                }


                catch (Exception e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }

            return ingredient;
        }

        public List<Ingredient> GetAllIngredientsForRecipeId(int recipeId)
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = $@"
                SELECT i.ingredientID, i.ingredientPicture, i.name, ri.quantity, ri.measurementUnit
                FROM RecipeIngredients ri
                JOIN Ingredient i ON ri.ingredientID = i.ingredientID
                WHERE ri.recipeID = @recipeID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@recipeID", recipeId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        byte[] ingredientPicture = reader["ingredientPicture"] as byte[];
                        int ingredientId = Convert.ToInt32(reader["ingredientID"]);
                        string ingredientName = reader["name"].ToString();
                        float quantity = Convert.ToSingle(reader["quantity"]);
                        string measurementUnit = reader["measurementUnit"].ToString();

                        // Using the constructor correctly
                        ingredients.Add(new Ingredient(
                            ingredientPicture,
                            ingredientId,
                            ingredientName,
                            quantity,
                            measurementUnit
                        ));
                    }
                }
            }

            return ingredients;
        }
        public List<Recipe> GetAllRecipes(int page, int pageSize)
        {
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();
                    int offset = Math.Max(0, (Math.Max(page, 1) - 1) * pageSize);

                    string query = $@"
                        SELECT r.recipeID, r.recipeName, r.recipePicture, r.creator, r.description, r.cookingInstructions, r.preparationTime, r.cookingTime, r.dateCreated
                        FROM Recipes r
                        ORDER BY r.recipeID
                        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int recipeId = (int)reader["recipeID"];
                        List<Ingredient> ingredients = GetAllIngredientsForRecipeId(recipeId);

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

                        recipes.Add(recipe);
                    }
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);

                }

            }

            return recipes;

        }
        public int GetAllRecipesPageNum(int pageSize)
        {
            int totalRecipes = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Recipes";
                SqlCommand command = new SqlCommand(query, connection);
                totalRecipes = (int)command.ExecuteScalar();
            }
            return (int)Math.Ceiling((double)totalRecipes / pageSize);
        }

        public int GetSavedRecipesPageNum(int pageSize, int userId)
        {
            int totalSavedRecipes = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM UserFavorites WHERE userID = @UserId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", userId);

                    totalSavedRecipes = (int)command.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            return (int)Math.Ceiling((double)totalSavedRecipes / pageSize);
        }

        public int GetCreatedRecipesPageNum(int pageSize, int userId)
        {
            int totalCreatedRecipes = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Recipes WHERE creator = @UserId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", userId);

                    totalCreatedRecipes = (int)command.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            return (int)Math.Ceiling((double)totalCreatedRecipes / pageSize);
        }


        public int GetRecipeID(Recipe recipe)
        {
            int recipeID = -1;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();
                    string query = $"SELECT recipeID FROM {tableName} WHERE recipeName = @RecipeName AND creator = @Creator";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@RecipeName ", recipe.RecipeName);
                    command.Parameters.AddWithValue("@Creator", userManager.GetIdByUsername(recipe.Creator.Username));

                    // Execute the query and attempt to read the data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Checks if there are rows and moves to the first one
                        {
                            recipeID = (int)reader["recipeID"]; // Cast to int and read the recipeID
                        }
                    }

                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);

                }

            }

            return recipeID;


        }

        public Recipe GetRecipeById(int recipeID)
        {
            Recipe recipe = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();
                    string query = $@"
                        SELECT r.recipeID, r.recipeName, r.recipePicture, r.creator, r.description, r.cookingInstructions, r.preparationTime, r.cookingTime, r.dateCreated
                        FROM Recipes r
                        WHERE r.recipeID = @RecipeID";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@RecipeID", recipeID);

                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        List<Ingredient> ingredients = GetAllIngredientsForRecipeId(recipeID);

                        recipe = new Recipe(
                        (byte[])reader["recipePicture"],
                        userManager.GetUserById((int)reader["creator"]),
                        reader["recipeName"].ToString(),
                        reader["description"].ToString(),
                        ingredients,
                        reader["cookingInstructions"].ToString(),
                        (int)reader["cookingTime"],
                        (int)reader["preparationTime"]
                     );


                    }
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);

                }

            }

            return recipe;

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

        public bool ToggleFavoriteRecipe(int userId, int recipeId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(1) FROM UserFavorites WHERE userID = @UserId AND recipeID = @RecipeId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@RecipeId", recipeId);

                    bool isFavorite = (int)command.ExecuteScalar() > 0;

                    SqlCommand cmd;
                    if (isFavorite)
                    {
                        // It's already a favorite, remove it
                        cmd = new SqlCommand("DELETE FROM UserFavorites WHERE UserId = @UserId AND RecipeId = @RecipeId", connection);
                    }
                    else
                    {
                        // It's not a favorite, add it
                        cmd = new SqlCommand("INSERT INTO UserFavorites (UserId, RecipeId) VALUES (@UserId, @RecipeId)", connection);
                    }

                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@RecipeId", recipeId);
                    cmd.ExecuteNonQuery();

                    return !isFavorite; // Return true if now a favorite, false if removed
                }
                catch (Exception e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return false;
                }
            }
        }
        public bool CheckIfFavorite(int userId, int recipeId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(1) FROM UserFavorites WHERE userID = @UserId AND recipeID = @RecipeId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@RecipeId", recipeId);

                    bool isFavorite = (int)command.ExecuteScalar() > 0;

                    return isFavorite; // Return true if now a favorite, false if removed
                }
                catch (Exception e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return false;
                }
            }
        }
        public List<Recipe> SearchRecipesByName(string searchRecipeName, int page, int pageSize)
        {
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    int offset = Math.Max(0, (Math.Max(page, 1) - 1) * pageSize);

                    // Modified query to include a WHERE clause with LIKE
                    string query = @"
                SELECT r.recipeID, r.recipeName, r.recipePicture, r.creator, r.description, r.cookingInstructions, r.preparationTime, r.cookingTime, r.dateCreated
                FROM Recipes r
                WHERE r.recipeName LIKE @SearchText
                ORDER BY r.recipeID
                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SearchText", "%" + searchRecipeName + "%"); // Add wildcard characters for partial match
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int recipeId = (int)reader["recipeID"];
                            List<Ingredient> ingredients = GetAllIngredientsForRecipeId(recipeId);

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

                            recipes.Add(recipe);
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Error searching recipes by name: " + e.Message);
                    // Depending on your error handling policy you might want to rethrow the exception or handle it differently
                }
            }
            return recipes;
        }

        public Recipe GetRecipeByNameAndCreator(string recipeName, string creatorName)
        {
            Recipe recipe = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();
                    string query = $@"
                        SELECT recipeID, recipeName, recipePicture, creator, description, cookingInstructions, preparationTime, cookingTime, dateCreated
                        FROM Recipes 
                        WHERE creator = @Creator AND recipeName = @RecipeName";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Creator", userManager.GetIdByUsername(creatorName));
                    command.Parameters.AddWithValue("@RecipeName", recipeName);

                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int recipeId = (int)reader["recipeID"];
                        List<Ingredient> ingredients = GetAllIngredientsForRecipeId(recipeId);

                        recipe = new Recipe(
                           (byte[])reader["recipePicture"],
                           userManager.GetUserById((int)reader["creator"]),
                           reader["recipeName"].ToString(),
                           reader["description"].ToString(),
                           ingredients,
                           reader["cookingInstructions"].ToString(),
                           (int)reader["cookingTime"],
                           (int)reader["preparationTime"]
                        );

                    }
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);

                }

            }

            return recipe;
        }

        public bool UpdateRecipe(string creator, string recipeName, string newRecipeName, string newRecipeDescription, string newInstructions)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = $@"UPDATE Recipes SET recipeName = @NewRecipeName, description = @NewRecipeDescription,
                    cookingInstructions = @NewInstructions WHERE  recipeName = @RecipeName AND creator = @CreatorId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CreatorId", userManager.GetIdByUsername(creator));
                    command.Parameters.AddWithValue("@RecipeName", recipeName);
                    command.Parameters.AddWithValue("@NewRecipeName", newRecipeName);
                    command.Parameters.AddWithValue("@NewRecipeDescription", newRecipeDescription);
                    command.Parameters.AddWithValue("@NewInstructions", newInstructions);

                    // Execute the update command
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return false;

                }
            }
        }

        public bool DeleteRecipe(Recipe recipe)
        {
            int recipeID = GetRecipeID(recipe);

            if (recipeID == -1)
            {
                System.Diagnostics.Debug.WriteLine("Recipe not found or error retrieving the recipe ID.");
                return false;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();

                    string deleteIngredientsQuery = $"DELETE FROM RecipeIngredients WHERE recipeID = @RecipeID";
                    SqlCommand ingredientCommand = new SqlCommand(deleteIngredientsQuery, connection);
                    ingredientCommand.Parameters.AddWithValue("@RecipeID", recipeID);
                    ingredientCommand.ExecuteNonQuery(); // Execute the query to delete ingredients

                    // Next, delete the recipe itself
                    string deleteRecipeQuery = $"DELETE FROM {tableName} WHERE recipeID = @RecipeID";
                    SqlCommand recipeCommand = new SqlCommand(deleteRecipeQuery, connection);
                    recipeCommand.Parameters.AddWithValue("@RecipeID", recipeID);
                    int result = recipeCommand.ExecuteNonQuery(); // Execute the delete query for the recipe

                    return result > 0;


                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

        }
        

        public bool RemoveSavedRecipe(int userId, int recipeId)
        {
            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM UserFavorites WHERE UserId = @UserId AND RecipeId = @RecipeId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@RecipeId", recipeId);

                    int rowAffected = command.ExecuteNonQuery();
                    System.Diagnostics.Debug.WriteLine("Rows affected: " + rowAffected);
                    return rowAffected > 0;
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine("SQL Error: " + e.Message);
                    return false;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("General Error: " + e.Message);
                    return false;
                }
            }
        }
        public List<Recipe> GetSavedRecipes(int page, int pageSize, int userId)
        {
            List<Recipe> savedRecipes = new List<Recipe>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                int offset = (page - 1) * pageSize;

                string query = @"
                SELECT r.recipeID, r.recipeName, r.recipePicture, r.creator, r.description, r.cookingInstructions, r.preparationTime, r.cookingTime, r.dateCreated
                FROM Recipes r
                JOIN UserFavorites uf ON r.recipeID = uf.recipeID
                WHERE uf.userID = @UserId
                ORDER BY r.recipeID
                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@Offset", offset);
                command.Parameters.AddWithValue("@PageSize", pageSize);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int recipeId = (int)reader["recipeID"];
                        List<Ingredient> ingredients = GetAllIngredientsForRecipeId(recipeId);

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

                        savedRecipes.Add(recipe);
                    }
                }
            }

            return savedRecipes;
        }

        public int GetSaveCount(int recipeId)
        {
            int saveCount = 0;
            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM UserFavorites WHERE recipeID = @RecipeId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RecipeId", recipeId);

                try
                {
                    saveCount = (int)command.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine("SQL Error: " + e.Message);
                }
            }
            return saveCount;
        }
        public List<Recipe> GetRecipesAlphabetically(int page, int pageSize)
        {
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();
                    int offset = Math.Max(0, (Math.Max(page, 1) - 1) * pageSize);

                    string query = $@"
                        SELECT r.recipeID, r.recipeName, r.recipePicture, r.creator, r.description, r.cookingInstructions, r.preparationTime, r.cookingTime, r.dateCreated
                        FROM Recipes r
                        ORDER BY r.recipeName
                        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int recipeId = (int)reader["recipeID"];
                        List<Ingredient> ingredients = GetAllIngredientsForRecipeId(recipeId);

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

                        recipes.Add(recipe);
                    }
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);

                }

            }

            return recipes;

        }
        public List<Recipe> GetRecipesByNewest(int page, int pageSize)
        {
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();
                    int offset = Math.Max(0, (Math.Max(page, 1) - 1) * pageSize);

                    string query = $@"
                        SELECT r.recipeID, r.recipeName, r.recipePicture, r.creator, r.description, r.cookingInstructions, r.preparationTime, r.cookingTime, r.dateCreated
                        FROM Recipes r
                        ORDER BY r.dateCreated DESC
                        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int recipeId = (int)reader["recipeID"];
                        List<Ingredient> ingredients = GetAllIngredientsForRecipeId(recipeId);

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

                        recipes.Add(recipe);
                    }
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);

                }

            }

            return recipes;

        }
        public List<Recipe> GetRecipesByOldest(int page, int pageSize)
        {
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();
                    int offset = Math.Max(0, (Math.Max(page, 1) - 1) * pageSize);

                    string query = $@"
                        SELECT r.recipeID, r.recipeName, r.recipePicture, r.creator, r.description, r.cookingInstructions, r.preparationTime, r.cookingTime, r.dateCreated
                        FROM Recipes r
                        ORDER BY r.dateCreated 
                        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int recipeId = (int)reader["recipeID"];
                        List<Ingredient> ingredients = GetAllIngredientsForRecipeId(recipeId);

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

                        recipes.Add(recipe);
                    }
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);

                }

            }

            return recipes;

        }
        public List<Recipe> GetRecipesByRating(int page, int pageSize)
        {
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                int offset = Math.Max(0, (Math.Max(page, 1) - 1) * pageSize);
                string query = @"
                   SELECT r.*, ISNULL(AvgRating.AverageRating, 0) AS AverageRating
                    FROM Recipes r
                    LEFT JOIN (
                        SELECT recipeID, AVG(CAST(rating AS FLOAT)) AS AverageRating
                        FROM UserRating
                        GROUP BY recipeID
                    ) AvgRating ON r.recipeID = AvgRating.recipeID
                    ORDER BY AvgRating.AverageRating DESC
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PageSize", pageSize);
                command.Parameters.AddWithValue("@Offset", offset);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int recipeId = (int)reader["recipeID"];
                        List<Ingredient> ingredients = GetAllIngredientsForRecipeId(recipeId);

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

                        recipes.Add(recipe);
                    }
                }
            }
            return recipes;
        }

        public List<Recipe> GetRecipesBySaves(int page, int pageSize)
        {
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                int offset = Math.Max(0, (Math.Max(page, 1) - 1) * pageSize);
                string query = @"
                    SELECT r.*, ISNULL(SaveCount.Count, 0) AS SaveCount
                    FROM Recipes r
                    LEFT JOIN (
                        SELECT recipeID, COUNT(*) AS Count
                        FROM UserFavorites
                        GROUP BY recipeID
                    ) SaveCount ON r.recipeID = SaveCount.recipeID
                    ORDER BY SaveCount.Count DESC
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PageSize", pageSize);
                command.Parameters.AddWithValue("@Offset", offset);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int recipeId = (int)reader["recipeID"];
                        List<Ingredient> ingredients = GetAllIngredientsForRecipeId(recipeId);

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

                        recipes.Add(recipe);
                    }
                }
            }
            return recipes;
        }

        public List<Recipe> GetRecipesCreatedByUser(int page, int pageSize,int userId)
        {
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                try
                {
                    connection.Open();

                    int offset = Math.Max(0, (Math.Max(page, 1) - 1) * pageSize);
                    string query = $@"
                        SELECT recipeID, recipeName, recipePicture, creator, description, cookingInstructions, preparationTime, cookingTime, dateCreated
                        FROM Recipes 
                        WHERE creator = @Creator
                        ORDER BY recipeID
                        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Creator", userId);
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int recipeId = (int)reader["recipeID"];
                        List<Ingredient> ingredients = GetAllIngredientsForRecipeId(recipeId);

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

                        recipes.Add(recipe);
                    }
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);

                }

            }

            return recipes;
        }

        public List<Recipe> GetSavedRecipesByUser(int userId)
        {
            List<Recipe> likedRecipes = new List<Recipe>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = @"
                SELECT r.recipeID, r.recipeName, r.recipePicture, r.creator, r.description, r.cookingInstructions, r.preparationTime, r.cookingTime, r.dateCreated
                FROM Recipes r
                JOIN UserFavorites uf ON r.recipeID = uf.recipeID
                WHERE uf.userID = @UserId ";  // 1 represents 'true' for liked recipes

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
                                    GetAllIngredientsForRecipeId((int)reader["recipeID"]),
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
		public Ingredient GetIngredientById(int ingredientId)
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
			{
				Ingredient ingredient = null;
				try
				{
					connection.Open();
					string query = @"
                    SELECT ingredientID, ingredientPicture, name, possibleUnits
                    FROM Ingredient
                    WHERE ingredientID = @IngredientID";

					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@IngredientID", ingredientId);

					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read()) // Ensures that we read only if there is data
						{
							byte[] ingredientPicture = (byte[])reader["ingredientPicture"];
							string name = reader["name"].ToString();
							string possibleUnits = reader["possibleUnits"].ToString(); // Assuming this is stored correctly in your DB

							ingredient = new Ingredient(
								ingredientPicture,
                                ingredientId,
                                name,
                                possibleUnits,
                                0 // Quantity might not be relevant here unless this is specific context
							);
						}
					}
				}
				catch (SqlException e)
				{
					System.Diagnostics.Debug.WriteLine(e.Message);
				}
				return ingredient;
			}
		}

        public int GetIngredientIdByName(string ingredientName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ingredientId FROM Ingredient WHERE name = @IngredientName";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IngredientName", ingredientName);

                    var result = command.ExecuteScalar(); 
                    if (result != null)
                    {
                        return Convert.ToInt32(result); // Convert the result to int and return it
                    }
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine("SQL Error: " + e.Message);
                }
                return -1; // Return -1 or another indicator to denote not found/error
            }
        }

        public bool SaveUserDislike(int userId, int ingredientId)
        {
            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO UserPreferences (userID, dislikedIngredient) VALUES (@UserId, @IngredientId)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@IngredientId", ingredientId);

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine("SQL Error: " + e.Message);
                    return false;
                }
            }
        }

        public List<Ingredient> GetUserDislikes(int userId)
        {
            List<Ingredient> dislikes = new List<Ingredient>();
            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                try
                {
                    connection.Open();
                    string query = @"
                    SELECT i.ingredientID, i.name FROM Ingredient i
                    INNER JOIN UserPreferences u ON i.ingredientID = u.dislikedIngredient
                    WHERE u.userID = @UserId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ingredient ingredient = new Ingredient(
                                (byte[])reader["ingredientPicture"], 
                                reader.GetInt32(reader.GetOrdinal("ingredientID")),
                                reader.GetString(reader.GetOrdinal("name")),
                                0, // Quantity not relevant here
                                ""// Measurement unit not relevant here
                                );
                            dislikes.Add(ingredient);
                        }
                    }
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine("SQL Error: " + e.Message);
                }
            }
            return dislikes;
        }

        public bool RemoveUserDislike(int userId, int ingredientId)
        {
            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM UserPreferences WHERE userID = @UserId AND dislikedIngredient = @IngredientId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@IngredientId", ingredientId);

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine("SQL Error: " + e.Message);
                    return false;
                }
            }
        }

        public DateTime GetRecipeCreateDate(int recipeID)
        {
            DateTime creationDate = new DateTime();

            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT dateCreated FROM Recipes WHERE recipeID = @RecipeID";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@RecipeID", recipeID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if a record was found
                        if (reader.Read())
                        {
                            creationDate = reader.GetDateTime(0); // The index (0) represents the first column in the query result
                        }

                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("SQL Error: " + ex.Message);

                }
            }

            return creationDate;
        }

    }
}

