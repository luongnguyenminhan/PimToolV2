using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;

namespace PIMTools.AnLNM.Repositories.Interface
{
    public interface IEmployeesRepository
    {
        Task<PagedList<Employee>> GetAllEmnployeesAsync(PaginationParameter paginationParameter);
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task<int> AddEmployeeAsync(Employee employee);
        Task<int> UpdateEmployeeAsync(Employee employee);
        Task<int> DeleteEmployeeAsync(int employeeId);

    }
}
