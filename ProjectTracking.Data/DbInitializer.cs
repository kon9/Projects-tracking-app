namespace ProjectTracking.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProjectsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
