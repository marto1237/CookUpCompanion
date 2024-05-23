using System.ComponentModel.DataAnnotations;

namespace CookUp_Companion_web.Model
{
    public class LoginDto
    {
        [EmailAddress(ErrorMessage = "Enter a valid email address!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required!")]
        public string? Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
