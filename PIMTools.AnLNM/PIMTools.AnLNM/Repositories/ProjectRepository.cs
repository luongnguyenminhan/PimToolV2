using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;
using System.Data;

namespace PIMTools.AnLNM.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly PimtoolContext _context;

        public ProjectRepository(PimtoolContext context)
        {
            _context = context;
        }


        public async Task<PagedList<Project>> GetAllProjectAsync(PaginationParameter paginationParameter)
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
            var pros = await _context.Projects
                      .FromSqlRaw($"exec GetProjectPageByPageNumber {paginationParameter.PageNumber}, {paginationParameter.PageSize}, @row OUTPUT", param)
                      .ToListAsync();
            int countTotal = (int)param.Value;
            return PagedList<Project>.ToPagedList(pros,countTotal,
                paginationParameter.PageNumber,
                paginationParameter.PageSize);
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            if (_context == null)
            {
                return null;
            }
            else
            {
                var pros = _context.Projects.SingleOrDefault(e => e.Id == projectId && e.IsExist.Equals("YES"));
                return pros;
            }
        }
        public async Task<int> AddProjectAsync(Project project)
        {
            if (_context.Projects == null)
            {
                return 0;
            }
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return (int)project.Id;
        }

        public async Task<int> UpdateProjectAsync(Project project)
        {
            if (_context.Projects.SingleOrDefault(p => p.Id == project.Id) == null)
            {
                return 0;
            }
            project.Version += 1;
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return (int)project.Id;
        }

        public Task<int> DeleteProjectAsync(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
