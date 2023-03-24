using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectTracking.Application.Employees.Commands.AssignEmployeeToProject;
using ProjectTracking.Application.Employees.Commands.CreateEmployee;
using ProjectTracking.Application.Employees.Commands.RemoveEmployeeFromProject;
using ProjectTracking.Application.Employees.Commands.UpdateEmployee;
using ProjectTracking.Application.Employees.Models;
using ProjectTracking.Application.Employees.Queries.GetEmployee;
using System;
using System.Threading.Tasks;

namespace ProjectTracking.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : BaseController
    {

        private readonly IMapper _mapper;
        public EmployeeController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<EmployeeVm>> Get(Guid id)
        {
            var query = new GetEmployeeQuery { Id = id, };
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateEmployeeDto createEmployeeDto)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(createEmployeeDto);
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateEmployeeDto updateEmployeeDto)
        {
            var command = _mapper.Map<UpdateEmployeeCommand>(updateEmployeeDto);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> AssignEmployeeToProject(AssignEmployeeToProjectCommand assignEmployee)
        {
            await Mediator.Send(assignEmployee);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> RemoveEmployeeFromProject(RemoveEmployeeFromProjectCommand removeEmployeeCommand)
        {
            await Mediator.Send(removeEmployeeCommand);
            return Ok();
        }
    }
}
