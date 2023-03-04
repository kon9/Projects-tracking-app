using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectTracking.Application.Common.Exeptions;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IProjectsDbContext _dbContext;
        public UpdateEmployeeCommandHandler(IProjectsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(employee => employee.Id == request.Id, cancellationToken: cancellationToken);
            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            employee.Name = request.Name;
            employee.Surname = request.Surname;
            employee.LastName = request.LastName;
            employee.Email = request.Email;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
