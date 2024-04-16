using CineTixx.Core.Entities;

namespace CineTixx.Core.Ports.Driven
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>>GetAllAsync();
        Task<Booking> GetByIdAsync(int BookingId);
        Task AddAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task DeleteAsync(int BookingId);
    }
}
