
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Core;
using MovieReservation.Core.MiddleWare;
using MovieReservation.Data.Entities.Identity;
using MovieReservation.Infrustructure;
using MovieReservation.Infrustructure.Context;
using MovieReservation.Infrustructure.Seeder;
using MovieReservation.Service;

namespace MovieReservation.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Connection To SQL Server
            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContextConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            builder.Services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue; // Allow more form values
                options.MultipartBodyLengthLimit = 50 * 1024 * 1024; // 50MB limit (adjust as needed)
            });



            // Dependency injections
            builder.Services.AddInfrastructureDependencies()
                            .AddServiceDependencies()
                            .AddCoreDependencies()
                            .AddServiceRegisteration(builder.Configuration);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            // Add Swagger services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                await RoleSeeder.SeedAsync(roleManager);
                await UserSeeder.SeedAsync(userManager);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "openapi/{documentName}.json";
                });
                app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "Swagger"));
            }

            app.UseStaticFiles();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
