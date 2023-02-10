using MediatR;
using System;

namespace ProjectTracking.Core.Employees.Commands.AssignEmployeeToProject
{
    public class AssignEmployeeToProjectCommand : IRequest
    {
        public Guid EmployeeId;
        public Guid ProjectId;
    }
}
