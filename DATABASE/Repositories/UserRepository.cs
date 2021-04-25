using DATABASE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATABASE.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(Context context)
            : base(context)
        {
        }
    }
}
