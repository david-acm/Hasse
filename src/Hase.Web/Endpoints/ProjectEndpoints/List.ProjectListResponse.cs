using System.Collections.Generic;
using Hase.Core.ProjectAggregate;

namespace Hase.Web.Endpoints.ProjectEndpoints
{
    public class ProjectListResponse
    {
        public List<ProjectRecord> Projects { get; set; } = new();
    }
}
