using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracking.Application.Infrastructure.Helpers;
using ProjectTracking.Application.Interfaces;
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
            return services;
        }

        public static IServiceCollection AddRepos(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepo, EmployeeRepo>();
            services.AddTransient<IProjectRepo, ProjectsRepo>();
            services.AddTransient<IProjectTaskRepo, ProjectTasksRepo>();
            services.AddScoped<ISortHelper<Project>, SortHelper<Project>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

    }
}
