using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;
using PIMTools.AnLNM.Repositories.Interface;
using System.Data;

namespace PIMTools.AnLNM.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly PimtoolContext _context;

        public GroupRepository(PimtoolContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Group>> GetAllGroupsAsync(PaginationParameter paginationParameter)
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
            var groups = await _context.Groups
                      .FromSqlRaw($"exec GetGroupsPageByPageNumber {paginationParameter.PageNumber}, {paginationParameter.PageSize}, @row OUTPUT", param)
                      .ToListAsync();
            int countTotal = (int)param.Value;
            return PagedList<Group>.ToPagedList(groups, countTotal,
                paginationParameter.PageNumber,
                paginationParameter.PageSize);
        }
    }
}
