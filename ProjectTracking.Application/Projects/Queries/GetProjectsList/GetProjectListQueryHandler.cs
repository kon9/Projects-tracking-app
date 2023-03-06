using AutoMapper;
using MediatR;
using ProjectTracking.Application.Interfaces;

namespace ProjectTracking.Application.Projects.Queries.GetProjectsList
{
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, ProjectListVm>
    {
        private readonly IProjectRepo _projectRepo;
        private readonly IMapper _mapper;
        private readonly IProjectsDbContext _dbContext;

        public GetProjectListQueryHandler(IProjectRepo projectRepo, IMapper mapper, IProjectsDbContext dbContext)
        {
            _dbContext = dbContext;
            _projectRepo = projectRepo;
            _mapper = mapper;
        }

        public async Task<ProjectListVm> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            /*var projects = await _dbContext.Projects.ProjectTo<ProjectLookupDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            var projects = await _projectRepo.GetAllAsync(cancellationToken).*/


            return new ProjectListVm { Projects = projects };

        }
    }
}
