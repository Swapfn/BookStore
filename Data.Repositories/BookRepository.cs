using Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Data.Repositories
{
    public class BookRepository : BaseRepository<Book, int>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context, ITenantService tenant) : base(context)
        {
            Tenant = tenant;
        }
        public ITenantService Tenant { get; }
    }
}