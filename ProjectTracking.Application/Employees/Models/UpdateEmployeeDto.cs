namespace ProjectTracking.Application.Employees.Models
{
    public class UpdateEmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

}
