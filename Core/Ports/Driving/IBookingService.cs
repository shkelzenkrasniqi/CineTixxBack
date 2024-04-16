using CineTixx.Core.DTOs;

namespace CineTixx.Core.Ports.Driving
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
        Task<BookingDto> GetBookingAsync(int BookingId);
        Task AddBookingAsync(BookingDto bookingdto);
        Task UpdateBookingAsync(BookingDto bookingdto);
        Task DeleteBookingAsync(int BookingId);
    }
}
