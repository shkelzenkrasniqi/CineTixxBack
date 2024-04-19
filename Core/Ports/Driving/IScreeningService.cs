using CineTixx.Core.DTOs;

namespace CineTixx.Core.Ports.Driving
{
    public interface IScreeningService
    {
        Task<IEnumerable<ScreeningDto>> GetAllScreeningsAsync();
        Task<ScreeningDto> GetScreeningAsync(Guid id);
        Task AddScreeningAsync(ScreeningDto screeningDto);
        Task UpdateScreeningAsync(ScreeningDto screeningDto);
        Task DeleteScreeningAsync(Guid id);
        Task<IEnumerable<CinemaRoomDto>> GetAllCinemaRoomsAsync(); 
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
    }
}
