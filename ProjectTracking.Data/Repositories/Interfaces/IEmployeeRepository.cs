using ProjectTracking.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracking.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task Create(Employee employee);
        Task Update(Employee employee);
        Task Delete(Guid id);
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(Guid id);
        bool Exist(Guid id);
    }
}
