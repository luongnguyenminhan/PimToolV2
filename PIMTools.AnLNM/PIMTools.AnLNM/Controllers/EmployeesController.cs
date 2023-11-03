using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;
using PIMTools.AnLNM.Services.Interface;

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
        public async Task<IActionResult> GetAllEmployeesAsync([FromQuery] PaginationParameter paginationParameter) 
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesByIdAsync(int id)
        {
            try
            {
            var emps = await _employeeService.GetEmployeeByIdAsync(id);
            return emps != null ? Ok(emps) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync(Employee employee)
        {
            try
            {
            var emps = await _employeeService.GetEmployeeByIdAsync((int)employee.Id); 
            return emps != null ? Ok(emps) : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
            var emp = await _employeeService.GetEmployeeByIdAsync((int)employee.Id);
            return emp != null ? Ok(emp) : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            try
            {
            var emp = await _employeeService.DeleteEmployeeAsync(id);
            return emp != null ? Ok(emp) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
