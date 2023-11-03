using System.Linq.Expressions;

namespace Data.Repositories.Contracts
{
    public interface IBaseRepository<T,TId> where T : class
    {
        IQueryable<T> Search(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        Task<T> GetByID(TId ID);
        Task<T> Add(T entity);
        T Update(TId ID, T entity);
        Task Delete(TId ID);
    }
}
