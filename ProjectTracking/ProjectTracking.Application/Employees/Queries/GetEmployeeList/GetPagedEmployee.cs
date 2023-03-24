using AutoMapper;
using MediatR;
using ProjectTracking.Application.Employees.Queries.GetEmployee;
using ProjectTracking.Application.Infrastructure.Helpers;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Employees.Queries.GetEmployeeList;


public class GetPagedEmployeeListHandler : IRequestHandler<GetPagedEmployeeListQuery, PagedList<EmployeeVm>>
{
    private readonly IEmployeeRepo _employeeRepo;
    private readonly IMapper _mapper;

    public GetPagedEmployeeListHandler(IEmployeeRepo employeeRepo, IMapper mapper)
    {
        _employeeRepo = employeeRepo;
        _mapper = mapper;
    }

    public async Task<PagedList<EmployeeVm>> Handle(GetPagedEmployeeListQuery request, CancellationToken cancellationToken)
    {
        var employeeList = _employeeRepo.GetPagedEmployees(request);
        var mappedList = _mapper.Map<PagedList<Employee>, PagedList<EmployeeVm>>(employeeList);
        return mappedList;
    }
}
