using Microsoft.Extensions.DependencyInjection;
using MovieReservation.Service.Abstracts;
using MovieReservation.Service.Implementations;

namespace MovieReservation.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();

            return services;
        }
    }
}
