using System.ComponentModel.DataAnnotations;

namespace FirstRealApp.Models.DTO_models
{
    public class RegisterDTO
    {

        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "email is required")]
        public string? Email { get; set; }

    }
}
