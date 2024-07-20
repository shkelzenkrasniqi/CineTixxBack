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
    public class ComingSoonService : IComingSoonService
    {
        private readonly IComingSoonRepository _comingSoonRepository;
        private readonly IMapper _mapper;

        public ComingSoonService(IComingSoonRepository comingSoonRepository, IMapper mapper)
        {
            _comingSoonRepository = comingSoonRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ComingSoonDto>> GetAllComingSoonAsync()
        {
            var comingSoonList = await _comingSoonRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ComingSoonDto>>(comingSoonList);
        }

        public async Task<ComingSoonDto> GetComingSoonAsync(Guid id)
        {
            var comingSoon = await _comingSoonRepository.GetByIdAsync(id);
            return _mapper.Map<ComingSoonDto>(comingSoon);
        }

        public async Task AddComingSoonAsync(ComingSoonDto comingSoonDto)
        {
            var comingSoon = _mapper.Map<ComingSoon>(comingSoonDto);
            await _comingSoonRepository.AddAsync(comingSoon);
        }

        public async Task UpdateComingSoonAsync(ComingSoonDto comingSoonDto)
        {
            var comingSoon = _mapper.Map<ComingSoon>(comingSoonDto);
            await _comingSoonRepository.UpdateAsync(comingSoon);
        }

        public async Task DeleteComingSoonAsync(Guid id)
        {
            await _comingSoonRepository.DeleteAsync(id);
        }
    }
}