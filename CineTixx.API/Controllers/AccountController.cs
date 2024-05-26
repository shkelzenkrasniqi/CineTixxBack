using CineTixx.Core.DTOs.Account;
using CineTixx.Core.Ports.Driving;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        [Authorize(Roles = "Admin")]
        [HttpPost("registerAdmin")]
        public async Task<IActionResult> RegisterAdmin(RegisterDto registerDto)
        {
            try
            {
                var user = await _accountService.RegisterAdmin(registerDto);
                return CreatedAtAction(nameof(Login), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutDto logoutDto)
        {
            await _accountService.Logout(logoutDto);
            return Ok();
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            try
            {
                var user = await _accountService.RefreshToken(refreshTokenDto);
                return Ok(user);
            }
            catch (SecurityTokenException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
