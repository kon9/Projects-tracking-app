using MediatR;
using ProjectTracking.Application.Employees.Queries.GetEmployee;

namespace ProjectTracking.Application.Projects.Queries.GetEmployeesOnProject
{
    public class GetEmployeesOnProjectQuery : IRequest<EmployeeVm>
    {
        public Guid Id { get; set; }
    }
}
