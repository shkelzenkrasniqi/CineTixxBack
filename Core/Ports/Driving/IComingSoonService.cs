using CineTixx.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineTixx.Core.Ports.Driving
{
    public interface IComingSoonService
    {
        Task<IEnumerable<ComingSoonDto>> GetAllComingSoonAsync();
        Task<ComingSoonDto> GetComingSoonAsync(Guid id);
        Task AddComingSoonAsync(ComingSoonDto comingSoonDto);
        Task UpdateComingSoonAsync(ComingSoonDto comingSoonDto);
        Task DeleteComingSoonAsync(Guid id);
    }
}