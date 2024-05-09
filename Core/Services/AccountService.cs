using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.DTOs.Account;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driving;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.Services
{
    internal sealed class AccountService(UserManager<AppUser> _userManager, IMapper _mapper, ITokenService _tokenService) : IAccountService
    {
        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user is null) return null;

            var passwordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (passwordValid)
            {
                var userDto = _mapper.Map<UserDto>(user);
                userDto.Token = await _tokenService.CreateToken(user);
                return userDto;
            }
            else
            {
                // Password does not match, return a UserDto with null token
                var userDto = _mapper.Map<UserDto>(user);
                userDto.Token = null;
                return userDto;
            }
        }
        public async Task<UserDto> Register(RegisterDto registerDto)
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
                var userDto = _mapper.Map<UserDto>(user);
                userDto.Token = await _tokenService.CreateToken(user);
                return userDto;
            }

            throw new Exception("Failed to register the user");
        }

    }
}