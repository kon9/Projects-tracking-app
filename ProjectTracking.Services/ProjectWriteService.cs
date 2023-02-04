using ProjectTracking.Core.Models;
using ProjectTracking.Data.Repositories.Interfaces;
using ProjectTracking.Services.Interfaces;
using System;

namespace ProjectTracking.Services
{
    public class ProjectWriteService : IProjectWriteService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectWriteService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public void Create(Project project)
        {
            _projectRepository.Create(project);
        }

        public void Delete(Guid id)
        {
            _projectRepository.Delete(id);
        }

        public void Update(Project project)
        {
            _projectRepository.Update(project);
        }
    }
}
