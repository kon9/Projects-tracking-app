using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectTracking.Application.Projects.Commands.CreateProject;
using ProjectTracking.Application.Projects.Commands.UpdateProject;
using ProjectTracking.Application.Projects.Models;
using ProjectTracking.Application.Projects.Queries.GetProject;
using ProjectTracking.Application.Projects.Queries.GetProjectsList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectViewModel = ProjectTracking.Application.Projects.Queries.GetProjectsList.ProjectViewModel;

namespace ProjectTracking.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProjectController : BaseController
    {
        private readonly IMapper _mapper;
        public ProjectController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<List<ProjectViewModel>>> GetAll([FromQuery] GetProjectListQuery query)
        {
            return Ok(await Mediator.Send(query));
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
