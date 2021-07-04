using DATABASE.Entities;

namespace DATABASE.Repositories
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(Context context)
            : base(context)
        {
        }
    }
}
