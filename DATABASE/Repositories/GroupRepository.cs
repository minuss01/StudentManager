using DATABASE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
