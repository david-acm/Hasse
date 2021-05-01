using System.Collections.Generic;
using Hasse.Core.ProjectAggregate;

namespace Hasse.Web.Endpoints.ProjectEndpoints
{
    public class ProjectListResponse
    {
        public List<ProjectRecord> Projects { get; set; } = new();
    }
}
