using System.ComponentModel.DataAnnotations;

namespace CookUp_Companion_web.Models
{
    public class User
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public User() 
        {

        }

    }
}
