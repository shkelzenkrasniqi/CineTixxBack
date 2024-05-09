using CineTixx.Core.DTOs.Account;
using CineTixx.Core.Ports.Driving;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AccountController(IAccountService _accountService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _accountService.Login(loginDto);
            if (user != null)
                return Ok(user);

            return BadRequest("Invalid email or password");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                var user = await _accountService.Register(registerDto);
                return CreatedAtAction(nameof(Login), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
