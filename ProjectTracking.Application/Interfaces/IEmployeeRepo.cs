using ProjectTracking.Application.Employees.Queries.GetEmployeeList;
using ProjectTracking.Application.Infrastructure.Helpers;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Interfaces;

public interface IEmployeeRepo : IRepo<Employee>
{
    PagedList<Employee> GetPagedEmployees(GetPagedEmployeeListQuery projectParam);
    Task AssignEmployeeToProjectAsync(Guid employeeId, Guid projectId, CancellationToken cancellationToken);
    Task RemoveEmployeeFromProject(Guid employeeId, Guid projectId, CancellationToken cancellationToken);
}