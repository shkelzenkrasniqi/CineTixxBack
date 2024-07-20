using CineTixx.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.Ports.Driving
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
        Task<string> CreateRefreshToken(AppUser user);
        void RevokeToken(string token);
        bool IsTokenRevoked(string token);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
