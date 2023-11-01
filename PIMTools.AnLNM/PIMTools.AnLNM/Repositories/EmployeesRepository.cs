using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;

namespace PIMTools.AnLNM.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly PimtoolContext _context;

        public EmployeesRepository(PimtoolContext context)
        {
            _context = context;
        }
        public async Task<PagedList<Employee>> GetAllEmnployeesAsync(PaginationParameter paginationParameter)
        {
            if (_context == null)
            {
                return null;
            }
            var emps = await _context.Employees.ToListAsync();

            return PagedList<Employee>.ToPagedList(emps,
                paginationParameter.PageNumber,
                paginationParameter.PageSize);
        }

            public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            if (_context == null)
            {
                return null;
            }
            return _context.Employees.SingleOrDefault(e => e.Id == employeeId);
        }

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            if (_context.Employees.SingleOrDefault(e => e.Id == employee.Id) != null)
            {
                return 0;
            }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return (int)employee.Id;
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            if (_context.Employees.SingleOrDefault(e => e.Id == employee.Id) == null)
            {
                return 0;
            }
            employee.Version += 1;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return (int)employee.Id;
        }
    }
}
