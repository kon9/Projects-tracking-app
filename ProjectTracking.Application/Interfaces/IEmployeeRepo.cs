using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Interfaces;

public interface IEmployeeRepo : IRepo<Employee>
{
    Task AssignEmployeeToProjectAsync(Guid employeeId, Guid projectId, CancellationToken cancellationToken);
    Task RemoveEmployeeFromProject(Guid employeeId, Guid projectId, CancellationToken cancellationToken);
}