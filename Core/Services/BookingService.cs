using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Core.Ports.Driving;

namespace CineTixx.Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }
        public async Task<BookingDto> GetBookingAsync(int BookingId)
        {
            var bookings = await _bookingRepository.GetByIdAsync(BookingId);
            return _mapper.Map<BookingDto>(bookings);
        }

        public async Task AddBookingAsync(BookingDto bookingdto)
        {
            var bookings = _mapper.Map<Booking>(bookingdto);
            await _bookingRepository.AddAsync(bookings);
        }

        public async Task UpdateBookingAsync(BookingDto bookingdto)
        {
            var bookings = _mapper.Map<Booking>(bookingdto);
            await _bookingRepository.UpdateAsync(bookings);
        }

        public async Task DeleteBookingAsync(int BookingId)
        {
            await _bookingRepository.DeleteAsync(BookingId);
        }
    }
}
