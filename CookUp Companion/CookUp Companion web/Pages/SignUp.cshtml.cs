using CookUp_Companion_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookUp_Companion_web.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public CreateUser createUser { get; set; }

        public string IsValid { get; private set; }
        public void OnGet()
        {
        }
        public void OnPost() 
        {
            

            //Validate the data if it is in correct format 
            IsValid = "NotValid";

            //If
            if (ModelState.IsValid)
            {
                // Process form submission
                IsValid = "Valid";
            }

            //Make user class and save it in the database

            //Give Error message
        }
    }
}
