using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;
using PIMTools.AnLNM.Repositories.Interface;
using PIMTools.AnLNM.Services.Interface;

namespace PIMTools.AnLNM.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeesRepository _service;

        public EmployeeService(IEmployeesRepository service) 
        {
            _service = service;
        }

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            return await _service.AddEmployeeAsync(employee);
        }


        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _service.GetEmployeeByIdAsync(id);
        }

        public async Task<PagedList<Employee>> GetEmployeeListAsync(PaginationParameter paginationParameter)
        {
            return await _service.GetAllEmnployeesAsync(paginationParameter);
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            return await _service.UpdateEmployeeAsync(employee);
        }
        public async Task<int> DeleteEmployeeAsync(int id)
        {
            return await _service.DeleteEmployeeAsync(id);
        }
    }
}
