using CineTixx.Core.Entities;

namespace CineTixx.Core.DTOs
    {
        public class BookingDto
        {
            public int BookingId { get; set; } 
            public int UserId { get; set; } 
            public decimal Price { get; set; }
            public DateTime ScreeningDateTime { get; set; }


          
        }
    
}
