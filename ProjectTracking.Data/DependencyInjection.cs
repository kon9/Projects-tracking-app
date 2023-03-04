using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;
using ProjectTracking.Data.Repository;

namespace ProjectTracking.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var projectsConnectionString = configuration.GetConnectionString("Projects");

            services.AddDbContext<ProjectsDbContext>(options =>
                options.UseSqlServer(projectsConnectionString));

            services.AddScoped<IProjectsDbContext>(provider => provider.GetService<ProjectsDbContext>());

            return services;
        }

        public static IServiceCollection AddUsers(this IServiceCollection services, IConfiguration configuration)
        {
            var usersConnectionString = configuration.GetConnectionString("Users");

            services.AddDbContext<UsersDbContext>(options =>
                options.UseSqlServer(usersConnectionString));

            return services;
        }

        public static IServiceCollection AddRepos(this IServiceCollection services)
        {
            services.AddTransient<IRepo<Project>, ProjectsRepo>();
            services.AddTransient<IRepo<Employee>, EmployeeRepo>();
            services.AddTransient<IRepo<ProjectTask>, ProjectTasksRepo>();
            return services;
        }

    }
}
