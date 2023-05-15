using System.ComponentModel.DataAnnotations;

namespace PizzaBE.Application.DTOs.ApplicationUser
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        //[EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }
}
