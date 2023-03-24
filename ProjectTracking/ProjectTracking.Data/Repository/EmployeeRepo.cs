using Microsoft.EntityFrameworkCore;
using ProjectTracking.Application.Employees.Queries.GetEmployeeList;
using ProjectTracking.Application.Infrastructure.Exeptions;
using ProjectTracking.Application.Infrastructure.Helpers;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracking.Data.Repository;

public class EmployeeRepo : BaseRepo<Employee>, IEmployeeRepo
{
    public EmployeeRepo(ProjectsDbContext context) : base(context)
    {
        Table = Context.Employees;
    }

    public async Task AssignEmployeeToProjectAsync(Guid employeeId, Guid projectId, CancellationToken cancellationToken)
    {
        var employee = await Context.Employees.FirstOrDefaultAsync(employee => employee.Id == employeeId, cancellationToken);
        var project = await Context.Projects.FirstOrDefaultAsync(project => project.Id == projectId, cancellationToken);

        if (project == null)
            throw new NotFoundException(nameof(Project), projectId);
        if (employee == null)
            throw new NotFoundException(nameof(Employee), employeeId);

        var employeeProjects = employee.Projects;
        if (employeeProjects.Any(ep => ep.Id == project.Id))
            throw new InvalidOperationException($"Employee with id {employee.Id} is already assigned to project with id {project.Id}.");

        employee.Projects.Add(project);
    }

    public PagedList<Employee> GetPagedEmployees(GetPagedEmployeeListQuery employeeParam)
    {
        return PagedList<Employee>.ToPagedList(Table,
            employeeParam.PageNumber,
            employeeParam.PageSize);
    }

    public async Task RemoveEmployeeFromProject(Guid employeeId, Guid projectId, CancellationToken cancellationToken)
    {
        var project = await Context.Projects.Include(p => p.Employees)
            .FirstOrDefaultAsync(p => p.Id == projectId, cancellationToken);
        if (project == null) throw new NotFoundException(nameof(Project), projectId);

        var employee = await Context.Employees.FindAsync(employeeId);
        if (employee == null) throw new NotFoundException(nameof(Employee), employeeId);

        project.Employees.Remove(employee);
    }
}