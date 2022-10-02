using AutoMapper;
using AutoMapper.QueryableExtensions;
using FirstRealApp.Models.DTO_models.PoodleDTos;
using FirstRealApp.Models.PoodleEntity;
using FirstRealApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstRealApp.Controllers
{
    [Route("api/poodles")]
    [ApiController]
    [Authorize]

    public class PoodlesController : ControllerBase
    {
        
        private readonly IPoodlesRepository _poodlesRepository;
        private readonly IMapper _mapper;

        public PoodlesController(IPoodlesRepository poodlesRepository,  IMapper mapper)
        {
            
            _poodlesRepository = poodlesRepository;
            _mapper = mapper;
        }

        
        

        [HttpGet]
        [AllowAnonymous]
        [Route("/api/poodles/list-sizes")]
        public async Task<ActionResult<List<PoodleSize>>> GetAllPoodleSizes()
        {
            return Ok(await _poodlesRepository.GetAllSizes());
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllPoodles()
        {
            var poodles = await _poodlesRepository.GetAllPoodles();
            return Ok(poodles.ProjectTo<PoodleDTO>(_mapper.ConfigurationProvider));
        }


        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetPoodleById(int id)
        {

            Poodle poodle = _poodlesRepository.GetById(id);


            if (poodle == null)
            {
                return NotFound();
            }
            PoodleDTO poodleDTO = _mapper.Map<PoodleDTO>(poodle);

            return Ok(poodleDTO);
        }

        [HttpPost]

        public IActionResult AddNewPoodle(Poodle poodle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _poodlesRepository.Add(poodle);

            return CreatedAtAction("GetPoodleById", new { id = poodle.Id }, poodle);

        }

        [HttpDelete("{id}")]

        public IActionResult DeletePoodle(int id )
        {
            var poodle = _poodlesRepository.GetById(id);

            if (poodle == null)
            {
                return NotFound();
            }

            _poodlesRepository.Delete(poodle);
            return NoContent();
        }

        [HttpPut("{id}")]

        public IActionResult UpdatePoodle(int id, Poodle poodle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (id != poodle.Id)
            {
                return NoContent();
            }

            try
            {
                _poodlesRepository.Update(poodle);
            }

            catch
            {
                return BadRequest();
            }

            return Ok(poodle);
        }


    }
}
