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
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IScreeningRepository _screeningRepository;
        private readonly ISeatReservationRepository _seatReservationRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IScreeningRepository screeningRepository, ISeatReservationRepository seatReservationRepository,ISeatRepository seatRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _screeningRepository = screeningRepository;
            _seatReservationRepository = seatReservationRepository;
            _seatRepository = seatRepository;
            _mapper = mapper;
        }
        public async Task AddBookingAsync(BookingDto bookingDto)
        {
            var screening = await _screeningRepository.GetByIdAsync(bookingDto.ScreeningId);
            if (screening == null)
            {
                throw new ArgumentException("Screening not found.");
            }

            // Retrieve all seats for the cinema room of the screening
            var seatsForCinemaRoom = await _seatRepository.GetSeatsForCinemaRoomAsync(screening.CinemaRoomId);

            // Retrieve all reserved seats for the screening
            var reservedSeats = await _seatReservationRepository.GetReservedSeatsForScreeningAsync(bookingDto.ScreeningId);
            var reservedSeatIds = reservedSeats.Select(sr => sr.SeatId).ToList();

            // Filter available seats by excluding reserved seats
            var availableSeats = seatsForCinemaRoom.Where(s => !reservedSeatIds.Contains(s.Id)).ToList();

            // Check if there are enough available seats for booking
            if (availableSeats.Count < bookingDto.NumberOfTickets)
            {
                throw new InvalidOperationException("Not enough available seats for the requested number of tickets.");
            }

            // Reserve the seats for this booking
            var reservedSeatsToAdd = availableSeats.Take(bookingDto.NumberOfTickets)
                .Select(seat => new SeatReservation
                {
                    Id = Guid.NewGuid(),
                    ScreeningId = bookingDto.ScreeningId,
                    SeatId = seat.Id,
                    IsReserved = true
                })
                .ToList();

            await _seatReservationRepository.AddRangeAsync(reservedSeatsToAdd);

            // Create and save the booking
            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                TotalPrice = screening.Price * bookingDto.NumberOfTickets,
                ScreeningId = bookingDto.ScreeningId,
                UserId = bookingDto.UserId,
                NumberOfTickets = bookingDto.NumberOfTickets
            };

            await _bookingRepository.AddAsync(booking);
        }


        public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto> GetBookingAsync(Guid id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task DeleteBookingAsync(Guid id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            if (booking != null)
            {
                // Delete the associated seat reservations
                await _seatReservationRepository.DeleteSeatReservationsForBookingAsync(id);

                // Delete the booking
                await _bookingRepository.DeleteAsync(id);
            }
        }
    }
}
