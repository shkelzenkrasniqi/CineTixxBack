using System;

namespace CineTixx.Core.Entities
{
    public class Booking
    {
        public int BookingId { get; set; } // Primary key
        public int UserId { get; set; } // Foreign key 
        public decimal Price { get; set; }
        public DateTime ScreeningDateTime { get; set; }
        

        public User User { get; set; } // Navigation property for user
    }
}
