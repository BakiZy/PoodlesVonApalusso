using FirstRealApp.Models;
using FirstRealApp.Repository;
using FirstRealApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstRealApp.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImagesRepository _imagesRepository;
        public ImagesController(IImagesRepository imagesRepository)
        {
            _imagesRepository = imagesRepository;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetImages()
        {
            return Ok(_imagesRepository.GetImages());
        }
        [HttpGet("{id}")]
        public IActionResult GetImage(int id)
        {
            var image = _imagesRepository.GetImage(id);
            if (image == null)
            {
                return BadRequest();
            }
            return Ok(image);
        }
        
        [HttpPost]
        public IActionResult AddImage([FromBody] Image image)
        {
            _imagesRepository.AddImage(image);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteImage(int id)
        {
            var image = _imagesRepository.GetImage(id);
            if (image == null)
            {
                return NotFound("image not found");
            }
            _imagesRepository.DeleteImage(image);
            
            return NoContent();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateImage(Image img, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (id != img.Id)
            {
                return BadRequest();
            }
            try
            {
                _imagesRepository.UpdateImage(img);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (_imagesRepository.GetImage(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(img);

        }
    }
}
