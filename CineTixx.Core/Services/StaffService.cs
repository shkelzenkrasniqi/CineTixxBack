using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Core.Ports.Driving;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineTixx.Core.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IMapper _mapper;

        public StaffService(IStaffRepository staffRepository, IMapper mapper)
        {
            _staffRepository = staffRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StaffDto>> GetAllStaffAsync()
        {
            var staff = await _staffRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StaffDto>>(staff);
        }

        public async Task<StaffDto> GetStaffAsync(Guid id)
        {
            var staff = await _staffRepository.GetByIdAsync(id);
            return _mapper.Map<StaffDto>(staff);
        }

        public async Task AddStaffAsync(StaffDto staffDto)
        {
            var staff = _mapper.Map<Staff>(staffDto);
            await _staffRepository.AddAsync(staff);
        }

        public async Task UpdateStaffAsync(StaffDto staffDto)
        {
            var staff = _mapper.Map<Staff>(staffDto);
            await _staffRepository.UpdateAsync(staff);
        }

        public async Task DeleteStaffAsync(Guid id)
        {
            await _staffRepository.DeleteAsync(id);
        }
    }
}
