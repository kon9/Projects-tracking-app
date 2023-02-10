using MediatR;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracking.Core.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IProjectsDbContext _dbContext;
        public CreateEmployeeCommandHandler(IProjectsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                LastName = request.LastName,
                Surname = request.Surname,
                Email = request.Email,
            };

            await _dbContext.Employees.AddAsync(employee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return employee.Id;
        }
    }
}
