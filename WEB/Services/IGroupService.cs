using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB.DTOs.Group;

namespace WEB.Services
{
    public interface IGroupService
    {
        Task<List<SelectListItem>> GetOptions();
        Task<List<GroupDto>> GetList();
        Task Create(GroupCreateDto form);
        Task Update(GroupEditDto form);
        Task Delete(int id);
        Task<List<string>> GetListOfNamesByTeacherId(int teacherId);
        Task<GroupEditDto> GetByIdForFrom(int id);
        Task<bool> GroupExists(int id);
        Task<int> CreatePlugIfNotExists();
    }
}
