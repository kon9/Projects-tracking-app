using ProjectTracking.Core.Models;

namespace ProjectTracking.Data.Repository;

public class ProjectsRepo : BaseRepo<Project>
{
    public ProjectsRepo(ProjectsDbContext context) : base(context)
    {
        Table = Context.Projects;
    }
}