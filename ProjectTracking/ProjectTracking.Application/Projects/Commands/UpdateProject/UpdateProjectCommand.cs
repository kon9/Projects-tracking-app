﻿using MediatR;

namespace ProjectTracking.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string CustomerCompanyName { get; set; }
        public string PerformerCompanyName { get; set; }
        public int ProjectPriority { get; set; }
        public Guid ProjectManagerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;

    }
}
