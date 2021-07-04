using System.Collections.Generic;
using System.Threading.Tasks;
using WEB.DTOs.Student;

namespace WEB.Services
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetList();
        Task GetById(int id);
        Task Create(StudentCreateDto form);
        Task Update(StudentEditDto form);
        Task Delete(int id);
        Task<StudentEditDto> GetByIdForFrom(int id);
    }
}
