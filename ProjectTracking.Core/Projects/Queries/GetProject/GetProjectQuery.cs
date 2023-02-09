using MediatR;
using System;

namespace ProjectTracking.Core.Projects.Queries.GetProject
{
    public class GetProjectQuery : IRequest<ProjectVm>
    {
        public Guid Id { get; set; }
    }
}
