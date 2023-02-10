using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectTracking.Core.Common.Exeptions;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracking.Core.Employees.Commands.AssignEmployeeToProject
{
    public class AssignEmployeeToProjectHandler : IRequestHandler<AssignEmployeeToProjectCommand>
    {
        private readonly IProjectsDbContext _dbContext;
        public AssignEmployeeToProjectHandler(IProjectsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(AssignEmployeeToProjectCommand request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.Id == request.EmployeeId, cancellationToken);
            var project = await _dbContext.Projects.FirstOrDefaultAsync(project => project.Id == request.ProjectId, cancellationToken);

            if (project == null)
                throw new NotFoundException(nameof(Project), request.ProjectId);
            if (employee == null)
                throw new NotFoundException(nameof(Employee), request.EmployeeId);


            var employeeProjects = employee.Projects;
            if (employeeProjects.Any(ep => ep.Id == project.Id))
                throw new InvalidOperationException($"Employee with id {employee.Id} is already assigned to project with id {project.Id}.");

            employee.Projects.Add(project);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
