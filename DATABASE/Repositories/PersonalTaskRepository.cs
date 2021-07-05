using DATABASE.Entities;

namespace DATABASE.Repositories
{
    public class PersonalTaskRepository : RepositoryBase<PersonalTask>, IPersonalTaskRepository
    {
        public PersonalTaskRepository(Context context)
            : base(context)
        {
        }
    }
}
