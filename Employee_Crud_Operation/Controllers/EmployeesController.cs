using Employee_Crud_Operation.Data.Models.ViewModels;
using Employee_Crud_Operation.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Crud_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public EmployeesService _employeesService;
        public EmployeesController(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet("get-all-employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var allEmployees = await _employeesService.GetAllEmployees();
            return Ok(allEmployees);
        }

        [HttpGet("get-employee-by-id/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeesService.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpPost("add-employee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeVM employee)
        {
            await _employeesService.AddEmployee(employee);
            return Ok();
        }

        [HttpPut("update-employee-by-id/{id}")]
        public async Task<IActionResult> UpdateEmployeeById(int id, [FromBody] EmployeeVM employee)
        {
            var UpdatedEmployee = await _employeesService.UpdateEmployeeById(id, employee);
            return Ok(UpdatedEmployee);
        }

        [HttpDelete("delete-employee-by-id/{id}")]
        public async Task<IActionResult> DeleteEmployeeById(int id)
        {
            await _employeesService.DeleteEmployeeById(id);
            return Ok();
        }
    }
}

