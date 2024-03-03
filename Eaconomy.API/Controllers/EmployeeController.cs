using Eaconomy.Application.DTO.Employee;
using Eaconomy.Application.Features.Employee.Requests.Commands;
using Eaconomy.Application.Features.Employee.Requests.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eaconomy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Employee")]
    public class EmployeeController : ProjectBaseController
    {
        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employees = await Mediatr.Send(new GetEmployeeListRequest());
            return Ok(employees);
        }
        [HttpGet("{id}")]
        //[Route("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await Mediatr.Send(new GetEmployeeRequest() { EmployeeId = id });
            return Ok(employee);
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDTO employee)
        {
            var response = await Mediatr.Send(new CreateEmployeeCommand() { CreateEmployeeDTO = employee});
            return Ok(response);
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDTO employee)
        {
            var response = await Mediatr.Send(new UpdateEmployeeCommand() { EmployeeDTO = employee });
            return Ok(response);
        }
        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            var response = await Mediatr.Send(new DeleteEmployeeCommand() { EmployeeId = employeeId });
            return Ok(response);
        }

    }
}


