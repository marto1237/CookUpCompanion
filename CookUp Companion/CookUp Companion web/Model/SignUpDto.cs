using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CookUp_Companion_web.Model
{
    public class SignUpDto
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
    }
}
