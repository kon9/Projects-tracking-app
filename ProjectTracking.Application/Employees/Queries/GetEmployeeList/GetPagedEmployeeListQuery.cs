using MediatR;
using ProjectTracking.Application.Employees.Queries.GetEmployee;
using ProjectTracking.Application.Infrastructure.Helpers;

namespace ProjectTracking.Application.Employees.Queries.GetEmployeeList;

public class GetPagedEmployeeListQuery : QueryStringParameters, IRequest<PagedList<EmployeeVm>>
{
    public GetPagedEmployeeListQuery()
    {
        OrderBy = "Name";
    }
}