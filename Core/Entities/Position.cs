
namespace CineTixx.Core.Entities
{
    public class Position
    {
        public Guid Id { get; set; } // Primary key (assuming)
        public string PositionName { get; set; }
        public string PositionDescription { get; set; }
        public string Shift { get; set; }
        // Additional properties related to position
    }
}
