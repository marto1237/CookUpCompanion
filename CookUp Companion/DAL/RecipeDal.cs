using InterfaceDAL;
using Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RecipeDal : Connection, IRecipeDALManager
    {
        private readonly string tableName = "Recipes";
        private string Server_Connection = "Server=mssqlstud.fhict.local;Database=dbi525452_cookup;User Id = dbi525452_cookup; Password=cookup;";
        public RecipeDal() { }


        public Ingredient GetInputIngredient(string name) 
        {
            Ingredient ingredient = null;

            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();

                string query = "SELECT * FROM Ingredient WHERE name = @name";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@name", name);

                using(SqlDataReader reader = command.ExecuteReader())
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
                string insertRecipeQuery = $"INSERT INTO {tableName} (recipeName, recipePicture, description, cookingInstructions, preparationTime, cookingTime, dateCreated) " +
                                           "VALUES (@RecipeName,@RecipePicture @Description, @Instructions, @PrepTime, @CookTime, @DateCreated); " +
                                           "SELECT SCOPE_IDENTITY();"; // Retrieve the generated ID

                SqlCommand insertRecipeCommand = new SqlCommand(insertRecipeQuery, connection);
                insertRecipeCommand.Parameters.AddWithValue("@RecipeName", recipe.RecipeName);
                insertRecipeCommand.Parameters.AddWithValue("@RecipePicture", recipe.Picture);
                insertRecipeCommand.Parameters.AddWithValue("@Description", recipe.Description);
                insertRecipeCommand.Parameters.AddWithValue("@Instructions", recipe.Instructions);
                insertRecipeCommand.Parameters.AddWithValue("@PrepTime", recipe.PreparationTime);
                insertRecipeCommand.Parameters.AddWithValue("@CookTime", recipe.CookingTime);
                insertRecipeCommand.Parameters.AddWithValue("@DateCreated", DateTime.Now);

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

            using(SqlConnection connection = new SqlConnection(ConnectionString))
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
    }
}
