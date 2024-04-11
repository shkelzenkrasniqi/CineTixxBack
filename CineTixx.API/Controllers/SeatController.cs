using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Ports.Driving;
using Microsoft.AspNetCore.Mvc;

namespace CineTixx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController(ISeatService _seatService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatDto>>> GetAllSeats()
        {
            var seatDtos = await _seatService.GetAllSeatsAsync();
            return Ok(seatDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeatDto>> GetSeat(Guid id)
        {
            var seatDto = await _seatService.GetSeatAsync(id);
            if (seatDto == null)
            {
                return NotFound();
            }
            return seatDto;
        }

        [HttpPost]
        public async Task<IActionResult> AddSeat(SeatDto seatDto)
        {
            await _seatService.AddSeatAsync(seatDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeat(Guid id, SeatDto seatDto)
        {
            if (id != seatDto.Id)
            {
                return BadRequest();
            }
            await _seatService.UpdateSeatAsync(seatDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(Guid id)
        {
            await _seatService.DeleteSeatAsync(id);
            return NoContent();
        }
    }
}
