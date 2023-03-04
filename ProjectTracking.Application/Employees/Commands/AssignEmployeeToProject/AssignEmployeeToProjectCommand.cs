using MediatR;

namespace ProjectTracking.Application.Employees.Commands.AssignEmployeeToProject
{
    public class AssignEmployeeToProjectCommand : IRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
