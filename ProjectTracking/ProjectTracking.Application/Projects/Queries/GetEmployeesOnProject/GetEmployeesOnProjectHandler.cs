using AutoMapper;
using MediatR;
using ProjectTracking.Application.Employees.Queries.GetEmployee;
using ProjectTracking.Application.Interfaces;

namespace ProjectTracking.Application.Projects.Queries.GetEmployeesOnProject;

public class GetEmployeesOnProjectHandler : IRequestHandler<GetEmployeesOnProjectQuery, EmployeeVm>
{
    private readonly IProjectRepo _projectRepo;
    private readonly IMapper _mapper;

    public GetEmployeesOnProjectHandler(IMapper mapper, IProjectRepo projectRepo)
    {
        _mapper = mapper;
        _projectRepo = projectRepo;
    }
    public Task<EmployeeVm> Handle(GetEmployeesOnProjectQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();//TODO Implement get employees on project
    }
}