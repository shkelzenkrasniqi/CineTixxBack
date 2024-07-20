using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.DTOs.Account;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driving;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.Services
{
    internal sealed class AccountService(UserManager<AppUser> _userManager, IMapper _mapper, ITokenService _tokenService, IRoleService _roleService) : IAccountService
    {
        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return null;
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (passwordValid)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userDto = _mapper.Map<UserDto>(user);
                userDto.Token = await _tokenService.CreateToken(user);
                userDto.RefreshToken = await _tokenService.CreateRefreshToken(user);
                return userDto;

            }

            return null;
        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            // Check if the user already exists
            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            // Validate password
            if (!IsValidPassword(registerDto.Password))
            {
                throw new Exception("Password must contain at least one uppercase letter, one number, and one symbol");
            }

            var user = new AppUser
            {
                UserName = registerDto.UserName,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                var usersCount = _userManager.Users.Count();
                if (usersCount == 1)
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.Admin.ToString());
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.User.ToString());
                }

                var userDto = _mapper.Map<UserDto>(user);
                userDto.Token = await _tokenService.CreateToken(user);
                userDto.RefreshToken = await _tokenService.CreateRefreshToken(user);
                return userDto;
            }

            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"Failed to register the user: {errors}");
        }

        // Helper method to validate password
        private bool IsValidPassword(string password)
        {
            var hasUpperCase = password.Any(char.IsUpper);
            var hasLowerCase = password.Any(char.IsLower);
            var hasDigits = password.Any(char.IsDigit);
            var hasSymbols = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasUpperCase && hasLowerCase && hasDigits && hasSymbols;
        }



        public async Task<UserDto> RegisterAdmin(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                UserName = registerDto.UserName,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin.ToString());
                var userDto = _mapper.Map<UserDto>(user);
                userDto.Token = await _tokenService.CreateToken(user);
                userDto.RefreshToken = await _tokenService.CreateRefreshToken(user);
                return userDto;
            }

            throw new Exception("Failed to register the user");
        }

        public async Task Logout(LogoutDto logoutDto)
        {
            _tokenService.RevokeToken(logoutDto.Token);
        }

        public async Task<UserDto> RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(refreshTokenDto.Token);
            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null || _tokenService.IsTokenRevoked(refreshTokenDto.Token))
            {
                throw new SecurityTokenException("Invalid token");
            }

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = await _tokenService.CreateToken(user);
            userDto.RefreshToken = await _tokenService.CreateRefreshToken(user);

            return userDto;
        }
    }
}