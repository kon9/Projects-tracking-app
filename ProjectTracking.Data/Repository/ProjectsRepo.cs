using Microsoft.EntityFrameworkCore;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracking.Data.Repository;

public class ProjectsRepo : BaseRepo<Project>, IProjectRepo
{
    public ProjectsRepo(ProjectsDbContext context) : base(context)
    {
        Table = Context.Projects;
    }



    public async Task<Project> GetProjectWithEmployees(Guid projectId)
    {
        return Table.Include(p => p.Employees).FirstOrDefault(p => p.Id == projectId);
    }
}