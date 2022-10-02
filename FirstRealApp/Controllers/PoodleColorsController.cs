using AutoMapper;
using FirstRealApp.Models.PoodleEntity;
using FirstRealApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstRealApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PoodleColorsController : ControllerBase
    {
        private readonly IPoodleColorsRepository _poodleColorsRepository;

        public PoodleColorsController(IPoodleColorsRepository poodleColorsRepository)
        {
            _poodleColorsRepository = poodleColorsRepository;
          
        }

        [HttpGet("{id}")]

        public IActionResult GetColorById(int id )
        {
            var color = _poodleColorsRepository.GetById(id);

            if (color == null)
            {
                return NotFound();
            }
            return Ok(color);
        }
        
        [AllowAnonymous]
        [HttpGet]
        [Route("/api/poodles/list-colors")]
        public IActionResult GetAllColors()
        {
            return Ok(_poodleColorsRepository.GetAllColors());
        }

        [HttpPost]

        public IActionResult AddColor(PoodleColor color)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _poodleColorsRepository.AddColor(color);

            return CreatedAtAction("GetColorById", new {id = color.Id});

        }




    }
}
