using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;
using PIMTools.AnLNM.Services;

namespace PIMTools.AnLNM.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService) 
        { 
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees([FromQuery] PaginationParameter paginationParameter) 
        { 
            var emps = await _employeeService.GetEmployeeListAsync(paginationParameter);
            var metadata = new
            {
                emps.TotalCount,
                emps.PageSize,
                emps.CurrentPage,
                emps.TotalPages,
                emps.HasNext,
                emps.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return emps != null ? Ok(emps) : NotFound();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesById(int id)
        {
            var emps = await _employeeService.GetEmployeeByIdAsync(id);
            return emps != null ? Ok(emps) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync(Employee employee)
        {
            var emps = await _employeeService.GetEmployeeByIdAsync((int)employee.Id); 
            return emps != null ? Ok(emps) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync((int)employee.Id);
            return emp != null ? Ok(emp) : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var emp = await _employeeService.DeleteEmployeeAsync(id);
            return emp != null ? Ok(emp) : NotFound();
        }
    }
}
