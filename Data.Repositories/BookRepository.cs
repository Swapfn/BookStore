using Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context, ITenantService tenant) : base(context)
        {
            Context = context;
            Tenant = tenant;
        }

        public ApplicationDbContext Context { get; }
        public ITenantService Tenant { get; }

        //public override IQueryable<Book> GetAll()
        //{

        //        var c  = Context.Books.Where(c => c.TenantId.ToLower().Equals(Tenant.TenantId)).AsNoTracking();
        //    var t = c.ToList();
        //    return c;
        //}
    }
}