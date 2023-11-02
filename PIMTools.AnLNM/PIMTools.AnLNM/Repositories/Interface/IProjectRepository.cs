using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;

namespace PIMTools.AnLNM.Repositories.Interface
{
    public interface IProjectRepository
    {
        Task<PagedList<Project>> GetAllProjectAsync(PaginationParameter paginationParameter);
        Task<Project> GetProjectByIdAsync(int projectId);
        Task<int> AddProjectAsync(Project project);
        Task<int> UpdateProjectAsync(Project project);
        Task<int> DeleteProjectAsync(int projectId);
    }
}
