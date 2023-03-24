using AutoMapper;
using MediatR;
using ProjectTracking.Application.Infrastructure.Exeptions;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Employees.Queries.GetEmployee
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, EmployeeVm>
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IMapper _mapper;

        public GetEmployeeQueryHandler(IEmployeeRepo employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public async Task<EmployeeVm> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepo.GetOneAsync(request.Id, cancellationToken);
            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }
            return _mapper.Map<EmployeeVm>(employee);
        }
    }
}
