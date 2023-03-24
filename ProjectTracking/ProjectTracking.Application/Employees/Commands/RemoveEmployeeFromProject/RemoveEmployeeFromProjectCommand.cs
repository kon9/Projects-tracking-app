using MediatR;

namespace ProjectTracking.Application.Employees.Commands.RemoveEmployeeFromProject
{
    public class RemoveEmployeeFromProjectCommand : IRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
