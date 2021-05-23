using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hasse.Core.ProjectAggregate;
using Hasse.Core.ProjectAggregate.Specifications;
using Hasse.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hasse.Web.Pages.ProjectDetails
{
    public class IncompleteModel : PageModel
    {
        private readonly IRepository<Project> _repository;

        public IncompleteModel(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public List<ToDoItem> ToDoItems { get; set; }

        public async Task OnGetAsync()
        {
            var projectSpec = new ProjectByIdWithItemsSpec(1); // TODO: get from route
            var project = await _repository.GetBySpecAsync(projectSpec);
            var spec = new IncompleteItemsSpec();

            ToDoItems = spec.Evaluate(project.Items).ToList();
        }
    }
}