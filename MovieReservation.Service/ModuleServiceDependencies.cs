﻿using Microsoft.Extensions.DependencyInjection;
using MovieReservation.Service.Abstracts;
using MovieReservation.Service.Implementations;

namespace MovieReservation.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ITheaterService, TheaterService>();

            return services;
        }
    }
}
