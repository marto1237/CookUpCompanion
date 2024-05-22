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

        public string AppealMessage { get; set; }


        private readonly IUserManager userManager;
        public LoginModel(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public void OnGet()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {

                Response.Redirect("/Profile");
                return;
            }
            // Check if the UserEmail cookie exists
            if (Request.Cookies["UserEmail"] != null)
            {
                Email = Request.Cookies["UserEmail"];
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
                        int userID = userManager.GetIdByUsername(user.Username);
                        string reason = userManager.GetBanReason(userID);
                        TempData["IsBanned"] = true;
                        TempData["BanReason"] = reason;


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

                    if (Request.Form["rememberMe"].Contains("on")) // assuming your checkbox has name="rememberMe"
                    {
                        CookieOptions options = new CookieOptions();
                        options.Expires = DateTimeOffset.Now.AddDays(30); // Set expiration as needed
                        /*"UserEmail"*/
                        Response.Cookies.Append(nameof(user.Email), user.Email, options);
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
