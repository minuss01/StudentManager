using DATABASE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
