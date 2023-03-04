using AutoMapper;
using ProjectTracking.Application.Common.Mappings;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Projects.Queries.GetProject
{
    public class ProjectVm : IMapWith<Project>
    {
        public string ProjectName { get; set; }
        public string CustomerCompanyName { get; set; }
        public string PerformerCompanyName { get; set; }
        public int ProjectPriority { get; set; }
        public Guid ProjectManagerId { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectVm>()
                .ForMember(projectVm => projectVm.ProjectName,
                opt => opt.MapFrom(project => project.ProjectName))
                .ForMember(projectVm => projectVm.CustomerCompanyName,
                opt => opt.MapFrom(project => project.CustomerCompanyName))
                .ForMember(projectVm => projectVm.PerformerCompanyName,
                opt => opt.MapFrom(project => project.PerformerCompanyName))
                .ForMember(projectVm => projectVm.ProjectPriority,
                opt => opt.MapFrom(project => project.ProjectPriority))
                .ForMember(projectVm => projectVm.ProjectManagerId,
                opt => opt.MapFrom(project => project.ProjectManagerId))
                .ForMember(projectVm => projectVm.ProjectTasks,
                opt => opt.MapFrom(project => project.ProjectTasks))
                .ForMember(projectVm => projectVm.Employees,
                opt => opt.MapFrom(project => project.Employees))
                .ForMember(projectVm => projectVm.StartDate,
                opt => opt.MapFrom(project => project.StartDate))
                .ForMember(projectVm => projectVm.EndDate,
                opt => opt.MapFrom(project => project.EndDate));
        }
    }
}
