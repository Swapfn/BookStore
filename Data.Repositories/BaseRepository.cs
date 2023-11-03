using Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class BaseRepository<T, TId> : IBaseRepository<T, TId> where T : class
    {
        readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async virtual Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async virtual Task Delete(TId ID)
        {
            T entity = await GetByID(ID);
            if (entity != null)
                _context.Set<T>().Remove(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async virtual Task<T> GetByID(TId ID)
        {
            return await _context.Set<T>().FindAsync(ID);
        }

        public virtual IQueryable<T> Search(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }

        public virtual T Update(TId ID, T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
