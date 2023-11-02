using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;
using System.Data;
using System.Drawing.Printing;

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
            var param = new SqlParameter
            {
                ParameterName = "@row",
                DbType = DbType.Int32,
                Direction = System.Data.ParameterDirection.Output
            };
            var emps = await _context.Employees
                      .FromSqlRaw($"exec GetEmployeesPageByPageNumber {paginationParameter.PageNumber}, {paginationParameter.PageSize}, @row OUTPUT", param)
                      .ToListAsync();
            int countTotal = (int)param.Value;
            return PagedList<Employee>.ToPagedList(emps,countTotal,
                paginationParameter.PageNumber,
                paginationParameter.PageSize);
        }

            public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            if (_context == null)
            {
                return null;
            }
            else
            {
                var emps = _context.Employees.SingleOrDefault(e => e.Id == employeeId && e.IsExist.Equals("YES"));
                return emps;
            }
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

        public async Task<int> DeleteEmployeeAsync(int employeeId)
        {
            if (_context == null)
            {
                return 0;
            }
            var emps = _context.Employees.SingleOrDefault(e => e.Id == employeeId && e.IsExist.Equals("YES"));
            if (emps  == null || emps.IsExist.Equals("NO"))
            {
                return 0;
            }
            emps.IsExist = "NO";
            _context.Employees.Update(emps);
            await _context.SaveChangesAsync();
            return (int)employeeId;
        }
    }
}
