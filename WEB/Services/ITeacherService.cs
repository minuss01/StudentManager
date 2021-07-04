using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB.DTOs.Teacher;

namespace WEB.Services
{
    public interface ITeacherService
    {
        Task<List<TeacherDto>> GetList();
        Task GetById(int id);
        Task Create(TeacherCreateDto form);
        Task Update(TeacherEditDto form);
        Task Delete(int id);
        Task<List<SelectListItem>> GetOptions();
        Task<TeacherEditDto> GetByIdForFrom(int id);
    }
}
