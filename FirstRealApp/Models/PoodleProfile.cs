using AutoMapper;
using FirstRealApp.Models.DTO_models.PoodleDTos;
using FirstRealApp.Models.PoodleEntity;

namespace FirstRealApp.Models
{
    public class PoodleProfile : Profile
    {
        public PoodleProfile()
        {
            CreateMap<Poodle, PoodleDTO>();
           


        }
    }
}
