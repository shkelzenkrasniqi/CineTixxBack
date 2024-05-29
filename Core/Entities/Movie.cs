
namespace CineTixx.Core.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set;}
        public string MovieTrailer { get; set;}
        public List<MoviePhoto> Photos { get; set; }

    }
}
