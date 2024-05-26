using CineTixx.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.DTOs
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public Guid ScreeningId { get; set; }
        public Guid UserId { get; set; }
        public int NumberOfTickets { get; set; }

    }
}
