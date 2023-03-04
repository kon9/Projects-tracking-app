using AutoMapper;
using ProjectTracking.Application.Common.Mappings;
using ProjectTracking.Application.Employees.Commands.UpdateEmployee;
using System;

namespace ProjectTracking.Web.Models
{
    public class UpdateEmployeeDto : IMapWith<UpdateEmployeeCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmployeeDto, UpdateEmployeeCommand>()
                .ForMember(employeeCommand => employeeCommand.Id, opt =>
                    opt.MapFrom(employeeDto => employeeDto.Id))
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
