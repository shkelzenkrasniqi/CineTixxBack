using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Persistence.Database;
using Microsoft.EntityFrameworkCore;


namespace CineTixx.Persistence.Repositories
{
    public class SeatReservationRepository : ISeatReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public SeatReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SeatReservation>> GetReservedSeatsForScreeningAsync(Guid screeningId)
        {
            return await _context.SeatReservations
                .Where(sr => sr.ScreeningId == screeningId)
                .Include(sr => sr.Seat)
                .ToListAsync();
        }

        public async Task AddRangeAsync(IEnumerable<SeatReservation> seatReservations)
        {
            await _context.SeatReservations.AddRangeAsync(seatReservations);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteSeatReservationsForBookingAsync(Guid bookingId)
        {
            var seatReservationsToDelete = await _context.SeatReservations
                .Where(sr => sr.ScreeningId == bookingId) 
                .ToListAsync();

            _context.SeatReservations.RemoveRange(seatReservationsToDelete);
            await _context.SaveChangesAsync();
        }

    }
}
