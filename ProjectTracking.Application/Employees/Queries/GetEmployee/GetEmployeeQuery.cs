using MediatR;

namespace ProjectTracking.Application.Employees.Queries.GetEmployee
{
    public class GetEmployeeQuery : IRequest<EmployeeVm>
    {
        public Guid Id { get; set; }
    }
}
