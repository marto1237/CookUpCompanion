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
	public class UserDal : Connection , IUserDALManager
	{
		private readonly string tableName = "Users";

		public UserDal() { }

		/*Query that create new user in the database */
		public bool InsertUser(User newUser)
		{
			using (SqlConnection connection = base.connection)
			{
				// Open the connection
				connection.Open();

				// Set up the query
				string query = $"INSERT INTO {tableName} " +
							   $"(username, firstName, lastName, email, password, passwordSalt, roleID, profilePicture) " +
							   $"VALUES (@username, @firstName, @lastName, @email," +
							   $"@passwordHash, @passwordSalt, @role, @profilePicture)";

				// Creating Command string to combine the query and the connection String
				SqlCommand command = new SqlCommand(query, base.connection);

				try
				{
					command.Parameters.AddWithValue("@username", newUser.Username);
					command.Parameters.AddWithValue("@firstName", newUser.FirstName);
					command.Parameters.AddWithValue("@lastName", newUser.LastName);
					command.Parameters.AddWithValue("@email", newUser.Email);
					command.Parameters.AddWithValue("@role", 1);// User role ID for users
					command.Parameters.AddWithValue("@passwordHash", newUser.Password);
					command.Parameters.AddWithValue("@passwordSalt", newUser.PasswordSalt);

					// Load the default profile picture
					byte[] defaultProfilePicture = File.ReadAllBytes("user.png");
					command.Parameters.AddWithValue("@profilePicture", defaultProfilePicture);


					// Execute the query and get the data
					using SqlDataReader reader = command.ExecuteReader();

					return true;
				}
				catch (SqlException e)
				{
					// Handle any errors that may have occurred.
					System.Diagnostics.Debug.WriteLine(e.Message);
					return false;
				}
			}
			
		}

        /*Query that get the user on login from the database */

        public User GetUserByEmail(string email)
        {
            User user = null;

            using (SqlConnection connection = base.connection)
			{
				connection.Open();

				//set up the query 

				string query = $"SELECT * FROM {tableName} WHERE email = @email";

				SqlCommand command = new SqlCommand (query, connection);

                
				try
				{
					//Give the searche email parameter
					command.Parameters.AddWithValue("@email", email);
					//Execute the query and get the data
					using SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						user = new User(
                                (byte[])reader["profilePicture"],
								(string)reader["username"],
								(string)reader["email"],
								(string)reader["password"],
								(string)reader["firstName"],
								(string)reader["lastName"],
								(int)reader["roleID"],
								////NEED TO FIX THAT WHEN USER LOGIN
								null


                        );
                        user.GetSaltForDb(reader["passwordSalt"].ToString());
                    }
				}
				catch(SqlException e)
				{
					// Handle any errors that may have occurred.
					System.Diagnostics.Debug.WriteLine(e.Message);


                }
            }

			return user;
		}

		public User Login(string email, string password)
		{
            User user = null;

            using (SqlConnection connection = base.connection)
            {
                connection.Open();

                //set up the query 

                string query = $"SELECT * FROM {tableName} WHERE email = @email";

                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    //Give the searche email parameter
                    command.Parameters.AddWithValue("@email", email);
                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User(
                                (byte[])reader["profilePicture"],
                                (string)reader["username"],
                                (string)reader["email"],
                                (string)reader["password"],
								//Password
                                (string)reader["firstName"],
                                (string)reader["lastName"],
                                (int)reader["roleID"],
                                ////NEED TO FIX THAT WHEN USER LOGIN
                                null


                        );
                        user.GetSaltForDb(reader["passwordSalt"].ToString());
						if (user.VerifyPassword(password))
						{
							return user;
						}
						else
						{
							//Give error message that the login failed
							return null;
						}
                    }
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);


                }
            }

            return null;
		}

		public bool CheckExistingEmail(string email)
		{
			using(SqlConnection connection = base.connection)
			{
				connection.Open();

				string query = $"SELECT * FROM {tableName} WHERE email = @email";

				SqlCommand command = new SqlCommand(query, connection);

				try
				{
					command.Parameters.AddWithValue("@email", email);
					using SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						return true;
					}
				}
				catch (SqlException e)
				{
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
				return false;
			}
		}
		public bool CheckExistingUsername(string username)
		{
            using(SqlConnection connection = base.connection)
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName} WHERE username = @username";

				SqlCommand command = new SqlCommand(query, connection);

				try
				{
					command.Parameters.AddWithValue("@username", username);
					using SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						return true;
					}
				}
				catch (Exception e)
				{
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
				return false;
			}
		}

    }
}
