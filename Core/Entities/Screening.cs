﻿
namespace CineTixx.Core.Entities
{
    public class Screening
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid CinemaRoomId { get; set; }
        public CinemaRoom CinemaRoom { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}