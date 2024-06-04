
using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Ports.Driving;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> AddComingSoon(ComingSoonDto comingSoonDto)
        {
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