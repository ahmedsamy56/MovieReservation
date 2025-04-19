using Microsoft.Extensions.DependencyInjection;
using MovieReservation.Infrustructure.Abstracts;
using MovieReservation.Infrustructure.GenericRepository;
using MovieReservation.Infrustructure.Repositories;

namespace MovieReservation.Infrustructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IShowtimeRepository, ShowtimeRepository>();
            services.AddTransient<ITheaterRepository, TheaterRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));



            return services;
        }
    }
}
