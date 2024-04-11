using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace CineTixx.Persistence.Repositories
{
    internal sealed class SeatRepository(ApplicationDbContext _context) : ISeatRepository
    {
        public async Task<IEnumerable<Seat>> GetAllAsync()
        {
            return await _context.Seats.ToListAsync();
        }

        public async Task<Seat> GetByIdAsync(Guid id)
        {
            return await _context.Seats.FindAsync(id);
        }

        public async Task AddAsync(Seat seat)
        {
            await _context.Seats.AddAsync(seat);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seat seat)
        {
            _context.Seats.Update(seat);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var seat = await GetByIdAsync(id);
            if (seat != null)
            {
                _context.Seats.Remove(seat);
                await _context.SaveChangesAsync();
            }
        }
    }
}
