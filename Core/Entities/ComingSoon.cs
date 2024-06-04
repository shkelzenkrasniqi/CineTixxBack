using System;

namespace CineTixx.Core.Entities
{
    public class ComingSoon
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PhotoUrl { get; set; }
    }
}