using MediatR;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IProjectsDbContext _dbContext;
        public CreateProjectCommandHandler(IProjectsDbContext dbContext) =>
            _dbContext = dbContext;


        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                ProjectName = request.ProjectName,
                CustomerCompanyName = request.CustomerCompanyName,
                PerformerCompanyName = request.PerformerCompanyName,
                ProjectPriority = request.ProjectPriority,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };

            await _dbContext.Projects.AddAsync(project, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return project.Id;
        }
    }
}
