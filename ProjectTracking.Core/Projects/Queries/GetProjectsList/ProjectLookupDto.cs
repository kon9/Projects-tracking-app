using AutoMapper;
using ProjectTracking.Core.Common.Mappings;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Core.Projects.Queries.GetProjectsList
{
    public class ProjectLookupDto : IMapWith<Project>
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectLookupDto>()
                .ForMember(projectDto => projectDto.Name,
                opt => opt.MapFrom(project => project.ProjectName))
                .ForMember(projectDto => projectDto.Priority,
                opt => opt.MapFrom(project => project.ProjectPriority));
        }
    }
}
