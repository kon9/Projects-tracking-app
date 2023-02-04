using Microsoft.EntityFrameworkCore;
using ProjectTracking.Core.Models;
using ProjectTracking.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracking.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ProjectsDbContext _context;

        public EmployeeRepository(ProjectsDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(Guid id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task Create(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Surname = employee.Surname;
                existingEmployee.Email = employee.Email;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public bool Exist(Guid id)
        {
            return _context.Employees.Any(p => p.Id == id);
        }

        public async Task<List<Project>> GetEmployeeProjects(Guid employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            return employee.Projects;
        }

        public async Task AddEmployeeToProject(Guid employeeId, Guid projectId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            var project = await _context.Projects.FindAsync(projectId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with id {employeeId} was not found.");
            }

            if (project == null)
            {
                throw new ArgumentException($"Project with id {projectId} was not found.");
            }

            employee.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveEmployeeFromProject(Guid employeeId, Guid projectId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            var project = await _context.Projects.FindAsync(projectId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with id {employeeId} was not found.");
            }

            if (project == null)
            {
                throw new ArgumentException($"Project with id {projectId} was not found.");
            }
            employee.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
