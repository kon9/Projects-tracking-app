using AutoMapper;
using MediatR;
using ProjectTracking.Application.Infrastructure.Exeptions;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Projects.Queries.GetProject
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectVm>
    {
        private readonly IProjectRepo _projectRepo;
        private readonly IMapper _mapper;

        public GetProjectQueryHandler(IMapper mapper, IProjectRepo projectRepo)
        {
            _mapper = mapper;
            _projectRepo = projectRepo;
        }

        public async Task<ProjectVm> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {

            var project = await _projectRepo.GetProjectWithEmployees(request.Id);
            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            return _mapper.Map<ProjectVm>(project);
        }
    }
}
