using DATABASE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
