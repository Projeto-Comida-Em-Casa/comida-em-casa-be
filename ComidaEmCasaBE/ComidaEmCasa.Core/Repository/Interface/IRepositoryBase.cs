using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComidaEmCasa.Core.Repository.Interface
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> List();
        Task<T> Get(int id);
        IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate);
        Task<int> Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
