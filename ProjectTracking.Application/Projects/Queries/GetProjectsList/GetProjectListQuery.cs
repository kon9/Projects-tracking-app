using MediatR;

namespace ProjectTracking.Application.Projects.Queries.GetProjectsList;

public class GetProjectListQuery : IRequest<List<ProjectViewModel>>
{
    public string? SortBy { get; set; }
    public bool IsSortAscending { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }

    public string? Name { get; set; }
    public string? Customer { get; set; }
    public string? Performer { get; set; }
    public int? Priority { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

}