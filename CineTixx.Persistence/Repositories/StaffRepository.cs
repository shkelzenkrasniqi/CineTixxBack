using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineTixx.Persistence.Repositories
{
    internal sealed class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;

        public StaffRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Staff>> GetAllAsync()
        {
            return await _context.Staff
                .Include(s => s.Position) // Include navigation property for Position
                .ToListAsync();
        }

        public async Task<Staff> GetByIdAsync(Guid id)
        {
            return await _context.Staff
                .Include(s => s.Position) // Include navigation property for Position
                .FirstOrDefaultAsync(s => s.UniqueId == id);
        }

        public async Task AddAsync(Staff staff)
        {
            await _context.Staff.AddAsync(staff);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Staff staff)
        {
            _context.Staff.Update(staff);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var staff = await GetByIdAsync(id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
                await _context.SaveChangesAsync();
            }
        }
    }
}
