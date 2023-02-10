using MediatR;
using System;

namespace ProjectTracking.Core.Employees.Queries.GetEmployee
{
    public class GetEmployeeQuery : IRequest<EmployeeVm>
    {
        public Guid Id { get; set; }
    }
}
