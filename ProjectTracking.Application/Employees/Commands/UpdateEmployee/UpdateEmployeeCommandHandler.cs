using AutoMapper;
using MediatR;
using ProjectTracking.Application.Infrastructure.Exeptions;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeRepo employeeRepo, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepo.GetOneAsync(request.Id, cancellationToken);
            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }
            _mapper.Map(request, employee);
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
