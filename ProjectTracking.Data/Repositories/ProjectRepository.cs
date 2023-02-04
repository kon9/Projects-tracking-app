using Microsoft.EntityFrameworkCore;
using ProjectTracking.Core.Models;
using ProjectTracking.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracking.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectsDbContext _context;

        public ProjectRepository(ProjectsDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetById(Guid id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task Create(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Project project)
        {
            //TODO Update project and validation on update
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public bool Exist(Guid id)
        {
            return _context.Projects.Any(p => p.Id == id);
        }

    }
}
