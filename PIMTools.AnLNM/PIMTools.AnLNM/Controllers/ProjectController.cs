using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;
using PIMTools.AnLNM.Services;

namespace PIMTools.AnLNM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects([FromQuery] PaginationParameter paginationParameter)
        {
            var pros = await _projectService.GetAllProjectAsync(paginationParameter);
            var metadata = new
            {
                pros.TotalCount,
                pros.PageSize,
                pros.CurrentPage,
                pros.TotalPages,
                pros.HasNext,
                pros.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return pros != null ? Ok(pros) : NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var pros = await _projectService.GetProjectByIdAsync(id);
            return pros != null ? Ok(pros) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddProjectAsync(Project project)
        {
            var pros = await _projectService.GetProjectByIdAsync((int)project.Id);
            return pros != null ? Ok(pros) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProject(Project project)
        {
            var emp = await _projectService.GetProjectByIdAsync((int)project.Id);
            return emp != null ? Ok(emp) : BadRequest();
        }
    }
}
