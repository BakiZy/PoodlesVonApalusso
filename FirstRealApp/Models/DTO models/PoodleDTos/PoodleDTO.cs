namespace FirstRealApp.Models.DTO_models.PoodleDTos
{
    public class PoodleDTO
    {

        public int Id { get; set; }

      
        public string? Name { get; set; }

        
        public DateTime DateOfBirth { get; set; }

        public bool? GeneticTests { get; set; }

        public string? PedigreeNumber { get; set; }

        public string? Sex { get; set; }

        public int? PoodleSizeId { get; set; }
        public string? PoodleSizeName { get; set; }

        public int? PoodleColorId { get; set; }

        public string? PoodleColorName{ get; set; }

        public int? ImageId { get; set; }

        public string? ImageUrl { get; set; }
        
        public string? ImagePedigreeUrl { get; set; }



    }
}
