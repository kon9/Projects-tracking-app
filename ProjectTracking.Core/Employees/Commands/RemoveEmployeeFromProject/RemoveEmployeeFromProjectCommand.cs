using MediatR;
using System;

namespace ProjectTracking.Core.Employees.Commands.RemoveEmployeeFromProject
{
    public class RemoveEmployeeFromProjectCommand : IRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
