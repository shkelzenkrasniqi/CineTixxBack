using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int NumberOfTickets { get; set; }
        public Guid ScreeningId { get; set; }
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }
        public Screening Screening { get; set; }
    }
}
