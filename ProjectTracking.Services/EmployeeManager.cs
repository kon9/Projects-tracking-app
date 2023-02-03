using ProjectTracking.Core.Models;
using ProjectTracking.Data.Repositories.Interfaces;
using ProjectTracking.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracking.Services
{
    public class EmployeeManager : IEmployeeManager
    {

        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void Create(Employee employee)
        {
            _employeeRepository.Create(employee);
        }
        public void Update(Employee employee)
        {
            _employeeRepository.Update(employee);
        }
        public void Delete(Guid id)
        {
            _employeeRepository.Delete(id);
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.GetAll();
        }
        public async Task<Employee> GetEmployeeById(Guid id)
        {
            return await _employeeRepository.GetById(id);
        }
        public List<Employee> SearchEmployees(string searchTerm)
        {
            throw new System.NotImplementedException();
            //TODO employee search
        }

    }
}
