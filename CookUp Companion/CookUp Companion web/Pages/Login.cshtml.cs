using CookUp_Companion_web.Models;
using Logic;
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
        public UserDTO userDTO { get; set; }

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

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

			claims.Add(new Claim(ClaimTypes.Name, userDTO.Email));

			if (userDTO.Email.ToLower().Contains("employee"))
            {
				claims.Add(new Claim(ClaimTypes.Role, "employee"));
            }
            else if (userDTO.Email.ToLower().Contains("admin"))
            {
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
            }
            else { return Page(); }
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToPage("/Index");
        }
    }
}
