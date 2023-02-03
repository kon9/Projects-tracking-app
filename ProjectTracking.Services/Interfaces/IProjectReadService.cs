using ProjectTracking.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracking.Services.Interfaces
{
    public interface IProjectReadService
    {
        Task<List<Project>> GetAllProjects();
        Task<List<Project>> GetAllSortedByPriority(); // added
        Task<List<Project>> GetProjectsByEmployeeId(Guid employeeId);
    }
}
