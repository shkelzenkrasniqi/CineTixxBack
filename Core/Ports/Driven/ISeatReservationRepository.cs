using CineTixx.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.Ports.Driven
{
    public interface ISeatReservationRepository
    {
        Task<IEnumerable<SeatReservation>> GetReservedSeatsForScreeningAsync(Guid screeningId);
        Task AddRangeAsync(IEnumerable<SeatReservation> seatReservations);
        Task DeleteSeatReservationsForBookingAsync(Guid bookingId);
    }
}
