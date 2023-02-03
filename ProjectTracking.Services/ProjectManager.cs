using ProjectTracking.Core.Models;
using ProjectTracking.Data.Repositories.Interfaces;
using ProjectTracking.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracking.Services
{
    public class ProjectManager : IProjectManager
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectManager(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public void AssignEmployeeToProject(Guid employeeId, Guid projectId)
        {
            throw new NotImplementedException();
        }

        public void Create(Project project)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> GetAllSortedByPriority()
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> GetProjectsByEmployeeId(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployeeFromProject(Guid employeeId, Guid projectId)
        {
            throw new NotImplementedException();
        }

        public void Update(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
