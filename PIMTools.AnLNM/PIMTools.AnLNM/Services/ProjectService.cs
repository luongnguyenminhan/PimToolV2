using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;
using PIMTools.AnLNM.Repositories;

namespace PIMTools.AnLNM.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _service;

        public ProjectService(IProjectRepository service) 
        {
            _service = service;
        }
        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _service.GetProjectByIdAsync(id);
        }

        public async Task<PagedList<Project>> GetAllProjectAsync(PaginationParameter paginationParameter)
        {
            return await _service.GetAllProjectAsync(paginationParameter);
        }

        public async Task<int> AddProjectAsync(Project project)
        {
            return await _service.AddProjectAsync(project);
        }

        public async Task<int> UpdateProjectAsync(Project project)
        {
            return await _service.UpdateProjectAsync(project);
        }

        public async Task<int> DeleteProjectAsync(int id)
        {
            return await _service.DeleteProjectAsync(id);
        }
    }
}
