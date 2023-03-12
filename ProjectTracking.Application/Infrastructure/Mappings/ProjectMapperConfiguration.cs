using ProjectTracking.Application.Infrastructure.Mappings.Base;
using ProjectTracking.Application.Projects.Commands.CreateProject;
using ProjectTracking.Application.Projects.Commands.UpdateProject;
using ProjectTracking.Application.Projects.Models;
using ProjectTracking.Application.Projects.Queries.GetProject;
using ProjectTracking.Core.Models;
using ProjectViewModel = ProjectTracking.Application.Projects.Queries.GetProjectsList.ProjectViewModel;

namespace ProjectTracking.Application.Infrastructure.Mappings
{
    public class ProjectMapperConfiguration : MapperConfigurationBase
    {
        public ProjectMapperConfiguration()
        {
            CreateMap<Project, ProjectViewModel>();
            CreateMap<UpdateProjectCommand, Project>()
                .ForMember(x => x.ProjectTasks, o => o.Ignore())
                .ForMember(x => x.Employees, o => o.Ignore());
            CreateMap<Project, ProjectVm>();
            CreateMap<CreateProjectDto, CreateProjectCommand>();
            CreateMap<UpdateProjectDto, UpdateProjectCommand>();
        }
    }
}
