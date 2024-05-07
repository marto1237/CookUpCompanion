using CookUp_Companion_BusinessLogic.InterfacesDal;
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
    public class ShoppingCartDal : Connection, IShoppingCartDALManager
    {
        IUserManager userManager;
        IRecipeManager recipeManager;
        private readonly string tableName = "ShoppingCarItems";
        private string Server_Connection = "Server=mssqlstud.fhict.local;Database=dbi525452_cookup;User Id = dbi525452_cookup; Password=cookup;";

        public ShoppingCartDal(IUserManager userManager, IRecipeManager recipeManager)
        {
            this.userManager = userManager;
            this.recipeManager = recipeManager;
        }
        public bool CreateCart(int userId)
        {
            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {

				try
				{
                    connection.Open();
                    string query = "INSERT INTO ShoppingCarts (userID) VALUES (@userId)";
					using (var command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@userId", userId);

                        int result = command.ExecuteNonQuery(); // This returns the number of rows affected
                        return result > 0;
                    }
				}catch (Exception ex)
				{
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return false;
                }
            }
        }
        public int GetCartIdByUserId(int userId)
        {
            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT cartID FROM ShoppingCarts WHERE userID = @userId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result); // Convert result to int and return it
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("SQL Error retrieving cart ID: " + ex.Message);
                }
                return -1; // Return -1 if no cart found or an error occurred
            }
        }


        public bool AddIngredientToCart(int cartId, int ingredientId, float quantity, string measurementUnit)
        {
            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                try
                {
                    connection.Open();
                    string insertQuery = $"INSERT INTO ShoppingCartItems (cartID, ingredientID, quantity, measurementUnit) VALUES (@CartId, @IngredientId, @Quantity, @MeasurementUnit);";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CartId", cartId);
                        command.Parameters.AddWithValue("@IngredientId", ingredientId);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@MeasurementUnit", measurementUnit);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public List<Ingredient> GetIngredientsInCart(int cartId)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();
                string query = @"SELECT IngredientID, Quantity, MeasurementUnit 
                         FROM ShoppingCartItems 
                         WHERE CartID = @CartId;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CartId", cartId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ingredientId = reader.GetInt32(0);
                            decimal quantity = reader.GetDecimal(1);
                            string measurementUnit = reader.GetString(2);

                            // Fetch ingredient details safely
                            Ingredient ingredient = recipeManager.GetIngredientById(ingredientId);
                            if (ingredient != null)
                            {
                                ingredient.ChangeQuantity((float)quantity);
                                ingredient.ChangeSelectedUnit(measurementUnit);
                                ingredients.Add(ingredient);
                            }
                        }
                    }
                }
            }
            return ingredients;
        }


        public bool RemoveIngredientFromCart(int cartId, int ingredientId, float quantity, string units)
		{

			using (SqlConnection connection = new SqlConnection(Server_Connection))
			{
				try
				{
					connection.Open();
					string deleteQuery = "DELETE FROM ShoppingCartItems WHERE CartID = @CartId AND IngredientID = @IngredientId AND quantity = @Quantity AND measurementUnit = @Unit;";
					using (SqlCommand command = new SqlCommand(deleteQuery, connection))
					{
						command.Parameters.AddWithValue("@CartId", cartId);
						command.Parameters.AddWithValue("@IngredientId", ingredientId);
						command.Parameters.AddWithValue("@Quantity", quantity);
						command.Parameters.AddWithValue("@Unit", units);

						int result = command.ExecuteNonQuery();
						return result > 0;
					}
				}
				catch (SqlException ex)
				{
					System.Diagnostics.Debug.WriteLine("SQL Error: " + ex.Message);
					return false;
				}
			}
		}
        public List<Ingredient> GetShoppingCartIngredients(int userId)
        {
            List<Ingredient> userShoppingCartIngredeints = new List<Ingredient>();
            int userCartID = GetCartIdByUserId(userId);
            if (userCartID != -1)
            {
                using (SqlConnection connection = new SqlConnection(Server_Connection))
                {
                    connection.Open();
                    string query = @"SELECT IngredientID, Quantity, MeasurementUnit 
                         FROM ShoppingCartItems 
                         WHERE CartID = @CartId;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CartId", userCartID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int ingredientId = reader.GetInt32(0);
                                decimal quantity = reader.GetDecimal(1);
                                string measurementUnit = reader.GetString(2);

                                // Fetch ingredient details safely
                                Ingredient ingredient = recipeManager.GetIngredientById(ingredientId);
                                if (ingredient != null)
                                {
                                    ingredient.ChangeQuantity((float)quantity);
                                    ingredient.ChangeSelectedUnit(measurementUnit);
                                    userShoppingCartIngredeints.Add(ingredient);
                                }
                            }
                        }
                    }
                }
                return userShoppingCartIngredeints;
            }
            else
            {
                return userShoppingCartIngredeints;
            }
        }
    }
}
