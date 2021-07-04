using DATABASE.Entities;

namespace DATABASE.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(Context context)
            : base(context)
        {
        }
    }
}
