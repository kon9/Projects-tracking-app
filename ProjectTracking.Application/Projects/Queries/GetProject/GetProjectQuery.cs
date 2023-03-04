using MediatR;

namespace ProjectTracking.Application.Projects.Queries.GetProject
{
    public class GetProjectQuery : IRequest<ProjectVm>
    {
        public Guid Id { get; set; }
    }
}
