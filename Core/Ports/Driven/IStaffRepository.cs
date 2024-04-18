using CineTixx.Core.Entities;


namespace CineTixx.Core.Ports.Driven
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetAllAsync();
        Task<Staff> GetByIdAsync(Guid id);
        Task AddAsync(Staff staff);
        Task UpdateAsync(Staff staff);
        Task DeleteAsync(Guid id);
    }
}
