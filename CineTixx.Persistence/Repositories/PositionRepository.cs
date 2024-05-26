
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace CineTixx.Persistence.Repositories
{
    internal sealed class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDbContext _context;

        public PositionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Position> GetByIdAsync(Guid id)
        {
            return await _context.Positions.FindAsync(id);
        }

        public async Task AddAsync(Position position)
        {
            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Position position)
        {
            _context.Positions.Update(position);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var position = await GetByIdAsync(id);
            if (position != null)
            {
                _context.Positions.Remove(position);
                await _context.SaveChangesAsync();
            }
        }
    }
}
