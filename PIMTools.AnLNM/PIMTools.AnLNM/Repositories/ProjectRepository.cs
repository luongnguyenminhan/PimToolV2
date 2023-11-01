using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;

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
            var pros = await _context.Projects.ToListAsync();

            return PagedList<Project>.ToPagedList(pros,
                paginationParameter.PageNumber,
                paginationParameter.PageSize);
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            if (_context == null)
            {
                return null;
            }
            return _context.Projects.SingleOrDefault(e => e.Id == projectId);
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
    }
}
