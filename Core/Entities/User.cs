namespace CineTixx.Core.Entities
{
    public class User
    {
        public int UserId { get; set; } //primary key
        public string? Name { get; set; }    
        public string? Email { get; set; }
        public string? Password { get; set; }


       public ICollection<Booking>? Bookings { get; set; }
    }
}