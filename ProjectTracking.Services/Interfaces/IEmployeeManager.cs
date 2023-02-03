using ProjectTracking.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracking.Services.Interfaces
{
    public interface IEmployeeManager
    {
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(Guid id);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(Guid id);
    }
}
