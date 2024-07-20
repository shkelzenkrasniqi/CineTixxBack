using CineTixx.Core.DTOs;

namespace CineTixx.Core.Ports.Driving
{
    public interface ICinemaRoomService
    {
        Task<IEnumerable<CinemaRoomDto>> GetAllCinemaRoomsAsync();
        Task<CinemaRoomDto> GetCinemaRoomAsync(Guid id);
        Task AddCinemaRoomAsync(CinemaRoomDto cinemaRoomDto);
        Task UpdateCinemaRoomAsync(CinemaRoomDto cinemaRoomDto);
        Task DeleteCinemaRoomAsync(Guid id);
    }
}
