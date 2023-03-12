using ProjectTracking.Core.Models;

namespace ProjectTracking.Application.Projects.Queries.GetProject
{
    public class ProjectVm
    {
        public string ProjectName { get; set; }
        public string CustomerCompanyName { get; set; }
        public string PerformerCompanyName { get; set; }
        public int ProjectPriority { get; set; }
        public Guid ProjectManagerId { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;

    }
}
