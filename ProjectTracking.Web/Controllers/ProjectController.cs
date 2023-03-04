using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectTracking.Application.Projects.Commands.CreateProject;
using ProjectTracking.Application.Projects.Commands.UpdateProject;
using ProjectTracking.Application.Projects.Queries.GetProject;
using ProjectTracking.Application.Projects.Queries.GetProjectsList;
using ProjectTracking.Web.Models;
using System;
using System.Threading.Tasks;

namespace ProjectTracking.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProjectController : BaseController
    {
        private readonly IMapper _mapper;
        public ProjectController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<ProjectListVm>> GetAll()
        {
            var query = new GetProjectListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        public async Task<ActionResult<ProjectVm>> Get(Guid id)
        {
            var query = new GetProjectQuery { Id = id, };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateProjectDto createProjectDto)
        {
            var command = _mapper.Map<CreateProjectCommand>(createProjectDto);
            var projectId = await Mediator.Send(command);
            return Ok(projectId);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProjectDto updateProjectDto)
        {
            var command = _mapper.Map<UpdateProjectCommand>(updateProjectDto);
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
