using ProjectTracking.Core.Models;
using ProjectTracking.Data.Repositories.Interfaces;
using ProjectTracking.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracking.Services
{
    public class EmployeeReadService : IEmployeeReadService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeReadService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<List<Employee>> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }

        public Task<Employee> GetEmployeeById(Guid id)
        {
            return _employeeRepository.GetById(id);
        }
    }
}
