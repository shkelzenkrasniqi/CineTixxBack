using CineTixx.Core.DTOs.Account;
using CineTixx.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.Ports.Driving
{
    public interface IAccountService
    {
        Task<UserDto> Login(LoginDto loginDto);
        Task<UserDto> Register(RegisterDto registerDto);
        Task<UserDto> RegisterAdmin(RegisterDto registerDto);
        Task Logout(LogoutDto logoutDto);
        Task<UserDto> RefreshToken(RefreshTokenDto refreshTokenDto);
    }
}
