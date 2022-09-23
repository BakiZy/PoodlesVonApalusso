
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstRealApp.Models.PoodleEntity
{
    public class Poodle
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string? Sex { get; set; }
        [Required]
        public bool? GeneticTests { get; set; }

        [MinLength(5, ErrorMessage = "pedigree must have at least 5 numbers ")]
        [MaxLength(13, ErrorMessage = "pedigree number cannot be longer than 13 characters")]

        public string? PedigreeNumber { get; set; }

        public int? PoodleSizeId { get; set; }
        public PoodleSize? PoodleSize { get; set; }

        public int? PoodleColorId { get; set; }
        public PoodleColor? PoodleColor { get; set; }

        public int? ImageId { get; set; }

        public Image? Image { get; set; }
















    }
}
