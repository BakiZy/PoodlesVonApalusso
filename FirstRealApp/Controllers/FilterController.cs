using AutoMapper;
using AutoMapper.QueryableExtensions;
using FirstRealApp.Models.DTO_models.FilterDTOS;
using FirstRealApp.Models.DTO_models.PoodleDTos;
using FirstRealApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstRealApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly IFilterService poodleService;
        private readonly IMapper _mapper;

        public FilterController(IFilterService filterRepository, IMapper mapper)
        {
            poodleService = filterRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("/api/filters/color-and-size")]

        public IActionResult FilterSizeAndCollor([FromQuery] FilterPoodleDTO filter)
        {
            return Ok(poodleService.FilterSizeAndColor(filter.SizeName, filter.ColorName).ProjectTo<PoodleDTO>(_mapper.ConfigurationProvider).ToList());
        }

        [HttpGet]
        [Route("/api/filters/min-max-year")]

        public async Task<IActionResult> FilterByYear([FromQuery] YearFilterDTO filter)
        {
            var result = await poodleService.FilterDate(filter.DateMin, filter.DateMax);

            return Ok(result);

        }




    }


}
