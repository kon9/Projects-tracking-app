using ProjectTracking.Core.Models;

namespace ProjectTracking.Data.Repository;

public class EmployeeRepo : BaseRepo<Employee>
{
    public EmployeeRepo(ProjectsDbContext context) : base(context)
    {
        Table = Context.Employees;
    }
}