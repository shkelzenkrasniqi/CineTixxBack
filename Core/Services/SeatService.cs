using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Core.Ports.Driving;

namespace CineTixx.Core.Services
{
    public class SeatService(ISeatRepository _seatRepository, IMapper _mapper) : ISeatService
    {
        public async Task<IEnumerable<SeatDto>> GetAllSeatsAsync()
        {
            var seats = await _seatRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SeatDto>>(seats);
        }

        public async Task<SeatDto> GetSeatAsync(Guid id)
        {
            var seat = await _seatRepository.GetByIdAsync(id);
            return _mapper.Map<SeatDto>(seat);
        }

        public async Task AddSeatAsync(SeatDto seatDto)
        {
            var seat = _mapper.Map<Seat>(seatDto);
            await _seatRepository.AddAsync(seat);
        }

        public async Task UpdateSeatAsync(SeatDto seatDto)
        {
            var seat = _mapper.Map<Seat>(seatDto);
            await _seatRepository.UpdateAsync(seat);
        }

        public async Task DeleteSeatAsync(Guid id)
        {
            await _seatRepository.DeleteAsync(id);
        }
    }
}
