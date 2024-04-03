using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookUp_Companion_web.Pages
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        [EmailAddress(ErrorMessage = "Enter a valid email address!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required!")]
        public string? Email { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        public string? Password { get; set; }

        List<Claim> claims = new List<Claim>();
        //public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        //{

        //    // Your authentication logic here
        //    // Authenticate user and retrieve user information

        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, "username"), // Example claim, replace with actual user information
        //        // Add more claims as needed
        //    };

        //    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //    var authProperties = new AuthenticationProperties
        //    {
        //        // Customize any additional properties if needed
        //        IsPersistent = true,
        //        RedirectUri = returnUrl
        //    };

        //    await HttpContext.SignInAsync(
        //        CookieAuthenticationDefaults.AuthenticationScheme,
        //        new ClaimsPrincipal(claimsIdentity),
        //        authProperties);

        //    return LocalRedirect(returnUrl ?? "/");
        //}
        private readonly IUserManager userManager;
        public LoginModel(IUserManager _userManager)
        {
            userManager = _userManager;
        }

        public void OnGet()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {

                Response.Redirect("/Account/YourAccount");
                return;
            }

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
                

                User user = userManager.Login(Email, Password);
                if (user != null)
                {
                    if (userManager.BannedUser(user))
                    {
                        ViewData["Error"] = "You are currently banned!";
                        return Page();
                    }

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                        new Claim(ClaimTypes.Role, userManager.GetRole(user))
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Sign in the user with the created identity
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToPage("/Index");
                }
                else
                {
                    TempData["IsLogInError"] = true;
                    ViewData["EmailPasswordError"] = "Check your email and password !";
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

    }
}
