using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Ports.Driving;
using CineTixx.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CineTixx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreeningController(IScreeningService _screeningService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScreeningDto>>> GetAllScreningss()
        {
            var screeningDtos = await _screeningService.GetAllScreeningsAsync();
            return Ok(screeningDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScreeningDto>> GetScreening(Guid id)
        {
            var screeningDto = await _screeningService.GetScreeningAsync(id);
            if (screeningDto == null)
            {
                return NotFound();
            }
            return screeningDto;
        }

        [HttpPost]
        public async Task<IActionResult> AddScreening(ScreeningDto screeningDto)
        {
            await _screeningService.AddScreeningAsync(screeningDto);
            return Ok();
        }
        [HttpGet("cinema-rooms")]
        public async Task<ActionResult<IEnumerable<CinemaRoomDto>>> GetAllCinemaRooms()
        {
            var cinemaRoomDtos = await _screeningService.GetAllCinemaRoomsAsync();
            return Ok(cinemaRoomDtos);
        }

        [HttpGet("movies")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAllMovies()
        {
            var movieDtos = await _screeningService.GetAllMoviesAsync();
            return Ok(movieDtos);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditScreening(Guid id, ScreeningDto screeningDto)
        {
            if (id != screeningDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _screeningService.UpdateScreeningAsync(screeningDto);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreening(Guid id)
        {
            var existingScreening = await _screeningService.GetScreeningAsync(id);
            if (existingScreening == null)
            {
                return NotFound();
            }

            await _screeningService.DeleteScreeningAsync(id);

            return NoContent();
        }
        [HttpGet("movie/{movieId}")]
        public async Task<ActionResult<IEnumerable<ScreeningDto>>> GetScreeningsByMovieId(Guid movieId)
        {
            var screenings = await _screeningService.GetScreeningsByMovieIdAsync(movieId);
            return Ok(screenings);
        }
    }
}
