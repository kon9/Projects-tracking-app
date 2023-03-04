using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectTracking.Application.Employees.Commands.AssignEmployeeToProject;
using ProjectTracking.Application.Employees.Commands.CreateEmployee;
using ProjectTracking.Application.Employees.Commands.RemoveEmployeeFromProject;
using ProjectTracking.Application.Employees.Commands.UpdateEmployee;
using ProjectTracking.Application.Employees.Queries.GetEmployee;
using ProjectTracking.Web.Models;
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
            var query = new GetEmployeeQuery
            {
                Id = id,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateEmployeeDto createEmployeeDto)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(createEmployeeDto);
            var employeeId = await Mediator.Send(command);
            return Ok(employeeId);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateEmployeeDto updateEmployeeDto)
        {
            var command = _mapper.Map<UpdateEmployeeCommand>(updateEmployeeDto);
            await Mediator.Send(command);
            return NoContent();
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
