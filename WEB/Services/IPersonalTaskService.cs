using System.Collections.Generic;

using System.Threading.Tasks;
using WEB.DTOs.PersonalTask;

namespace WEB.Services
{
    public interface IPersonalTaskService
    {
        Task<List<PersonalTaskDto>> GetList();
        Task ChangeState(int id);
        Task Delete(int id);
        Task Create(string content);
    }
}
