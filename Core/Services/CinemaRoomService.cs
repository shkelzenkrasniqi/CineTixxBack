using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Core.Ports.Driving;

namespace CineTixx.Core.Services
{
    public class CinemaRoomService : ICinemaRoomService
    {
        private readonly ICinemaRoomRepository _cinemaRoomRepository;
        private readonly IMapper _mapper;

        public CinemaRoomService(ICinemaRoomRepository cinemaRoomRepository, IMapper mapper)
        {
            _cinemaRoomRepository = cinemaRoomRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CinemaRoomDto>> GetAllCinemaRoomsAsync()
        {
            var cinemaRooms = await _cinemaRoomRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CinemaRoomDto>>(cinemaRooms);
        }
        public async Task<CinemaRoomDto> GetCinemaRoomAsync(Guid id)
        {
            var cinemaRoom = await _cinemaRoomRepository.GetByIdAsync(id);
            return _mapper.Map<CinemaRoomDto>(cinemaRoom);
        }

        public async Task AddCinemaRoomAsync(CinemaRoomDto cinemaRoomDto)
        {
            var cinemaRoom = _mapper.Map<CinemaRoom>(cinemaRoomDto);
            await _cinemaRoomRepository.AddAsync(cinemaRoom);
        }

        public async Task UpdateCinemaRoomAsync(CinemaRoomDto cinemaRoomDto)
        {
            var cinemaRoom = _mapper.Map<CinemaRoom>(cinemaRoomDto);
            await _cinemaRoomRepository.UpdateAsync(cinemaRoom);
        }

        public async Task DeleteCinemaRoomAsync(Guid id)
        {
            await _cinemaRoomRepository.DeleteAsync(id);
        }
    }
}
