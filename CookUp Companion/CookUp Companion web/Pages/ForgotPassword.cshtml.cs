using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CookUp_Companion_web.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        [BindProperty]
        [EmailAddress(ErrorMessage = "Enter a valid email address!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required!")]
        public string? Email { get; set; }
        [BindProperty]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        public string? NewPassword { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        [Compare(nameof(NewPassword), ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

        private readonly IUserManager userManager;
        public ForgotPasswordModel(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Oops Something went wrong!";
                return Page();
            }

            try
            {


                User user = userManager.GetUserByEmail(Email);
                if (user != null)
                {
                    bool IsPasswordChanged = userManager.UpdateUserPassword(user, NewPassword);
                    if(IsPasswordChanged)
                    {
                        TempData["PasswordChanged"] = true;
                        return RedirectToPage("/Login");
                    }
                    else
                    {
                        ViewData["Error"] = "Oops Something went wrong changing the password!";
                        return Page();
                    }

                }
                else
                {
                    TempData["IsEmailExist"] = true;
                    ViewData["EmailError"] = "There is no user with that email!";
                    return Page();
                }
            }
            catch (Exception)
            {
                // Handle exception
                ViewData["Error"] = "Oops Something went wrong!";
                return Page();
            }
        }
        public void OnGet()
        {
        }
    }
}
