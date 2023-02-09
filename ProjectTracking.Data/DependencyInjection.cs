using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracking.Core.Interfaces;

namespace ProjectTracking.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Sqlite");

            services.AddDbContext<ProjectsDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IProjectsDbContext>(provider => provider.GetService<ProjectsDbContext>());

            return services;
        }
    }
}
