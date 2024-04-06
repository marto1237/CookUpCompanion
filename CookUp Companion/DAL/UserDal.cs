using InterfaceDAL;
using InterfacesLL;
using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class UserDal : Connection , IUserDALManager
	{
		private readonly string tableName = "Users";
        private string Server_Connection = "Server=mssqlstud.fhict.local;Database=dbi525452_cookup;User Id = dbi525452_cookup; Password=cookup;";
        public UserDal() { }

		/*Query that create new user in the database */
		public bool InsertUser(User newUser)
		{
			using (SqlConnection connection = new SqlConnection(Server_Connection))
			{
				// Open the connection
				connection.Open();

				// Set up the query
				string query = $"INSERT INTO {tableName} " +
							   $"(username, firstName, lastName, email, password, passwordSalt, roleID, profilePicture) " +
							   $"VALUES (@username, @firstName, @lastName, @email," +
							   $"@passwordHash, @passwordSalt, @role, @profilePicture)";

				// Creating Command string to combine the query and the connection String
				SqlCommand command = new SqlCommand(query, connection);

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

            using (SqlConnection connection = new SqlConnection(Server_Connection))
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

        public List<User> GetUsersBySimilarUsername(string username)
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();

                //set up the query 

                string query = $"SELECT DISTINCT * FROM {tableName} WHERE username LIKE '%' + @username + '%'";

                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    //Give the searche email parameter
                    command.Parameters.AddWithValue("@username", username);
                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                       User user = new User(
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
                        users.Add(user);
                    }
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);


                }
            }

            return users;
        }
        public List<User> GetUsersBySimilarEmail(string email)
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();

                //set up the query 

                string query = $"SELECT DISTINCT * FROM {tableName} WHERE email LIKE '%' + @email + '%'";

                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    //Give the searche email parameter
                    command.Parameters.AddWithValue("@email", email);
                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User(
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
                        users.Add(user);
                    }
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);


                }
            }
            return users ;
        }

        public User Login(string email, string password)
		{
            User user = null;

            using (SqlConnection connection = new SqlConnection(Server_Connection))
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
		public string GetRole(User user)
		{
			using(SqlConnection connection = new SqlConnection(Server_Connection))
			{
				connection.Open();

                //get the role id form the user
                string query = $"SELECT Roles.roleName " +
                       $"FROM {tableName} AS Users " +
                       $"INNER JOIN Roles ON Users.roleID = Roles.roleID " +
                       $"WHERE Users.email = @email AND Users.username = @username";


                SqlCommand command = new SqlCommand (query, connection);

                // Set parameters
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@username", user.Username);

                // Execute the query and get the role name
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["roleName"].ToString();
                    }
                }
            }
            return null;
        }
		public bool CheckExistingEmail(string email)
		{
			using(SqlConnection connection = new SqlConnection(Server_Connection))
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
            using(SqlConnection connection = new SqlConnection(Server_Connection))
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
		public bool IsUserBanned(User bannedUser)
		{
			using(SqlConnection connection = new SqlConnection(Server_Connection))
			{
				connection.Open();

				string query = $"SELECT * FROM BannedPeople JOIN Users ON BannedPeople.userID = Users.userID WHERE Users.email = @email OR Users.username = @username";

				SqlCommand command = new SqlCommand(query, connection);

				try
				{
					//add the user email and username to find it is banned
					command.Parameters.AddWithValue("@email", bannedUser.Email);
					command.Parameters.AddWithValue("@username", bannedUser.Username);

					using(SqlDataReader reader = command.ExecuteReader())
					{
						return reader.HasRows;
					}
				}
				catch(Exception e)
				{
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }

                return false;
            }
			
		}

		public List<User> GetAllUsers()
		{
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();

				//set up the query 

				string query = $"SELECT * FROM {tableName}";

                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                       User user = new User(
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
						users.Add(user);
                    }
                }
                catch (SqlException e)
                {
                    // Handle any errors that may have occurred.
                    System.Diagnostics.Debug.WriteLine(e.Message);


                }
            }

            return users;
        }

		public User GetUserById(int id)
		{
			User searchedUser = null;

			using (SqlConnection connection = new SqlConnection(Server_Connection))
			{
				connection.Open();

				string query = $"SELECT * FROM {tableName} WHERE userID = @userID";
				
				SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    //Give the searche email parameter
                    command.Parameters.AddWithValue("@userID", id);
                    //Execute the query and get the data
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        searchedUser = new User(
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
                        searchedUser.GetSaltForDb(reader["passwordSalt"].ToString());

                    }
                }
                catch (SqlException e)
				{
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
			}
			return searchedUser;
		}

        public List<User> GetBySearch(string search)
		{
			

			using(SqlConnection connection = new SqlConnection(Server_Connection))
			{
                connection.Open();

				string query = $"SELECT * FROM {tableName} WHERE Users.username LIKE @search";

                SqlCommand command = new SqlCommand(query, connection);

				try
				{
                    command.Parameters.AddWithValue("@search", "%" + search + "%");

					using SqlDataReader reader = command.ExecuteReader();
					List<User> searchUsers = new List<User>();

					while (reader.Read())
					{
                       User user = new User(
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
						searchUsers.Add(user);
                    }
                    return searchUsers;
                }
				catch(SqlException e)
				{
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }

                return new List<User>();


            }
			
		}

		public bool UpdateUser(User user)
		{
			using(SqlConnection connection = new SqlConnection(Server_Connection))
			{
				connection.Open();

				string query = $"UPDATE {tableName} SET roleID = @roleID, username = @username, firstName = @FirstName, " +
					$"lastName = @LastName, email = @email, password = @password, profilePicture = @profilePicture WHERE userID = @userID";

				SqlCommand command = new SqlCommand (query, connection);

				try
				{
					// Set parameter values

					command.Parameters.AddWithValue("@roleID", user.RoleId);
					command.Parameters.AddWithValue("@username", user.Username);
					command.Parameters.AddWithValue("@FirstName", user.FirstName);
					command.Parameters.AddWithValue("@LastName", user.LastName);
					command.Parameters.AddWithValue("@email", user.Email);
					command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@profilePicture", user.ProfilePicture);
                    command.Parameters.AddWithValue("@userID", GetIdByUsername(user.Username));

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected (updated)
                    if (rowsAffected > 0)
                    {
                        return true; // Successfully updated the user
                    }
                    else
                    {
                        return false; // No rows were updated
                    }

                }
                catch(SqlException e)
				{
                    System.Diagnostics.Debug.WriteLine(e.Message);
					return false;
                }
			}
		}

		public bool DeleteUser(int userId)
		{
			using (SqlConnection connection = new SqlConnection(Server_Connection))
			{
				connection.Open();

                string query = $"DELETE FROM {tableName} WHERE userID = @userID";

                SqlCommand command = new SqlCommand(query, connection);

				try
				{
                    // Set parameter value
                    command.Parameters.AddWithValue("@userID", userId);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected (deleted)
                    if (rowsAffected > 0)
                    {
                        return true; // Successfully deleted the user
                    }
                    else
                    {
                        return false; // No rows were deleted (user with specified ID not found)
                    }
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return false;
                }
            }
		}
        public int GetIdByUsername(string username)
        {
            int userId = -1;

            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();

                string query = $"SELECT userID FROM {tableName} WHERE username = @username";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    //Give the searche email parameter
                    command.Parameters.AddWithValue("@username", username);
                    // Execute the query and get the user ID
                    object result = command.ExecuteScalar();

                    // Check if a result was obtained
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            return userId;
        }
        public bool BanUser(User banningUser , User bannedUser, string reason, int banLevel)
		{
			using(SqlConnection connection = new SqlConnection(Server_Connection))
			{
				connection.Open();

				string query = $"INSERT INTO BannedPeople " +
                               $"(userID, reason, banLevel, bannedOn, bannedBy) " +
                               $"VALUES (@userID, @reason, @banLevel, @bannedOn, @bannedBy)";

				SqlCommand command = new SqlCommand(query, connection);

                try
				{
                    // Set parameters for banning user
                    command.Parameters.AddWithValue("@userID", GetIdByUsername(bannedUser.Username)); 
                    command.Parameters.AddWithValue("@reason", reason);
                    command.Parameters.AddWithValue("@banLevel", banLevel); 
                    command.Parameters.AddWithValue("@bannedOn", DateTime.Now); 
                    command.Parameters.AddWithValue("@bannedBy", GetIdByUsername(banningUser.Username));

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected (deleted)
                    if (rowsAffected > 0)
                    {
                        return true; // Successfully deleted the user
                    }
                    else
                    {
                        return false; // No rows were deleted (user with specified ID not found)
                    }
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return false;
                }
            }
		}
        public List<User> GetBannedUsers()
        {
            List<User> bannedUsers = new List<User>();

            using ( SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();

                string query = $"SELECT BannedPeople.userID, Users.profilePicture, Users.username, Users.email, Users.password, " +
                       $"Users.firstName, Users.lastName, Users.roleID, Users.passwordSalt " +
                       $"FROM BannedPeople " +
                       $"INNER JOIN Users ON BannedPeople.userID = Users.userID";


                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User(
                                (byte[])reader["profilePicture"],
                                (string)reader["username"],
                                (string)reader["email"],
                                (string)reader["password"],
                                (string)reader["firstName"],
                                (string)reader["lastName"],
                                (int)reader["roleID"],
                                null // You need to handle salt retrieval as per your application logic
                            );

                            user.GetSaltForDb(reader["passwordSalt"].ToString());
                            bannedUsers.Add(user);
                        }
                    }
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            return bannedUsers;
        }

        public bool UnbanUser(int userId)
        {
            using( SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();

                string query = $"DELETE FROM BannedPeople WHERE userID = @userID";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    command.Parameters.AddWithValue("@userID", userId);
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0; // Return true if rows were affected (user unbanned)
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public string GetBanReason(int userID)
        {
            string reason = string.Empty;
            using ( SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();

                string query = $"SELECT reason FROM BannedPeople WHERE  userID = @userID";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    command.Parameters.AddWithValue("@userID", userID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve the ban reason from the database
                            reason = reader.GetString(0);
                        }
                    }
                }
                catch( SqlException e )
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    
                }
            }
            return reason;
        }

        public bool UpdateUserPassword(User user)
        {
            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();

                string query = $"UPDATE {tableName} SET password = @password WHERE userID = @userID";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    // Set parameter values

                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@userID", GetIdByUsername(user.Username));

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected (updated)
                    if (rowsAffected > 0)
                    {
                        return true; // Successfully updated the user
                    }
                    else
                    {
                        return false; // No rows were updated
                    }

                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public List<string> AllRoles()
        {
            List<string> roles = new List<string>();

            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();

                string query = "SELECT RoleName FROM Roles";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(reader.GetString(0));
                        }
                    }
                    

                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                   
                }
            }
            return roles;
        }

        public int GetRoleIdByRoleName(string roleName)
        {
            int roleID = -1;

            using (SqlConnection connection = new SqlConnection(Server_Connection))
            {
                connection.Open();

                string query = "SELECT roleId FROM Roles WHERE roleName = @roleName";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@roleName", roleName);

                try
                {
                    // Execute the query and retrieve the role ID
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        roleID = Convert.ToInt32(result);
                    }

                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    
                }
            }
            return roleID ;
        }
    }
}
