using PIMTools.AnLNM.Helper;
using PIMTools.AnLNM.Models;
using System.Threading.Tasks;

namespace PIMTools.AnLNM.Services.Interface
{
    public interface IGroupService
    {
        Task<PagedList<Group>> GetAllGroupsAsync(PaginationParameter paginationParameter);
    }
}
