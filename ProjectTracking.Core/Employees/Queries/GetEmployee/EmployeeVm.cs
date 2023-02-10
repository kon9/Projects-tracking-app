using AutoMapper;
using ProjectTracking.Core.Common.Mappings;
using ProjectTracking.Core.Models;
using System.Collections.Generic;

namespace ProjectTracking.Core.Employees.Queries.GetEmployee
{
    public class EmployeeVm : IMapWith<Employee>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeVm>()
                .ForMember(employeeVm => employeeVm.Name,
                    opt => opt.MapFrom(employee => employee.Name))
                .ForMember(employeeVm => employeeVm.Surname,
                    opt => opt.MapFrom(employee => employee.Surname))
                .ForMember(employeeVm => employeeVm.LastName,
                    opt => opt.MapFrom(employee => employee.LastName))
                .ForMember(employeeVm => employeeVm.Email,
                    opt => opt.MapFrom(employee => employee.Email))
                .ForMember(employeeVm => employeeVm.Projects,
                    opt => opt.MapFrom(employee => employee.Projects))
                .ForMember(employeeVm => employeeVm.Tasks,
                    opt => opt.MapFrom(employee => employee.Tasks));
        }
    }
}