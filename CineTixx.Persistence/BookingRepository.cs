using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace CineTixx.Persistence
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }
        public async Task<Booking> GetByIdAsync(int BookingId)
        {
            return await _context.Bookings.FindAsync(BookingId);
        }

        public async Task AddAsync(Booking bookings)
        {
            await _context.Bookings.AddAsync(bookings);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Booking bookings)
        {
            _context.Bookings.Update(bookings);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int BookingId)
        {
            var booking = await GetByIdAsync(BookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
