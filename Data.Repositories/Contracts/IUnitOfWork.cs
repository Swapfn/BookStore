namespace Data.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}
