using System.Linq;
using System.Threading.Tasks;
using Hasse.Core;
using Hasse.Web.ApiModels;
using Hasse.Core.ProjectAggregate;
using Hasse.Core.ProjectAggregate.Specifications;
using Hasse.SharedKernel.Interfaces;
using Hasse.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hasse.Web.Controllers
{
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private readonly IRepository<Project> _projectRepository;

        public ProjectController(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET project/{projectId?}
        [HttpGet("{projectId:int}")]
        public async Task<IActionResult> Index(int projectId = 1)
        {
            var spec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _projectRepository.GetBySpecAsync(spec);

            var dto = new ProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                Items = project.Items
                            .Select(item => ToDoItemViewModel.FromToDoItem(item))
                            .ToList()
            };
            return View(dto);
        }
    }
}
