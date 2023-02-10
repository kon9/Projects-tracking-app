using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectTracking.Core.Common.Exeptions;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracking.Core.Projects.Queries.GetProject
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectVm>
    {
        private readonly IProjectsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProjectQueryHandler(IProjectsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProjectVm> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects
                .FirstOrDefaultAsync(project =>
                project.Id == request.Id, cancellationToken);

            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }
            return _mapper.Map<ProjectVm>(project);
        }
    }
}
