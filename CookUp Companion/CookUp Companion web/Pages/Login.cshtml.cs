using CookUp_Companion_web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookUp_Companion_web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            // Your authentication logic here
            // Authenticate user and retrieve user information

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "username"), // Example claim, replace with actual user information
                // Add more claims as needed
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                // Customize any additional properties if needed
                IsPersistent = true,
                RedirectUri = returnUrl
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return LocalRedirect(returnUrl ?? "/");
        }

    }
}
