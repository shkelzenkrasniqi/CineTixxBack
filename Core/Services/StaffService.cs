using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Core.Ports.Driving;

namespace CineTixx.Core.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IMapper _mapper;

        public StaffService(IStaffRepository staffRepository, IMapper mapper)
        {
            _staffRepository = staffRepository ?? throw new ArgumentNullException(nameof(staffRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<StaffDto>> GetAllStaffMembersAsync()
        {
            var staffMembers = await _staffRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StaffDto>>(staffMembers);
        }

        public async Task<StaffDto> GetStaffMemberAsync(Guid id)
        {
            var staffMember = await _staffRepository.GetByIdAsync(id);
            return _mapper.Map<StaffDto>(staffMember);
        }

        public async Task AddStaffMemberAsync(StaffDto staffDto)
        {
            var staffMember = _mapper.Map<Staff>(staffDto);
            await _staffRepository.AddAsync(staffMember);
        }

        public async Task UpdateStaffMemberAsync(StaffDto staffDto)
        {
            var staffMember = _mapper.Map<Staff>(staffDto);
            await _staffRepository.UpdateAsync(staffMember);
        }

        public async Task DeleteStaffMemberAsync(Guid id)
        {
            await _staffRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<StaffDto>> GetAllStaffAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StaffDto> GetStaffAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task AddStaffAsync(StaffDto staffDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStaffAsync(StaffDto staffDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStaffAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
