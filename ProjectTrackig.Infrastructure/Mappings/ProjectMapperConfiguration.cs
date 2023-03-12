using ProjectTracking.Application.Common.Mappings.Base;
using ProjectTracking.Application.Projects.Commands.CreateProject;
using ProjectTracking.Application.Projects.Commands.UpdateProject;
using ProjectTracking.Application.Projects.Queries.GetProject;
using ProjectTracking.Core.Models;
using ProjectTracking.Web.Models;
using ProjectViewModel = ProjectTracking.Application.Projects.Queries.GetProjectsList.ProjectViewModel;

namespace ProjectTracking.Application.Common.Mappings
{
    public class ProjectMapperConfiguration : MapperConfigurationBase
    {
        public ProjectMapperConfiguration()
        {
            CreateMap<Project, ProjectViewModel>();
            CreateMap<UpdateProjectCommand, Project>();
            CreateMap<Project, ProjectVm>();
            CreateMap<CreateProjectDto, CreateProjectCommand>();
        }
    }
}
