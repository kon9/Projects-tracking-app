using MediatR;
using ProjectTracking.Application.Interfaces;

namespace ProjectTracking.Application.Employees.Commands.RemoveEmployeeFromProject
{
    public class RemoveEmployeeFromProjectCommandHandlerSuperLongNameHere : IRequestHandler<RemoveEmployeeFromProjectCommand>
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IUnitOfWork _unitOfWork;
        public RemoveEmployeeFromProjectCommandHandlerSuperLongNameHere(IEmployeeRepo employeeRepo, IUnitOfWork unitOfWork)
        {
            _employeeRepo = employeeRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveEmployeeFromProjectCommand request, CancellationToken cancellationToken)
        {
            await _employeeRepo.RemoveEmployeeFromProject(request.EmployeeId, request.ProjectId, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
