using CineTixx.Core.Ports.Driven;
using CineTixx.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace CineTixx.Persistence
{

    public class RepositoryDIConfiguration
    {

        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ICinemaRoomRepository, CinemaRoomRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IScreeningRepository, ScreeningRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ISeatReservationRepository, SeatReservationRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IComingSoonRepository, ComingSoonRepository>();

        }
    }
}