

using CineTixx.Core.Entities;

namespace CineTixx.Core.DTOs
{
    public class ScreeningDto
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid CinemaRoomId { get; set; }
        public Guid MovieId { get; set; }
        public string MovieName { get; set; }
    }
}
