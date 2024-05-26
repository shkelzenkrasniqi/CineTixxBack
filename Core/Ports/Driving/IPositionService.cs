
using CineTixx.Core.DTOs;

namespace CineTixx.Core.Ports.Driving
{
    public interface IPositionService
    {
        Task<IEnumerable<PositionDto>> GetAllPositionsAsync();
        Task<PositionDto> GetPositionAsync(Guid id);
        Task AddPositionAsync(PositionDto positionDto);
        Task UpdatePositionAsync(PositionDto positionDto);
        Task DeletePositionAsync(Guid id);
    }
}
