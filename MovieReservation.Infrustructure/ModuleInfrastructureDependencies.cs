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
            services.AddTransient<ITheaterRepository, TheaterRepository>();
            services.AddTransient<IShowtimeRepository, ShowtimeRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));



            return services;
        }
    }
}
