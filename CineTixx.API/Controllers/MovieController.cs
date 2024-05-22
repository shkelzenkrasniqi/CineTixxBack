using System;
using System.Threading.Tasks;
using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Ports.Driving;
using CineTixx.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineTixx.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController(IMovieService _movieService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAllMovies()
        {
            var movieDtos = await _movieService.GetAllMoviesAsync();
            return Ok(movieDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(Guid id)
        {
            var movieDto = await _movieService.GetMovieAsync(id);
            if (movieDto == null)
            {
                return NotFound();
            }
            return movieDto;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieDto MovieDto)
        {
            await _movieService.AddMovieAsync(MovieDto);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(Guid id, MovieDto movieDto)
        {
            if (id != movieDto.Id)
            {
                return BadRequest();
            }
            await _movieService.UpdateMovieAsync(movieDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            await _movieService.DeleteMovieAsync(id);
            return NoContent();
        }

    }
}
