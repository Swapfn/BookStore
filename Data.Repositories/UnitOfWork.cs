using Data.Repositories.Contracts;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Dispose() => _context.Dispose();

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
