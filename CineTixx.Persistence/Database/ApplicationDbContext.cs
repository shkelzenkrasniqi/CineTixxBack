using CineTixx.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CineTixx.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<CinemaRoom> CinemaRooms { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
