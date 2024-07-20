using CineTixx.Core.Entities;

namespace CineTixx.Core.Ports.Driven
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetAllAsync();
        Task<Seat> GetByIdAsync(Guid id);
        Task AddAsync(Seat seat);
        Task UpdateAsync(Seat seat);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Seat>> GetSeatsForCinemaRoomAsync(Guid cinemaRoomId);
    }
}
