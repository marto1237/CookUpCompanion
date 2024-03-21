    using CookUp_Companion_web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    namespace CookUp_Companion_web.Pages
    {
        public class CreateRecipeModel : PageModel
        {
            [BindProperty]
            public CreateRecipe createRecipe { get; set; }
            public void OnGet()
            {
            }
            public void OnPost() 
            {

            }
        }
    }
