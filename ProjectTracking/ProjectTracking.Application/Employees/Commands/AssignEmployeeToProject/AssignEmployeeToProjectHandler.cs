using MediatR;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Interfaces;

namespace ProjectTracking.Application.Employees.Commands.AssignEmployeeToProject
{
    public class AssignEmployeeToProjectHandler : IRequestHandler<AssignEmployeeToProjectCommand>
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IUnitOfWork _unitOfWork;
        public AssignEmployeeToProjectHandler(IEmployeeRepo employeeRepo, IUnitOfWork unitOfWork)
        {
            _employeeRepo = employeeRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AssignEmployeeToProjectCommand request, CancellationToken cancellationToken)
        {
            await _employeeRepo.AssignEmployeeToProjectAsync(request.EmployeeId, request.ProjectId, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }

    }
}
