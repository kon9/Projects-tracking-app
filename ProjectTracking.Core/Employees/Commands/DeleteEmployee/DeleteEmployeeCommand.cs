using MediatR;
using System;

namespace ProjectTracking.Core.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
