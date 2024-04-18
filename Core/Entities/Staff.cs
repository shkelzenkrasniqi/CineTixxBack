
using System.ComponentModel.DataAnnotations;

namespace CineTixx.Core.Entities
{
    public class Staff
    {
       [Key] public Guid UniqueId { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public Guid PositionId { get; set; } // Foreign key
        public Position Position { get; set; } // Navigation property
                                               public Guid UserId { get; set; } // Foreign key (assuming relation with user)
                                               // public User User { get; set; } 
    }
}
