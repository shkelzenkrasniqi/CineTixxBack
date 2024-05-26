using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Ports.Driving;
using Microsoft.AspNetCore.Mvc;

namespace CineTixx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    /* public class PositionController : ControllerBase
     {
         private readonly IPositionService _positionService;
         private readonly IMapper _mapper; */

    public class PositionController(IPositionService _positionService, IMapper _mapper) : ControllerBase
    {



        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionDto>>> GetAllPositions()
        {
            var positionDtos = await _positionService.GetAllPositionsAsync();
            return Ok(positionDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PositionDto>> GetPosition(Guid id)
        {
            var positionDto = await _positionService.GetPositionAsync(id);
            if (positionDto == null)
            {
                return NotFound();
            }
            return positionDto;
        }

        [HttpPost]
        public async Task<IActionResult> AddPosition(PositionDto positionDto)
        {
            await _positionService.AddPositionAsync(positionDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePosition(Guid id, PositionDto positionDto)
        {
            if (id != positionDto.Id)
            {
                return BadRequest();
            }
            await _positionService.UpdatePositionAsync(positionDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(Guid id)
        {
            await _positionService.DeletePositionAsync(id);
            return NoContent();
        }
    }
}