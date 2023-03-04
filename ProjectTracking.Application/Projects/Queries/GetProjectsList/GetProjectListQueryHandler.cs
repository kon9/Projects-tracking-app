using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectTracking.Core.Interfaces;

namespace ProjectTracking.Application.Projects.Queries.GetProjectsList
{
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, ProjectListVm>
    {
        private readonly IProjectsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProjectListQueryHandler(IProjectsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProjectListVm> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            var projects = await _dbContext.Projects.ProjectTo<ProjectLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProjectListVm { Projects = projects };

        }
    }
}
