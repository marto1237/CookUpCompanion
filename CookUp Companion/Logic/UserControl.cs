using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using System.Security.Cryptography;
using System.IO;

namespace Logic
{
    public class UserControl
    {
        public List<User> users { get; private set; }
        public UserControl()
        {
            users = new List<User>();
        }
        public void SignUp(byte[] profilePic, string username, string email,string first_name, string last_name, string password, int roleId)
        {

            Preference preference = new Preference();

            User createUser = new User(profilePic, username, email, password, first_name, last_name, roleId, preference);

            users.Add(createUser);
        }

        public bool Login(string email, string password)
        { 
            return true;

            //add function there to verify is the credentials are right
        }
        public void ChangeUserRole(string email, int roleID)
        {
            User userToPromote = users.Find(u=> u.Email == email);

            if (userToPromote != null)
            {
                userToPromote.ChangeRole(roleID);
            }
        }

        public void DeleteUser(string username, string email)
        {
            User userToDelete = users.Find(u=> u.Username == username && u.Email ==email);

            if (userToDelete != null)
            {
                users.Remove(userToDelete);
                //emplement funtion to the delete the user from the database 
            }
        }

        public bool ChangePassword(string email, string password, string newPassword)
        {
            //Check use the user put the right credentials from the database and if yes ask for new password which will be set
            User user = users.Find(u=> u.Email==email && u.Password == password);

            if (user != null)
            {
                user.ChangePassword(newPassword);
            }

            return true;
        }
        public void AddDislikes(User user, Ingredient ingredient)
        {
            user.Preferences.AddDislikedIngredient(ingredient);
        }

        public void RemoveDislikes(User user, Ingredient ingredient)
        {
            user.Preferences.RemoveDislikedIngredient(ingredient);
        }

        public void AddRecipeToSaved(User user, Recipe recipe)
        {
            user.Preferences.AddSavedRecipe(recipe);
        }

        public void RemoveRecipeFromSaved(User user, Recipe recipe)
        {
            user.Preferences.RemoveSavedRecipe(recipe);
        }

        public void AddRecipeToLiked(User user, Recipe recipe)
        {
            user.Preferences.AddLikedRecipe(recipe);
        }

        public void RemoveRecipeFromLiked(User user, Recipe recipe)
        {
            user.Preferences.RemoveLikedRecipe(recipe);
        }
    }
}
