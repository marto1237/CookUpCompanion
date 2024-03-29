using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CookUp_Companion_web.Pages
{
    public class CreateRecipeModel : PageModel
    {
        [BindProperty]
        [Required]
        public byte[] ? RecipePicture { get; set; }
        [BindProperty]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "The recipe name should be between 3 and 70 symbols!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid recipe name!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Recipe name is required!")]
        public string RecipeName { get; private set; }

        [BindProperty]
        [MinLength(10, ErrorMessage = "The description should be atleast 10 symbols!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Recipe name is required!")]
        public string RecipeDescription { get;  set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingredient name is required!")]
        public List<Ingredient> Ingredients { get;  set; }

        [BindProperty]
        [MinLength(10, ErrorMessage = "The instruction should be atleast 10 symbols!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Instruction is required!")]
        public string Instructions { get;  set; }

        
        [BindProperty]
        [RegularExpression("^[0-9]$", ErrorMessage = "Preparation hours must be a single digit.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Preparation hours time is required!")]
        public int PrepHours { get;  set; }

        [BindProperty]
        [RegularExpression("^[0-5]?[0-9]$", ErrorMessage = "Preparation minutes must be a valid two-digit number.")]
        [Required(ErrorMessage = "Preparation minutes time is required.")]
        public int PrepMinutes { get; set; }

        [BindProperty]
        [RegularExpression("^[0-5]?[0-9]$", ErrorMessage = "Preparation minutes must be a valid two-digit number.")]
        [Required(ErrorMessage = "Preparation minutes time is required.")]
        public int CookHours { get; set; }

        [BindProperty]
        [RegularExpression("^[0-5]?[0-9]$", ErrorMessage = "Preparation minutes must be a valid two-digit number.")]
        [Required(ErrorMessage = "Preparation minutes time is required.")]
        public int CookMinutes { get; set; }

        
        

        public void OnGet()
        {
        }
        public void OnPost() 
        {

        }
    }
}
