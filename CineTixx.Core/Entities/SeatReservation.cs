using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.Entities
{
    public class SeatReservation
    {
        public Guid Id { get; set; }
        public Guid SeatId { get; set; }
        public Seat Seat { get; set; }
        public Guid ScreeningId { get; set; }
        public Screening Screening { get; set; }
        public bool IsReserved { get; set; }
    }
}
