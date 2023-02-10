using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectTracking.Core.Employees.Commands.CreateEmployee;
using ProjectTracking.Core.Employees.Queries.GetEmployee;
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
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(createEmployeeDto);
            var employeeId = await Mediator.Send(command);
            return Ok(employeeId);
        }
    }
}
