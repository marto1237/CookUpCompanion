using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookUp_Companion_web.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly ILogger<ProfileModel> _logger;

        public ProfileModel(ILogger<ProfileModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            // byte[] profilePictureBytes = userManager.GetProfilePicture();
            // ProfilePictureBase64 = Convert.ToBase64String(profilePictureBytes);
        }

    }
}
