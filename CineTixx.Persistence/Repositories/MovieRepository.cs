using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Persistence.Database;
using Microsoft.EntityFrameworkCore;
namespace CineTixx.Persistence.Repositories
{
    internal sealed class MovieRepository(ApplicationDbContext _context) : IMovieRepository
    {
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies
                .Include(c => c.Photos)
                .ToListAsync();
        }
        public async Task<Movie> GetByIdAsync(Guid id)
        {
            return await _context.Movies
                .Include(c => c.Photos)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var movie = await GetByIdAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
