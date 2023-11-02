using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Services;
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
    }
}
