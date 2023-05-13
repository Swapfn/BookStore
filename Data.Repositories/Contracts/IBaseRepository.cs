using System.Linq.Expressions;

namespace Data.Repositories.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Search(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        T GetByID(int ID);
        T Add(T entity);
        T Update(int ID, T entity);
        void Delete(int ID);
    }
}
