using ProjectTracking.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracking.Services.Interfaces
{
    public interface IProjectManager
    {
        void Create(Project project);
        void Update(Project project);
        void Delete(Guid id);
        void AssignEmployeeToProject(Guid employeeId, Guid projectId);
        void RemoveEmployeeFromProject(Guid employeeId, Guid projectId);
        Task<List<Project>> GetAllProjects();
        Task<List<Project>> GetAllSortedByPriority(); // added
        Task<List<Project>> GetProjectsByEmployeeId(Guid employeeId);
    }
}
