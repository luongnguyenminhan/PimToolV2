using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;

namespace PIMTools.AnLNM.Repositories.Interface
{
    public interface IGroupRepository
    {
        Task<PagedList<Group>> GetAllGroupsAsync(PaginationParameter paginationParameter);

    }
}
