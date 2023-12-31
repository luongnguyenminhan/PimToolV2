﻿using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;

namespace PIMTools.AnLNM.Services.Interface
{
    public interface IProjectService
    {
        Task<PagedList<Project>> GetAllProjectAsync(PaginationParameter paginationParameter);
        Task<Project> GetProjectByIdAsync(int id);
        Task<int> AddProjectAsync(Project project);
        Task<int> UpdateProjectAsync(Project project);
        Task<int> DeleteProjectAsync(int id);
    }
}
