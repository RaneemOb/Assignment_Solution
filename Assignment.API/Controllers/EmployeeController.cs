using Assignment.Core.Models;
using Assignment.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

       
        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<List<Employees>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        
        [HttpPost("InsertEmployee")]
        public async Task<ActionResult> InsertEmployee([FromBody] Employees employee)
        {
            var success = await _employeeService.InsertEmployee( employee.FirstName, employee.LastName, employee.JobTitle, employee.Department, employee.Salary);

            if (success)
                return Ok("Employee added successfully.");
            else
                return BadRequest("Failed to add employee.");
        }

        
        [HttpPut]
        [Route("UpdateEmployee/{employeeId}")]
        public async Task<ActionResult> UpdateEmployee(int employeeId, [FromBody] Employees employee)
        {
            var success = await _employeeService.UpdateEmployee(employeeId, employee.FirstName, employee.LastName, employee.JobTitle, employee.Department, employee.Salary);

            if (success)
                return Ok("Employee updated successfully.");
            else
                return NotFound("Employee not found or update failed.");
        }

        
        [HttpDelete]
        [Route("DeleteEmployee/{employeeId}")]
        public async Task<ActionResult> DeleteEmployee(int employeeId)
        {
            var success = await _employeeService.DeleteEmployee(employeeId);

            if (success)
                return Ok("Employee deleted successfully.");
            else
                return NotFound("Employee not found or deletion failed.");
        }
    }
}
