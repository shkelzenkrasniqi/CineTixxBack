using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace CineTixx.Persistence.Repositories
{
    internal sealed class ScreeningRepository(ApplicationDbContext _context) : IScreeningRepository
    {
        public async Task<IEnumerable<Screening>> GetAllAsync()
        {
            return await _context.Screenings.ToListAsync();
        }
        public async Task<Screening> GetByIdAsync(Guid id)
        {
            return await _context.Screenings.FindAsync(id);
        }
        public async Task AddAsync(Screening screening)
        {
            await _context.Screenings.AddAsync(screening);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Screening screening)
        {
            _context.Screenings.Update(screening);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var screening = await GetByIdAsync(id);
            if (screening != null)
            {
                _context.Screenings.Remove(screening);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Screening>> GetScreeningsByMovieIdAsync(Guid movieId)
        {
            return await _context.Screenings
                .Where(s => s.MovieId == movieId)
                .Include(s => s.CinemaRoom) 
                .ToListAsync();
        }
    }
}
