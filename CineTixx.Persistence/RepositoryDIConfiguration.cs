using CineTixx.Core.Ports.Driven;
using Microsoft.Extensions.DependencyInjection;


namespace CineTixx.Persistence
{

    public class RepositoryDIConfiguration
    {

        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ICinemaRoomRepository, CinemaRoomRepository>();
        }
    }
}