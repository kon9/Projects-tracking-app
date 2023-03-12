namespace ProjectTracking.Application.Projects.Models
{
    public class CreateProjectDto
    {
        public string ProjectName { get; set; }
        public string CustomerCompanyName { get; set; }
        public string PerformerCompanyName { get; set; }
        public int ProjectPriority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;
    }
}
