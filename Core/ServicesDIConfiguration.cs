using CineTixx.Core.Ports.Driving;
using CineTixx.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CineTixx.Core
{
    public class ServicesDIConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICinemaRoomService, CinemaRoomService>();
            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IScreeningService, ScreeningService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}