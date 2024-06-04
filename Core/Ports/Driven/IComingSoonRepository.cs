using CineTixx.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineTixx.Core.Ports.Driven
{
    public interface IComingSoonRepository
    {
        Task<IEnumerable<ComingSoon>> GetAllAsync();
        Task<ComingSoon> GetByIdAsync(Guid id);
        Task AddAsync(ComingSoon comingSoon);
        Task UpdateAsync(ComingSoon comingSoon);
        Task DeleteAsync(Guid id);
    }
}