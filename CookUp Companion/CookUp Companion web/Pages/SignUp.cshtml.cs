using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using InterfacesLL;
using Logic;

namespace CookUp_Companion_web.Pages
{
    public class SignUpModel : PageModel
    {
        
        [BindProperty]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Firtst name should be between 3 and 50 symbols!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid first name!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required!")]
        public string? FirstName { get; set; }

        [BindProperty]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name should be between 8 and 50 symbols!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid first name!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required!")]
        public string? LastName { get; set; }

        [BindProperty]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username should be between 8 and 50 symbols!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required!")]
        public string? Username { get; set; }

        [BindProperty]
        [EmailAddress(ErrorMessage = "Enter a valid email address!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required!")]
        public string? Email { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        public string? Password { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }


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

            
            else if (Password != ConfirmPassword)
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
                                        Username, 
                                        Email, 
                                        Password, 
                                        FirstName, 
                                        LastName, 
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
