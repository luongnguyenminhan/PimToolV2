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
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupsService;

        public GroupsController(IGroupService groupsService)
        {
            _groupsService = groupsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGroups([FromQuery] PaginationParameter paginationParameter)
        {
            var groups = await _groupsService.GetAllGroupsAsync(paginationParameter);
            var metadata = new
            {
                groups.TotalCount,
                groups.PageSize,
                groups.CurrentPage,
                groups.TotalPages,
                groups.HasNext,
                groups.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return groups != null ? Ok(groups) : NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            var groups = await _groupsService.GetGroupByIdAsync(id);
            return groups != null ? Ok(groups) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddGroupAsync(Group group)
        {
            var groups = await _groupsService.GetGroupByIdAsync((int)group.Id);
            return groups != null ? Ok(groups) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGroupAsync(Project group)
        {
            var emp = await _groupsService.GetGroupByIdAsync((int)group.Id);
            return emp != null ? Ok(emp) : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteGroupAsync(int id)
        {
            var pro = await _groupsService.DeleteGroupAsync(id);
            return pro != null ? Ok(pro) : NotFound();
        }
    }
}
