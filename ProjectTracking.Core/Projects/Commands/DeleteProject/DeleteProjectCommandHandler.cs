using MediatR;
using ProjectTracking.Core.Common.Exeptions;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracking.Core.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IProjectsDbContext _dbContext;

        public DeleteProjectCommandHandler(IProjectsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.FindAsync(new object[] { request.Id }, cancellationToken);

            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }
            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
