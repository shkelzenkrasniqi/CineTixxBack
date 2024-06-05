using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Ports.Driving;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CineTixx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(IEventService comingSoonService, IMapper mapper)
        {
            _eventService = comingSoonService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAllEvent()
        {
            var eventDtos = await _eventService.GetAllEventAsync();
            return Ok(eventDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent(Guid id)
        {
            var eventDto = await _eventService.GetEventAsync(id);
            if (eventDto == null)
            {
                return NotFound();
            }
            return Ok(eventDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromForm] EventDto eventDto, IFormFile photo)
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
                eventDto.PhotoUrl = $"/images/{photo.FileName}";
            }

            await _eventService.AddEventAsync(eventDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(Guid id, EventDto eventDto)
        {
            if (id != eventDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _eventService.UpdateEventAsync(eventDto);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            await _eventService.DeleteEventAsync(id);
            return NoContent();
        }
    }
}
