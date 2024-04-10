using InterfacesLL;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace CookUp_Companion_web.Pages
{
    [Authorize] // Restricts access to authenticated users only
    public class ProfileModel : PageModel
    {
        private readonly ILogger<ProfileModel> _logger;
        private User user;

        private readonly IUserManager userManager;
        public ProfileModel(IUserManager userManager)
        {
            this.userManager = userManager;
        }


        public byte[] UserProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; private set; }
        public string Username { get; private set; }
        public string Role { get; private set; }
        public User _user  { get; private set; }
        public void OnGet()
        {
            // Retrieve the authenticated user's claims
            var userClaims = HttpContext.User.Claims;

            //get the user id fro mthe claims

            // Extract user data from claims
            var userEmailClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var userNameClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            var roleClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            if (userEmailClaim != null)
            {
                _user = userManager.GetUserByEmail(userEmailClaim.Value);
            }

            if (_user != null)
            {
                UserProfilePicture = _user.ProfilePicture;
                FirstName = _user.FirstName;
                LastName = _user.LastName;
                Username = _user.Username;
            }
        }

    }
}
