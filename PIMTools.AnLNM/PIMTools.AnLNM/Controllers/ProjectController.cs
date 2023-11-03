using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;
using PIMTools.AnLNM.Services.Interface;

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
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectByIdAsync(int id)
        {
            try
            {
                var pros = await _projectService.GetProjectByIdAsync(id);
                return pros != null ? Ok(pros) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProjectAsync(Project project)
        {
            try
            {
                var pros = await _projectService.GetProjectByIdAsync((int)project.Id);
                return pros != null ? Ok(pros) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProjectAsync(Project project)
        {
            try
            {
                var emp = await _projectService.GetProjectByIdAsync((int)project.Id);
                return emp != null ? Ok(emp) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProjectAsync(int id)
        {
            try
            {
                var pro = await _projectService.DeleteProjectAsync(id);
                return pro == null ? NotFound() : Ok(pro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
