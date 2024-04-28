using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Ports.Driving;
using CineTixx.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CineTixx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class StaffController(IStaffService _staffService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffDto>>> GetAllStaff()
        {
            var staffDtos = await _staffService.GetAllStaffAsync();
            return Ok(staffDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StaffDto>> GetStaff(Guid id)
        {
            var staffDto = await _staffService.GetStaffAsync(id);
            if (staffDto == null)
            {
                return NotFound();
            }
            return staffDto;
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(StaffDto staffDto)
        {
            await _staffService.AddStaffAsync(staffDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaff(Guid id, StaffDto staffDto)
        {
            if (id != staffDto.UniqueId)
            {
                return BadRequest();
            }

            try
            {
                await _staffService.UpdateStaffAsync(staffDto);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(Guid id)
        {
            await _staffService.DeleteStaffAsync(id);
            return NoContent();
        }
    }
}
