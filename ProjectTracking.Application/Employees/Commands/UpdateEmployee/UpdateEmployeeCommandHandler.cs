using MediatR;
using ProjectTracking.Application.Common.Exeptions;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEmployeeCommandHandler(IEmployeeRepo employeeRepo, IUnitOfWork unitOfWork)
        {
            _employeeRepo = employeeRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepo.GetOneAsync(request.Id, cancellationToken);
            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            employee.Name = request.Name;
            employee.Surname = request.Surname;
            employee.LastName = request.LastName;
            employee.Email = request.Email;

            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
