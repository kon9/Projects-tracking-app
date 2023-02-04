using ProjectTracking.Core.Models;
using ProjectTracking.Data.Repositories.Interfaces;
using ProjectTracking.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracking.Services
{
    public class ProjectReadService : IProjectReadService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectReadService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public Task<List<Project>> GetAllProjects()
        {
            return _projectRepository.GetAll();
        }
        public Task<Project> GetProjectById(Guid projectId)
        {
            return _projectRepository.GetById(projectId);
        }

        public async Task<List<Project>> GetProjectsByDateRange(DateTime startDate, DateTime endDate)
        {
            //idk what to do with asyncs functions everywhere
            var projects = await _projectRepository.GetAll();
            var filteredProjects = projects.Where(p => p.CreationDate >= startDate && p.CompletionDate <= endDate).ToList();
            return filteredProjects;
        }
    }
}
