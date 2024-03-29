﻿using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Data.Repository;

public class ProjectTasksRepo : BaseRepo<ProjectTask>, IProjectTaskRepo
{
    public ProjectTasksRepo(ProjectsDbContext context) : base(context)
    {
        Table = Context.ProjectTasks;
    }
}