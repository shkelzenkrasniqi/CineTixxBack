using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Ports.Driving;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CineTixx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComingSoonController : ControllerBase
    {
        private readonly IComingSoonService _comingSoonService;
        private readonly IMapper _mapper;

        public ComingSoonController(IComingSoonService comingSoonService, IMapper mapper)
        {
            _comingSoonService = comingSoonService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComingSoonDto>>> GetAllComingSoon()
        {
            var comingSoonDtos = await _comingSoonService.GetAllComingSoonAsync();
            return Ok(comingSoonDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComingSoonDto>> GetComingSoon(Guid id)
        {
            var comingSoonDto = await _comingSoonService.GetComingSoonAsync(id);
            if (comingSoonDto == null)
            {
                return NotFound();
            }
            return Ok(comingSoonDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddComingSoon([FromForm] ComingSoonDto comingSoonDto, IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                // Define the path to save the uploaded photo
                var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                Directory.CreateDirectory(uploadsDirectory); // Ensure the directory exists

                var filePath = Path.Combine(uploadsDirectory, photo.FileName);

                // Save the file to the server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }

                // Set the PhotoUrl property
                comingSoonDto.PhotoUrl = $"/images/{photo.FileName}";
            }

            await _comingSoonService.AddComingSoonAsync(comingSoonDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComingSoon(Guid id, ComingSoonDto comingSoonDto)
        {
            if (id != comingSoonDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _comingSoonService.UpdateComingSoonAsync(comingSoonDto);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComingSoon(Guid id)
        {
            await _comingSoonService.DeleteComingSoonAsync(id);
            return NoContent();
        }
    }
}
