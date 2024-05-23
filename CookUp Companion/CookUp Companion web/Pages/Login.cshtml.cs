using CookUp_Companion_web.Model;
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
        public LoginDto Login { get; set; }

        
        public string AppealMessage { get; set; }


        private readonly IUserManager userManager;
        public LoginModel(IUserManager userManager)
        {
            this.userManager = userManager;
            Login = new LoginDto();
        }

        public void OnGet()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {

                Response.Redirect("/Profile");
                return;
            }
            // Check if the UserEmail cookie exists
            if (Request.Cookies[nameof(Login.Email)] != null)
            {
                Login.Email = Request.Cookies[nameof(Login.Email)];
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Oops Something went wrong!";
                return Page();
            }
            if (Login == null)
            {
                Login = new LoginDto();
            }

            try
            {
                (User user, bool isBanned, string banReason) = userManager.GetUserAndBanInfo(Login.Email);

                if (user != null)
                {
                    if (isBanned)
                    {
                        TempData["IsBanned"] = true;
                        TempData["BanReason"] = banReason;
                        return Page();
                    }

                    // Get the appeal message from the form submission
                    string appealMessage = AppealMessage;

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, userManager.GetRole(user))
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    if (Login.RememberMe) // assuming your checkbox has name="rememberMe"
                    {
                        CookieOptions options = new CookieOptions();
                        options.Expires = DateTimeOffset.Now.AddDays(30); // Set expiration as needed
                        Response.Cookies.Append(nameof(Login.Email), user.Email, options);
                    }

                    // Assuming you have a method to store the appeal in the database
                    bool appealSent = true; //userManager.SendAppeal(userIdentity.Name, AppealMessage);

                    if (appealSent)
                    {
                        // Show a success alert
                        TempData["AppealSent"] = true;
                    }
                    else
                    {
                        // Show an error alert
                        TempData["AppealSent"] = false;
                    }


                    // Get the authenticated user's identity
                    var userIdentity = HttpContext.User.Identity;

                    
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
