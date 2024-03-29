using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ProjectTracking.Identity;
using ProjectTracking.Identity.Data;
using ProjectTracking.Identity.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetValue<string>("DbConnection");
builder.Services.AddDbContext<AuthDbContext>(opt =>
{
    opt.UseSqlite(connectionString);
});

builder.Services.AddIdentity<AppUser, IdentityRole>(cfg =>
    {
        cfg.Password.RequiredLength = 4;
        cfg.Password.RequireNonAlphanumeric = false;
        cfg.Password.RequireDigit = false;
        cfg.Password.RequireUppercase = false;
    }).AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<AppUser>()
    .AddInMemoryApiResources(Configuration.ApiResources)
    .AddInMemoryIdentityResources(Configuration.IdentityResources)
    .AddInMemoryApiScopes(Configuration.ApiScopes)
    .AddInMemoryClients(Configuration.Clients)
    .AddDeveloperSigningCredential();


builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.Cookie.Name = "Projects.Identity.Cookie";
    cfg.LoginPath = "/Auth/Login";
    cfg.LogoutPath = "/Auth/Logout";
});

builder.Services.AddControllersWithViews();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<AuthDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception e)
    {
        var logger = serviceProvider.GetService<ILogger<Program>>();
        logger.LogError(e, "An error occurred while app initialization");
    }
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
               Path.Combine(Directory.GetCurrentDirectory(), "Styles")),
    RequestPath = "/styles"
});
app.UseRouting();
app.UseIdentityServer();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();
