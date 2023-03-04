using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectTracking.Application.Common.Exeptions;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Employees.Commands.RemoveEmployeeFromProject
{
    public class RemoveEmployeeFromProjectCommandHandlerSuperLongNameHere : IRequestHandler<RemoveEmployeeFromProjectCommand>
    {
        private readonly IProjectsDbContext _dbContext;
        public RemoveEmployeeFromProjectCommandHandlerSuperLongNameHere(IProjectsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(RemoveEmployeeFromProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.Include(p => p.Employees)
                .FirstOrDefaultAsync(p => p.Id == request.ProjectId, cancellationToken);
            if (project == null) throw new NotFoundException(nameof(Project), request.ProjectId);

            var employee = await _dbContext.Employees.FindAsync(request.EmployeeId);
            if (employee == null) throw new NotFoundException(nameof(Employee), request.EmployeeId);


            project.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
