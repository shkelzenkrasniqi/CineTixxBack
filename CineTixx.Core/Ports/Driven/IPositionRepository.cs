using CineTixx.Core.Entities;

namespace CineTixx.Core.Ports.Driven
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAllAsync();
        Task<Position> GetByIdAsync(Guid id);
        Task AddAsync(Position position);
        Task UpdateAsync(Position position);
        Task DeleteAsync(Guid id);
    }
}
