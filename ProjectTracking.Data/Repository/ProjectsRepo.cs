using Microsoft.EntityFrameworkCore;
using ProjectTracking.Application.Infrastructure.Helpers;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Application.Projects.Queries.GetProjectsList;
using ProjectTracking.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracking.Data.Repository;

public class ProjectsRepo : BaseRepo<Project>, IProjectRepo
{
    private readonly ISortHelper<Project> _sortHelper;
    public ProjectsRepo(ProjectsDbContext context, ISortHelper<Project> sortHelper) : base(context)
    {
        Table = Context.Projects;
        _sortHelper = sortHelper;
    }

    public PagedList<Project> GetPagedProjects(GetPagedProjectListQuery projectParam)
    {
        var projects = FilterProjects(projectParam);
        var sortedProjects = _sortHelper.ApplySort(projects, projectParam.OrderBy);

        return PagedList<Project>.ToPagedList(sortedProjects,
            projectParam.PageNumber,
            projectParam.PageSize);
    }
    private IQueryable<Project> FilterProjects(GetPagedProjectListQuery projectParam)
    {
        return Table.Where(project =>
            project.StartDate >= projectParam.MinYearOfStart && project.StartDate <= projectParam.MaxYearOfStart &&
            project.ProjectPriority >= projectParam.MinPriority);
    }

    public async Task<Project> GetProjectWithEmployees(Guid projectId)
    {
        return Table.Include(p => p.Employees).FirstOrDefault(p => p.Id == projectId);
    }
}