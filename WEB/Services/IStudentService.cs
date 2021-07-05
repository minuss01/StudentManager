using System.Collections.Generic;
using System.Threading.Tasks;
using WEB.DTOs.Student;

namespace WEB.Services
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetList();
        Task Create(StudentCreateDto form);
        Task CreateRange(List<StudentFromFileDto> list);
        Task Update(StudentEditDto form);
        Task Delete(int id);
        Task<StudentEditDto> GetByIdForFrom(int id);
    }
}
