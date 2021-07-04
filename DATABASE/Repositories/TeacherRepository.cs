using DATABASE.Entities;

namespace DATABASE.Repositories
{
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(Context context)
            : base(context)
        {
        }
    }
}
