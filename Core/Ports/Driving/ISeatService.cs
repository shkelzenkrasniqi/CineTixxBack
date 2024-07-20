using CineTixx.Core.DTOs;

namespace CineTixx.Core.Ports.Driving
{
    public interface ISeatService
    {
        Task<IEnumerable<SeatDto>> GetAllSeatsAsync();
        Task<SeatDto> GetSeatAsync(Guid id);
        Task AddSeatAsync(SeatDto seatDto);
        Task UpdateSeatAsync(SeatDto seatDto);
        Task DeleteSeatAsync(Guid id);
    }
}
