using CineTixx.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.Ports.Driving
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
        Task<BookingDto> GetBookingAsync(Guid id);
        Task AddBookingAsync(BookingDto bookingDto);
        Task DeleteBookingAsync(Guid id);
    }
}
