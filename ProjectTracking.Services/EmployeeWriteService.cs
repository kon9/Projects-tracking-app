using ProjectTracking.Core.Models;
using ProjectTracking.Data.Repositories.Interfaces;
using ProjectTracking.Services.Interfaces;
using System;
using System.Linq;

namespace ProjectTracking.Services
{
    public class EmployeeWriteService : IEmployeeWriteService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        public EmployeeWriteService(IEmployeeRepository employeeRepository, IProjectRepository projectRepository)
        {
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
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

        public async void RemoveEmployeeFromProject(Guid employeeId, Guid projectId)
        {
            var project = _projectRepository.GetById(projectId);
            if (project == null)
                throw new ArgumentException($"Project with id {projectId} was not found.");

            var employee = _employeeRepository.GetById(employeeId);
            if (employee == null)
                throw new ArgumentException($"Employee with id {employeeId} was not found.");

            var employeeProjects = await _employeeRepository.GetEmployeeProjects(employeeId);
            if (!employeeProjects.Any(ep => ep.Id == projectId))
                throw new InvalidOperationException($"Employee with id {employeeId} is not assigned to project with id {projectId}.");

            await _employeeRepository.RemoveEmployeeFromProject(employeeId, projectId);
        }
        public async void AssignEmployeeToProject(Guid employeeId, Guid projectId)
        {
            var employee = await _employeeRepository.GetById(employeeId);
            var project = await _projectRepository.GetById(projectId);

            if (project == null)
                throw new ArgumentException($"Project with id {projectId} was not found.");
            if (employee == null)
                throw new ArgumentException($"Employee with id {employeeId} was not found.");


            var employeeProjects = await _employeeRepository.GetEmployeeProjects(employeeId);
            if (employeeProjects.Any(ep => ep.Id == projectId))
                throw new InvalidOperationException($"Employee with id {employeeId} is already assigned to project with id {projectId}.");

            await _employeeRepository.AddEmployeeToProject(employeeId, projectId);
        }
    }
}

