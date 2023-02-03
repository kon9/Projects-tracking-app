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
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public bool Exist(Guid id)
        {
            return _context.Employees.Any(p => p.Id == id);
        }

    }
}
