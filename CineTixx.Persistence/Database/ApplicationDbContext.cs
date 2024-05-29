using CineTixx.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CineTixx.Persistence.Database
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<CinemaRoom> CinemaRooms { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<SeatReservation> SeatReservations { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<MoviePhoto> MoviePhotos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure SeatReservation relationships
            modelBuilder.Entity<SeatReservation>()
                .HasOne(sr => sr.Seat)
                .WithMany()
                .HasForeignKey(sr => sr.SeatId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SeatReservation>()
                .HasOne(sr => sr.Screening)
                .WithMany()
                .HasForeignKey(sr => sr.ScreeningId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure other entity relationships here as needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
