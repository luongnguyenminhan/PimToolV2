using Microsoft.CodeAnalysis;
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
        public async Task<Group> GetGroupByIdAsync(int groupId)
        {

            if (_context == null)
            {
                return null;
            }
            else
            {
                var groups = _context.Groups.SingleOrDefault(e => e.Id == groupId && e.IsExist.Equals("YES"));
                return groups;
            }
        }

        public async Task<int> AddGroupAsync(Group group)
        {
            if (_context.Groups == null)
            {
                return 0;
            }
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return (int)group.Id;
        }
        public async Task<int> UpdateGroupAsync(Group group)
        {
            if (_context.Projects.SingleOrDefault(p => p.Id == group.Id) == null)
            {
                return 0;
            }
            group.Version += 1;
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
            return (int)group.Id;
        }

        public async Task<int> DeleteGroupAsync(int groupId)
        {
            if (_context == null)
            {
                return 0;
            }
            var groups = _context.Groups.SingleOrDefault(e => e.Id == groupId && e.IsExist.Equals("YES"));
            if (groups == null || groups.IsExist.Equals("NO"))
            {
                return 0;
            }
            groups.IsExist = "NO";
            _context.Groups.Update(groups);
            await _context.SaveChangesAsync();
            return (int)groupId;
        }

    }
}
