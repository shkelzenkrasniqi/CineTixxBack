

using CineTixx.Core.Entities;

namespace CineTixx.Core.DTOs
{
    public class ScreeningDto
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid CinemaRoomId { get; set; }
        public CinemaRoom CinemaRoom { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
