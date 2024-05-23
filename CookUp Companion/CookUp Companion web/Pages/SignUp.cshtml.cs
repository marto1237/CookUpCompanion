using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using InterfacesLL;
using Logic;
using CookUp_Companion_web.Model;

namespace CookUp_Companion_web.Pages
{
    public class SignUpModel : PageModel
    {

        [BindProperty]
        public SignUpDto SignUp { get; set; }


        private readonly IUserManager userManager;
        public SignUpModel(IUserManager _userManager)
        {
            userManager = _userManager;
        }

        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Something went wrong!";
                return Page();
            }

            
            else if (SignUp.Password != SignUp.ConfirmPassword)
            {
                ViewData["Error"] = "Passwords doesn't match";
                return Page();
            }
            else
            {
                // Instantiate a new User object with the form data
                // 1 is the role ID for users
                // Create a new instance of UserDal
                User newUser = new User(null,
                                        SignUp.Username,
                                        SignUp.Email,
                                        SignUp.Password,
                                        SignUp.FirstName,
                                        SignUp.LastName, 
                                        1, 
                                        null);

                

                if (userManager.CheckExistingUsername(newUser.Username))
                {
                    ViewData["UsernameError"] = "The username is already in use by another user. Please choose a different username.";
                    return Page();
                }
                if (userManager.CheckExistingEmail(newUser.Email))
                {
                    ViewData["EmailError"] = "The email is already in use. Please use a different email address.";
                    return Page();
                }

                // Attempt to create the user
                bool creationResult = userManager.CreateUser(newUser);
                if (!creationResult)
                {
                    // Log the error or handle it appropriately
                    ViewData["Error"] = "An error occurred while creating your account. Please try again.";
                    return Page();
                }
                // If successful, redirect to the login page or a confirmation page
                TempData["RegistrationSuccess"] = "You have successfully registered. You can now login.";
                return RedirectToPage("/Login");


            }
           
            

			
        }
    }
}
