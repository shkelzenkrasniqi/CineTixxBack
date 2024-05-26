
using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Core.Ports.Driving;

namespace CineTixx.Core.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PositionDto>> GetAllPositionsAsync()
        {
            var positions = await _positionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PositionDto>>(positions);
        }

        public async Task<PositionDto> GetPositionAsync(Guid id)
        {
            var position = await _positionRepository.GetByIdAsync(id);
            return _mapper.Map<PositionDto>(position);
        }

        public async Task AddPositionAsync(PositionDto positionDto)
        {
            var position = _mapper.Map<Position>(positionDto);
            await _positionRepository.AddAsync(position);
        }

        public async Task UpdatePositionAsync(PositionDto positionDto)
        {
            var position = _mapper.Map<Position>(positionDto);
            await _positionRepository.UpdateAsync(position);
        }

        public async Task DeletePositionAsync(Guid id)
        {
            await _positionRepository.DeleteAsync(id);
        }
    }
}
