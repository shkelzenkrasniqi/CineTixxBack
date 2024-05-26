using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Core.Ports.Driving;

namespace CineTixx.Core.Services
{
    public class ScreeningService(IScreeningRepository _screeningRepository, ICinemaRoomRepository _cinemaRoomRepository, IMovieRepository _movieRepository, IMapper _mapper, IBookingRepository _bookingRepository) : IScreeningService
    {
        public async Task<IEnumerable<ScreeningDto>> GetAllScreeningsAsync()
        {
            var screenings = await _screeningRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ScreeningDto>>(screenings);
        }
        
        public async Task<ScreeningDto> GetScreeningAsync(Guid id)
        {
            var screening = await _screeningRepository.GetByIdAsync(id);
            return _mapper.Map<ScreeningDto>(screening);
        }
        public async Task AddScreeningAsync(ScreeningDto screeningDto)
        {
            var screening = _mapper.Map<Screening>(screeningDto);
            await _screeningRepository.AddAsync(screening);
        }
        public async Task UpdateScreeningAsync(ScreeningDto screeningDto)
        {
            var screening = _mapper.Map<Screening>(screeningDto);
            await _screeningRepository.UpdateAsync(screening);
        }
        public async Task DeleteScreeningAsync(Guid id)
        {
            await _screeningRepository.DeleteAsync(id);
        }
        public async Task<IEnumerable<CinemaRoomDto>> GetAllCinemaRoomsAsync()
        {
            var cinemaRooms = await _cinemaRoomRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CinemaRoomDto>>(cinemaRooms);
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }
    }
}
