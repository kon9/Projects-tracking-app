using ProjectTracking.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracking.Services.Interfaces
{
    public interface IProjectReadService
    {
        Task<Project> GetProjectById(Guid projectId);
        Task<List<Project>> GetAllProjects();
        Task<List<Project>> GetProjectsByDateRange(DateTime startDate, DateTime endDate);
    }
}
