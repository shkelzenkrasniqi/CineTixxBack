using System;
using System.Threading.Tasks;
using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Ports.Driving;
using Microsoft.AspNetCore.Mvc;

namespace CineTixx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaRoomController(ICinemaRoomService _cinemaRoomService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinemaRoomDto>>> GetAllCinemaRooms()
        {
            var cinemaRoomDtos = await _cinemaRoomService.GetAllCinemaRoomsAsync();
            return Ok(cinemaRoomDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CinemaRoomDto>> GetCinemaRoom(Guid id)
        {
            var cinemaRoomDto = await _cinemaRoomService.GetCinemaRoomAsync(id);
            if (cinemaRoomDto == null)
            {
                return NotFound();
            }
            return cinemaRoomDto;
        }

        [HttpPost]
        public async Task<IActionResult> AddCinemaRoom(CinemaRoomDto cinemaRoomDto)
        {
            await _cinemaRoomService.AddCinemaRoomAsync(cinemaRoomDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCinemaRoom(Guid id, CinemaRoomDto cinemaRoomDto)
        {
            if (id != cinemaRoomDto.Id)
            {
                return BadRequest();
            }
            await _cinemaRoomService.UpdateCinemaRoomAsync(cinemaRoomDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCinemaRoom(Guid id)
        {
            await _cinemaRoomService.DeleteCinemaRoomAsync(id);
            return NoContent();
        }
    }
}
