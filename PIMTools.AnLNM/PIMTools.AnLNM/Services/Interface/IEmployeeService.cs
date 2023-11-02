using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;

namespace PIMTools.AnLNM.Services.Interface
{
    public interface IEmployeeService
    {
        Task<PagedList<Employee>> GetEmployeeListAsync(PaginationParameter paginationParameter);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<int> AddEmployeeAsync(Employee employee);
        Task<int> UpdateEmployeeAsync(Employee employee);
        Task<int> DeleteEmployeeAsync(int id);
    }
}
