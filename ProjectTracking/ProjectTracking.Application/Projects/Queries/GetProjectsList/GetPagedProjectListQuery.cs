﻿using MediatR;
using ProjectTracking.Application.Infrastructure.Helpers;

namespace ProjectTracking.Application.Projects.Queries.GetProjectsList;

public class GetPagedProjectListQuery : QueryStringParameters, IRequest<PagedList<ProjectViewModel>>
{
    public GetPagedProjectListQuery()
    {
        OrderBy = "ProjectPriority";
    }
    public DateTime MinYearOfStart { get; set; } = new DateTime(2000, 1, 1);
    public DateTime MaxYearOfStart { get; set; } = DateTime.Now;
    public int MinPriority { get; set; }

    public bool ValidYearRange => MaxYearOfStart > MinYearOfStart;
}