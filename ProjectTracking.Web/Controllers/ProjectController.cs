using Microsoft.AspNetCore.Mvc;
using ProjectTracking.Core.Projects.Queries.GetProjectsList;
using System.Threading.Tasks;

namespace ProjectTracking.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ProjectListVm>> GetAll()
        {
            var query = new GetProjectListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /*[HttpPost]
        public IActionResult Create(ProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var project = new Project
            {
                Id = Guid.NewGuid(),
                ProjectName = model.Name,
                CustomerCompanyName = model.CustomerCompanyName,
                PerformerCompanyName = model.PerformerCompanyName,
                ProjectManagerId = model.ProjectManagerId,
                CreationDate = model.CreationDate,
                ProjectPriority = model.ProjectPriority,
                CompletionDate = model.CompletionDate,
            };


            _projectWriteService.Create(project);

            return RedirectToAction(nameof(Index));
        }*/
    }
}
