using Microsoft.EntityFrameworkCore;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Application.Projects.Queries.GetProjectsList;
using ProjectTracking.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using ProjectTracking.Application.Infrastructure.Helpers;

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
        var projects = Table.Where(pr =>
            pr.StartDate >= projectParam.MinYearOfStart && pr.StartDate <= projectParam.MaxYearOfStart &&
            pr.ProjectPriority >= projectParam.MinPriority);

        var sortedProjects = _sortHelper.ApplySort(projects, projectParam.OrderBy);

        return PagedList<Project>.ToPagedList(sortedProjects,
            projectParam.PageNumber,
            projectParam.PageSize);
    }

    public async Task<Project> GetProjectWithEmployees(Guid projectId)
    {
        return Table.Include(p => p.Employees).FirstOrDefault(p => p.Id == projectId);
    }
}