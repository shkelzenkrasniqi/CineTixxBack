using CineTixx.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.Ports.Driving
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAllEventAsync();
        Task<EventDto> GetEventAsync(Guid id);
        Task AddEventAsync(EventDto eventDto);
        Task UpdateEventAsync(EventDto eventDto);
        Task DeleteEventAsync(Guid id);
    }
}
