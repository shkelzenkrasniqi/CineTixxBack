namespace CineTixx.Core.Entities
{
    public class CinemaRoom
    {
        public Guid Id { get; set; }
        public int RoomNumber { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public bool Is3D { get; set; }
        public bool HasIMAX { get; set; }
    }
}
