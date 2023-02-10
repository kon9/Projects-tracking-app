using MediatR;
using System;

namespace ProjectTracking.Core.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
