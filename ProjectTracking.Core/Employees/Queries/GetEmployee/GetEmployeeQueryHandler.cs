using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectTracking.Core.Common.Exeptions;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracking.Core.Employees.Queries.GetEmployee
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, EmployeeVm>
    {
        private readonly IProjectsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeeQueryHandler(IProjectsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeVm> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees
                .FirstOrDefaultAsync(employee =>
                    employee.Id == request.Id, cancellationToken);

            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }
            return _mapper.Map<EmployeeVm>(employee);
        }
    }
}
