using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CookUp_Companion_web.Models
{
    public class CreateRecipe
    {
        public byte[] RecipePicture { get; set; }

        [Required, MinLength(3)]
        public string RecipeName { get; set; }

        
        

        [Required]
        public string RecipeDescription { get; set; }

        [Required]
        public List<string> Ingredients { get; set; }

        [Required]
        public List<string> Instructions { get; set; }

        [Required]
        public int Servings { get; set; }

        public int PrepHours { get; set; }

        [Required]
        public int PrepMinutes { get; set; }

        public int CookHours { get; set; }

        [Required]
        public int CookMinutes { get; set; }

        public CreateRecipe()
        {

        }
    }
}
