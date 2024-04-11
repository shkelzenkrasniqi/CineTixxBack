using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace CineTixx.Persistence.Repositories
{
    internal sealed class CinemaRoomRepository(ApplicationDbContext _context) : ICinemaRoomRepository
    {
        public async Task<IEnumerable<CinemaRoom>> GetAllAsync()
        {
            return await _context.CinemaRooms.ToListAsync();
        }
        public async Task<CinemaRoom> GetByIdAsync(Guid id)
        {
            return await _context.CinemaRooms.FindAsync(id);
        }

        public async Task AddAsync(CinemaRoom cinemaRoom)
        {
            await _context.CinemaRooms.AddAsync(cinemaRoom);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CinemaRoom cinemaRoom)
        {
            _context.CinemaRooms.Update(cinemaRoom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var cinemaRoom = await GetByIdAsync(id);
            if (cinemaRoom != null)
            {
                _context.CinemaRooms.Remove(cinemaRoom);
                await _context.SaveChangesAsync();
            }
        }
    }
}
