

namespace CineTixx.Core.DTOs
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public string MovieTrailer { get; set; }
        public List<MoviePhotoDto> Photos { get; set; }

    }
}
