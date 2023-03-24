
using ProjectTracking.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjectTracking.Core.Models
{
    public class Employee : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string Surname { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Incorrect email")]
        [Column(TypeName = "nvarchar(128)")]
        public string Email { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();

        public List<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();

    }
}
