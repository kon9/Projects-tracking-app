using ProjectTracking.Core.Models;
using System;

namespace ProjectTracking.Services.Interfaces
{
    public interface IEmployeeWriteService
    {
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(Guid id);
        void AssignEmployeeToProject(Guid employeeId, Guid projectId);
        void RemoveEmployeeFromProject(Guid employeeId, Guid projectId);
    }
}
