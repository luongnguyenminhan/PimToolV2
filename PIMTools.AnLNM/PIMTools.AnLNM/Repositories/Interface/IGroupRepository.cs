using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;

namespace PIMTools.AnLNM.Repositories.Interface
{
    public interface IGroupRepository
    {
        Task<PagedList<Group>> GetAllGroupsAsync(PaginationParameter paginationParameter);
        Task<Group> GetGroupByIdAsync(int groupId);
        Task<int> AddGroupAsync(Group group);
        Task<int> UpdateGroupAsync(Group group);
        Task<int> DeleteGroupAsync(int groupId);
    }
}
