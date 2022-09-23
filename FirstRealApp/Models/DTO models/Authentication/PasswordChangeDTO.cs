using System.ComponentModel.DataAnnotations;

namespace FirstRealApp.Models.DTO_models
{
    public class PasswordChangeDTO
    {


        [Required(ErrorMessage = "username required")]

        public string? Username { get; set; }


        [Required(ErrorMessage = "Current assword is required")]
        [DataType(DataType.Password)]
        public string? CurrentPassword { get; set; }


        [Required(ErrorMessage = "new Password is required")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "password's mustc match")]
        public string? ConfirmPassword { get; set; }
    }
}
