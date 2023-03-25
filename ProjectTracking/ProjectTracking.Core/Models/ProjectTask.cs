using ProjectTracking.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTracking.Core.Models
{
    public class ProjectTask : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string TaskName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(512)")]
        public string TaskDescription { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Invalid priority")]
        public int Priority { get; set; }

        [Required]
        public Guid TaskAuthorId { get; set; }
        public Guid TaskCompleterId { get; set; }
        public TaskStatus Status { get; set; }

    }
    public enum TaskStatus
    {
        ToDo, InProgress, Done
    }
}
