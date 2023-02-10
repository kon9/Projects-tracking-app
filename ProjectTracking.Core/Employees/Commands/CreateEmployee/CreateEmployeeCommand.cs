using MediatR;
using System;

namespace ProjectTracking.Core.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
