using System.ComponentModel.DataAnnotations;

namespace ProjectTracking.Application.Projects.Models
{
    public class ProjectViewModelRename

    {
        [Required]
        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Customer Company Name")]
        public string CustomerCompanyName { get; set; }

        [Required]
        [Display(Name = "Performer Company Name")]
        public string PerformerCompanyName { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public int ProjectPriority { get; set; }

        [Required]
        [Display(Name = "Project Manager")]
        public Guid ProjectManagerId { get; set; }

        [Required]
        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Required]
        [Display(Name = "Completion Date")]
        [DataType(DataType.Date)]
        public DateTime CompletionDate { get; set; }

    }
}