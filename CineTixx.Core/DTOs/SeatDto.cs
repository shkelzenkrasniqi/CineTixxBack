using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.DTOs
{
    public class SeatDto
    {
        public Guid Id { get; set; }
        public int SeatNumber { get; set; }
        public string SeatRow { get; set; }
        public Guid CinemaRoomId { get; set; }
    }
}
