using Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public  virtual T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public virtual void Delete(int ID)
        {
            T entity = GetByID(ID);
            if (entity != null)
                _context.Set<T>().Remove(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public virtual T GetByID(int ID)
        {
            return _context.Set<T>().Find(ID);
        }

        public virtual IQueryable<T> Search(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }

        public virtual T Update(int ID, T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
