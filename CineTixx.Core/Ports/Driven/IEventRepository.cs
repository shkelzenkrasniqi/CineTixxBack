using CineTixx.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.Ports.Driven
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllAsync();
        Task<Event> GetByIdAsync(Guid id);
        Task AddAsync(Event events);
        Task UpdateAsync(Event events);
        Task DeleteAsync(Guid id);
    }
}
