using System.Collections.Generic;

namespace ProjectTracking.Core.Projects.Queries.GetProjectsList
{
    public class ProjectListVm
    {
        public IList<ProjectLookupDto> Projects { get; set; }
    }
}
