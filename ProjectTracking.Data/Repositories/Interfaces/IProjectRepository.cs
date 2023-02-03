using ProjectTracking.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracking.Data.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task Create(Project project);
        Task Update(Project project);
        Task Delete(Guid id);
        Task<List<Project>> GetAll();
        Task<Project> GetById(Guid id);
        bool Exist(Guid id);
    }
}
