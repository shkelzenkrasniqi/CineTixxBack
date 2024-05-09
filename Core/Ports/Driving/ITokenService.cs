using CineTixx.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.Ports.Driving
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);

    }
}
