using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectTracking.Core.Common.Exeptions;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracking.Core.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IProjectsDbContext _dbContext;
        public UpdateEmployeeCommandHandler(IProjectsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
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

            return Unit.Value;
        }
    }
}
