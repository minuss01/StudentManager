using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DATABASE.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetQuery();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> GetCount();
        Task SaveChangesAsync();
    }
}
