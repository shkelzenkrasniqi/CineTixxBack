
namespace CineTixx.Core.Entities
{
    public class Seat
    {
        public Guid Id { get; set; }
        public int SeatNumber { get; set; }
        public string SeatRow { get; set; }
        public Guid CinemaRoomId { get; set; }
        public CinemaRoom CinemaRoom { get; set; }
    }
}
