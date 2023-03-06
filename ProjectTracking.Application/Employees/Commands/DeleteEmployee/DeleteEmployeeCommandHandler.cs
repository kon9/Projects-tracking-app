using MediatR;
using ProjectTracking.Application.Common.Exeptions;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeCommandHandler(IEmployeeRepo employeeRepo, IUnitOfWork unitOfWork)
        {
            _employeeRepo = employeeRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepo.GetOneAsync(request.Id, cancellationToken);

            if (employee == null) throw new NotFoundException(nameof(Employee), request.Id);

            await _employeeRepo.DeleteAsync(request.Id);
            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
