using ProjectTracking.Core.Models;
using System;

namespace ProjectTracking.Services.Interfaces
{
    public interface IProjectWriteService
    {
        void Create(Project project);
        void Update(Project project);
        void Delete(Guid id);
        void AssignEmployeeToProject(Guid employeeId, Guid projectId);
        void RemoveEmployeeFromProject(Guid employeeId, Guid projectId);
    }
}
