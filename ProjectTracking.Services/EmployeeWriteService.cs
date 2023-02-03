using ProjectTracking.Core.Models;
using ProjectTracking.Data.Repositories.Interfaces;
using ProjectTracking.Services.Interfaces;
using System;

namespace ProjectTracking.Services
{
    public class EmployeeWriteService : IEmployeeWriteService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeWriteService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Create(Employee employee)
        {
            _employeeRepository.Create(employee);
        }

        public void Delete(Guid id)
        {
            _employeeRepository.Delete(id);
        }

        public void Update(Employee employee)
        {
            _employeeRepository.Update(employee);
        }
    }
}
