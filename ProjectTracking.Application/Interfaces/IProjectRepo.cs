using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Interfaces;

public interface IProjectRepo : IRepo<Project>
{
    Task<Project> GetProjectWithEmployees(Guid projectId);
}