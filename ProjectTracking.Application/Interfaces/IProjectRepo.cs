using ProjectTracking.Application.Infrastructure.Helpers;
using ProjectTracking.Application.Projects.Queries.GetProjectsList;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Interfaces;

public interface IProjectRepo : IRepo<Project>
{
    PagedList<Project> GetPagedProjects(GetPagedProjectListQuery projectParam);
    Task<Project> GetProjectWithEmployees(Guid projectId);
}