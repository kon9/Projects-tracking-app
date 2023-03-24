using ProjectTracking.Application.Employees.Commands.CreateEmployee;
using ProjectTracking.Application.Employees.Commands.UpdateEmployee;
using ProjectTracking.Application.Employees.Models;
using ProjectTracking.Application.Employees.Queries.GetEmployee;
using ProjectTracking.Application.Infrastructure.Mappings.Base;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Infrastructure.Mappings;

public class EmployeeMapperConfiguration : MapperConfigurationBase
{
    public EmployeeMapperConfiguration()
    {
        CreateMap<UpdateEmployeeCommand, Employee>()
            .ForMember(x => x.Projects, o => o.Ignore())
            .ForMember(x => x.Tasks, o => o.Ignore());
        CreateMap<Employee, EmployeeVm>();
        CreateMap<CreateEmployeeDto, CreateEmployeeCommand>();


    }
}