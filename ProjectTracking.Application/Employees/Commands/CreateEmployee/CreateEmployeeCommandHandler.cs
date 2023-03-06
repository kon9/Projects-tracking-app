using MediatR;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IUnitOfWork _unitOfWork;
        public CreateEmployeeCommandHandler(IEmployeeRepo employeeRepo, IUnitOfWork unitOfWork)
        {
            _employeeRepo = employeeRepo;
            _unitOfWork = unitOfWork;
        }

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

            await _employeeRepo.AddAsync(employee, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return employee.Id;
        }
    }
}
