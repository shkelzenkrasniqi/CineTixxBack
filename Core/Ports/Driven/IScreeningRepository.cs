using CineTixx.Core.Entities;

namespace CineTixx.Core.Ports.Driven
{
    public interface IScreeningRepository
    {
        Task<IEnumerable<Screening>> GetAllAsync();
        Task<Screening> GetByIdAsync(Guid id);
        Task AddAsync(Screening screening);
        Task UpdateAsync(Screening screening);
        Task DeleteAsync(Guid id);
    }
}
