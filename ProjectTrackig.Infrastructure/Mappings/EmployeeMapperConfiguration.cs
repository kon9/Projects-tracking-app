using ProjectTracking.Application.Common.Mappings.Base;
using ProjectTracking.Application.Employees.Commands.CreateEmployee;
using ProjectTracking.Application.Employees.Commands.UpdateEmployee;
using ProjectTracking.Application.Employees.Queries.GetEmployee;
using ProjectTracking.Core.Models;
using ProjectTracking.Web.Models;

namespace ProjectTracking.Application.Common.Mappings;

public class EmployeeMapperConfiguration : MapperConfigurationBase
{
    public EmployeeMapperConfiguration()
    {
        CreateMap<UpdateEmployeeCommand, Employee>();
        CreateMap<Employee, EmployeeVm>();
        CreateMap<CreateEmployeeDto, CreateEmployeeCommand>();

    }
}