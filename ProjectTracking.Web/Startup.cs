using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ProjectTracking.Application;
using ProjectTracking.Application.Infrastructure.Mappings.Base;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Data;
using ProjectTracking.Data.Repository;

namespace ProjectTracking.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IAutomapper));

            services.AddApplication();
            services.AddData(Configuration);
            services.AddRepos();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectTrackingApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectTrackingApi v1"));

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
