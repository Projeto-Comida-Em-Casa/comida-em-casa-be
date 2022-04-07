using ComidaEmCasa.Core.Repository.Interface;
using ComidaEmCasa.Model.Info;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComidaEmCasa.Core.Repository
{
    public abstract class AbstractRepositoryBase<T> : IRepositoryBase<T> where T : BaseInfo
    {
        internal readonly DbSet<T> _dbSet;
        internal readonly DbContext _context;

        public AbstractRepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public virtual async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task<T> Get(int id)
        {
            T info = await _dbSet.FirstOrDefaultAsync(entity => entity.Id.Equals(id));
            return info;
        }
        public IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
        public virtual async Task<int> Insert(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
        public virtual Task<List<T>> List()
        {
            return _dbSet.ToListAsync();
        }
        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
