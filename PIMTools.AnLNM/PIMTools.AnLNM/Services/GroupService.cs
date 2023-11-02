using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;
using PIMTools.AnLNM.Repositories.Interface;
using PIMTools.AnLNM.Services.Interface;

namespace PIMTools.AnLNM.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _service;


        public GroupService(IGroupRepository service)
        {
            _service = service;
        }
        public async Task<PagedList<Group>> GetAllGroupsAsync(PaginationParameter paginationParameter)
        {
            return await _service.GetAllGroupsAsync(paginationParameter);
        }
    }
}
