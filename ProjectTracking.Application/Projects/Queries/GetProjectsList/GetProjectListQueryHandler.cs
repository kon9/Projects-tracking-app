using AutoMapper;
using MediatR;
using ProjectTracking.Application.Interfaces;

namespace ProjectTracking.Application.Projects.Queries.GetProjectsList
{
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepo _projectRepo;
        private readonly IMapper _mapper;

        public GetProjectListQueryHandler(IProjectRepo projectRepo, IMapper mapper)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
        }

        public Task<List<ProjectViewModel>> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
