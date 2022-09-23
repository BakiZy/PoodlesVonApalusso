using System.ComponentModel.DataAnnotations;

namespace FirstRealApp.Models.DTO_models.AdminDTO
{
    public class EditRoleDTO
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "rolename is required")]
        public string? RoleName { get; set; }

        public List<string>? Users { get; set; }

    }
}
