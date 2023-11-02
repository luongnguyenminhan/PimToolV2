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
        public async Task<Group> GetGroupByIdAsync(int id)
        {
            return await _service.GetGroupByIdAsync(id);
        }
        public async Task<int> AddGroupAsync(Group group)
        {
            return await _service.AddGroupAsync(group);
        }
        public async Task<int> UpdateGroupAsync(Group group)
        {
            return await _service.UpdateGroupAsync(group);
        }

        public async Task<int> DeleteGroupAsync(int id)
        {
            return await _service.DeleteGroupAsync(id);
        }



    }
}
