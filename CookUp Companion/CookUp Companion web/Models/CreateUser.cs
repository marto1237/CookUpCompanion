using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CookUp_Companion_web.Models
{
    public class CreateUser
    {
        [Required , MinLength(3)]
        public string Name { get; set; }
        [Required , EmailAddress]
        public string Email { get; set; }
        [Required , DataType(DataType.Password)]
        public string Password { get; set; }
        [Required , DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public CreateUser()
        {

        }
    }
}
