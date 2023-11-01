using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;

namespace PIMTools.AnLNM.Services
{
    public interface IProjectService
    {
        Task<PagedList<Project>> GetAllProjectAsync(PaginationParameter paginationParameter);
        Task<Project> GetProjectByIdAsync(int id);
        Task<int> AddProjectAsync(Project project);
        Task<int> UpdateProjectAsync(Project project);
    }
}
