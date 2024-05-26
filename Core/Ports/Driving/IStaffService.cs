using CineTixx.Core.DTOs;


namespace CineTixx.Core.Ports.Driving
{
    public interface IStaffService
    {
        Task<IEnumerable<StaffDto>> GetAllStaffAsync();
        Task<StaffDto> GetStaffAsync(Guid id);
        Task AddStaffAsync(StaffDto staffDto);
        Task UpdateStaffAsync(StaffDto staffDto);
        Task DeleteStaffAsync(Guid id);
    }
}
