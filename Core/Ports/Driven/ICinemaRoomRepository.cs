using CineTixx.Core.Entities;

namespace CineTixx.Core.Ports.Driven
{
    public interface ICinemaRoomRepository
    {
        Task<IEnumerable<CinemaRoom>> GetAllAsync();
        Task<CinemaRoom> GetByIdAsync(Guid id);
        Task AddAsync(CinemaRoom cinemaRoom);
        Task UpdateAsync(CinemaRoom cinemaRoom);
        Task DeleteAsync(Guid id);
    }
}
