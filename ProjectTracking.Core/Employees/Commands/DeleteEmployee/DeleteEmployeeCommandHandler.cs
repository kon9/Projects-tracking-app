using MediatR;
using ProjectTracking.Core.Common.Exeptions;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracking.Core.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IProjectsDbContext _dbContext;

        public DeleteEmployeeCommandHandler(IProjectsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.FindAsync(new object[] { request.Id }, cancellationToken);

            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
