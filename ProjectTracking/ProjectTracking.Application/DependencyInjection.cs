using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracking.Application.Infrastructure.Behaviors;
using System.Reflection;

namespace ProjectTracking.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly(), });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
