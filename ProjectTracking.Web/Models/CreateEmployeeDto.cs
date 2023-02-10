using AutoMapper;
using ProjectTracking.Core.Common.Mappings;
using ProjectTracking.Core.Employees.Commands.CreateEmployee;

namespace ProjectTracking.Web.Models
{
    public class CreateEmployeeDto : IMapWith<CreateEmployeeCommand>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeDto, CreateEmployeeCommand>()
                .ForMember(employeeCommand => employeeCommand.Name, opt =>
                    opt.MapFrom(employeeDto => employeeDto.Name))
                .ForMember(employeeCommand => employeeCommand.Surname, opt =>
                    opt.MapFrom(employeeDto => employeeDto.Surname))
                .ForMember(employeeCommand => employeeCommand.LastName, opt =>
                    opt.MapFrom(employeeDto => employeeDto.LastName))
                .ForMember(employeeCommand => employeeCommand.Email, opt =>
                    opt.MapFrom(employeeDto => employeeDto.Email));
        }

    }
}
