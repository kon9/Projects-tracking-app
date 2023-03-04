
using ProjectTracking.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTracking.Core.Models
{
    public class Project : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string ProjectName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string CustomerCompanyName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string PerformerCompanyName { get; set; }

        [Range(0, 100, ErrorMessage = "Invalid priority")]
        public int ProjectPriority { get; set; }

        public Guid ProjectManagerId { get; set; }

        public List<ProjectTask> ProjectTasks { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EndDate { get; set; } = null;

    }
}
