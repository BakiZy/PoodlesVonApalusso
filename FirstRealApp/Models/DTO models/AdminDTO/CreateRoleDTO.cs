using System.ComponentModel.DataAnnotations;

namespace FirstRealApp.Models.DTO_models
{
    public class CreateRoleDTO
    {
       

        [Required]
        public string? RoleName { get; set; }


    }
}
