using System;
using System.Threading.Tasks;
using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Ports.Driving;
using CineTixx.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CineTixx.API.Controllers
{
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
        [HttpPost]
        public async Task<ActionResult<MovieDto>> AddMovie([FromForm] MovieDto movieDto, [FromForm] List<IFormFile> photos)
        {
            try
            {
                var createdMovie = await _movieService.AddMovieAsync(movieDto, photos);
                return CreatedAtAction(nameof(GetMovie), new { id = createdMovie.Id }, createdMovie);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
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
