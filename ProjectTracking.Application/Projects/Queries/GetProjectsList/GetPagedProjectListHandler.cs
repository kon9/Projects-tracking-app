using AutoMapper;
using MediatR;
using ProjectTracking.Application.Infrastructure.Helpers;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Projects.Queries.GetProjectsList
{
    public class GetPagedProjectListHandler : IRequestHandler<GetPagedProjectListQuery, PagedList<ProjectViewModel>>
    {
        private readonly IProjectRepo _projectRepo;
        private readonly IMapper _mapper;

        public GetPagedProjectListHandler(IProjectRepo projectRepo, IMapper mapper)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
        }

        public async Task<PagedList<ProjectViewModel>> Handle(GetPagedProjectListQuery request, CancellationToken cancellationToken)
        {
            var projectList = _projectRepo.GetPagedProjects(request);
            var mapped = _mapper.Map<PagedList<Project>, PagedList<ProjectViewModel>>(projectList);
            return mapped;
        }
    }
}
