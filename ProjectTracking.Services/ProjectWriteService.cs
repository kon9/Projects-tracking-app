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
