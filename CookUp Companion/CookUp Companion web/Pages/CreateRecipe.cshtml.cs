using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Newtonsoft.Json; // Add this namespace for JSON deserialization

namespace CookUp_Companion_web.Pages
{
    public class CreateRecipeModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Recipe picture is required.")]
        public IFormFile ? RecipePicture { get; set; }

        [BindProperty]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "The recipe name should be between 3 and 70 symbols!")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Please enter a valid recipe name!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Recipe name is required!")]
        public string RecipeName { get;  set; }

        [BindProperty]
        [MinLength(10, ErrorMessage = "The description should be atleast 10 symbols!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Recipe name is required!")]
        public string RecipeDescription { get;  set; }


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
        [RegularExpression("^[0-9]$", ErrorMessage = "Cooking hours must be a valid two-digit number.")]
        [Required(ErrorMessage = "Cooking hours time is required.")]
        public int CookHours { get; set; }

        [BindProperty]
        [RegularExpression("^[0-5]?[0-9]$", ErrorMessage = "Cooking minutes must be a valid two-digit number.")]
        [Required(ErrorMessage = "Cooking minutes time is required.")]
        public int CookMinutes { get; set; }

        [BindProperty]
        public List<string> IngredientPicture { get; set; } = new List<string>();

        [BindProperty]
        public List<int> IngredientId { get; set; } = new List<int>();

        [BindProperty]
        public List<string> IngredientName { get; set; } = new List<string>();

        [BindProperty]
        public List<string> SelectedIngredientMeasurmentUnits { get; set; } = new List<string>();
        [BindProperty]
        public List<float> IngredientQuanity { get; set; } = new List<float>();


        public User _user { get; private set; }

        private readonly IRecipeManager recipeManager;
        private readonly IUserManager userManager;

        public List<Ingredient> Ingredients = new List<Ingredient>();

        public CreateRecipeModel(IRecipeManager recipeManager, IUserManager userManager)
        {
            this.recipeManager = recipeManager;
            this.userManager = userManager;
        }



        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            

            if (!ModelState.IsValid)
            {
                // If ModelState is not valid, return the page with validation errors
                return Page();
            }

            
            // If ModelState is valid, process the form data
            // Convert the uploaded image to a byte array
            byte[] pictureBytes = null;
            if (RecipePicture != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await RecipePicture.CopyToAsync(ms);
                    pictureBytes = ms.ToArray();
                }
            }

            /// Convert the Recipe PrepTime and CookingTime into minutes
            int totalPrepMinutes = PrepHours * 60 + PrepMinutes;
            int totalCookMinutes = CookHours * 60 + CookMinutes;

            // If ModelState is valid, process the form data

            // Change the foreach loop to iterate over the indexes of the collections
            for (int i = 0; i < IngredientPicture.Count; i++)
            {
                // Retrieve values for each ingredient
                string ingredientPicture = IngredientPicture[i];
                byte[] ingredientPic = Convert.FromBase64String(ingredientPicture);
                int ingredientId = IngredientId[i];
                string ingredientName = IngredientName[i];
                string measurmentUnits = SelectedIngredientMeasurmentUnits[i];
                float ingredientQuantity = IngredientQuanity[i];

                // Create an Ingredient object using the retrieved values
                Ingredient ingredient = new Ingredient(ingredientPic, ingredientId, ingredientName, ingredientQuantity,measurmentUnits);

                // Add the ingredient to the Ingredients list
                Ingredients.Add(ingredient);
            }

            // Retrieve the authenticated user's claims
            var userClaims = HttpContext.User.Claims;

            //get the user id fro mthe claims

            // Extract user data from claims
            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var userNameClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            var roleClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);
               
            
            }
            if(_user != null)
            {
                Recipe recipe = new Recipe(pictureBytes,_user,RecipeName, RecipeDescription ,Ingredients, Instructions, totalCookMinutes, totalPrepMinutes);
                recipeManager.CreateRecipe(recipe);
            }

            TempData["IsSuccess"] = true;
            //Recipe recipe = new Recipe(pictureBytes, current user, RecipeDescription, Ingredients, Instructions, CookMinutes, PrepMinutes);
            // Redirect to a success page or perform any other action
            return RedirectToPage("/CreateRecipe");
        }
    }

}



