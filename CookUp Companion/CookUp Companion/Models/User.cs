using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUp_Companion
{
    public class User
    {
        public byte[] ProfilePicture {  get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Roles Role { get; private set; }

        public List<Ingredient> Dislikes { get; private set; }
        public List<Recipe> SavedRecipes { get; private set; }
        public List<Recipe> LikedRecipes { get; private set; }


        public User(byte[] profilePicture, string username, string email, string password, string firstName, string lastName, Roles role)
        {
            ProfilePicture = profilePicture;
            Username = username;
            Email = email;
            Password = password;
            FirstName = firstName;  
            LastName = lastName;
            Role = role;
            Dislikes = new List<Ingredient>();
            SavedRecipes = new List<Recipe>();
            LikedRecipes = new List<Recipe>();
        }

        public string GetUsername()
        {
            return Username;
        }

        public byte[] GetProfilePic()
        {
            return ProfilePicture;
        }

        public string GetEmail()
        {
            return Email;
        }

        public string GetName()
        {
            return FirstName + " " + LastName;
        }

        public Roles GetRole()
        {
            return Role;
        }

        public List<Ingredient> DislikesIngredients()
        {
            return Dislikes;
        }

        public List<Recipe> GetSavedRecipes()
        {
            return SavedRecipes;
        }

        public List<Recipe> GetLikedRecipes()
        {
            return LikedRecipes;
        }
    }
}
