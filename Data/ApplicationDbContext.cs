using Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, IdentityUserClaim<int>,
        ApplicationUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public readonly string _tenant;
        public ApplicationDbContext(DbContextOptions options, ITenantService tenantService) : base(options)
        {
            _tenant = tenantService.TenantId;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure Identity
            builder.Entity<ApplicationUser>().HasMany(ur => ur.UserRoles).WithOne(u => u.User).HasForeignKey(u => u.UserId).IsRequired();
            builder.Entity<ApplicationRole>().HasMany(ur => ur.UserRoles).WithOne(r => r.Role).HasForeignKey(r => r.RoleId).IsRequired();
            // Configure m->n relations
            builder.Entity<Book>().HasMany(b => b.BookAuthors).WithOne(b => b.Book).HasForeignKey(b => b.BookId);
            builder.Entity<Author>().HasMany(b => b.BookAuthors).WithOne(a => a.Author).HasForeignKey(a => a.AuthorId);
            builder.Entity<Book>().HasMany(b => b.BookReviews).WithOne(b => b.Book).HasForeignKey(b => b.BookId);
            builder.Entity<Review>().HasMany(b => b.BooksReviews).WithOne(r => r.Review).HasForeignKey(r => r.ReviewId);
            builder.Entity<Book>().HasMany(b => b.BookCategories).WithOne(b => b.Book).HasForeignKey(b => b.BookId);
            builder.Entity<Category>().HasMany(b => b.BookCategories).WithOne(c => c.Category).HasForeignKey(c => c.CategoryId);
            // Tenants Queryfilter
            //builder.Entity<ApplicationUser>().HasQueryFilter(a => a.TenantId == _tenant);
            builder.Entity<Book>().HasQueryFilter(a => a.TenantId == _tenant);
            builder.Entity<Author>().HasQueryFilter(a => a.TenantId == _tenant);
            builder.Entity<Category>().HasQueryFilter(a => a.TenantId == _tenant);
            builder.Entity<Review>().HasQueryFilter(a => a.TenantId == _tenant);
            // Seed Data
            builder.ApplyConfiguration(new UsersConfiguration());
            builder.ApplyConfiguration(new RolesConfiguration());
            builder.ApplyConfiguration(new UsersRolesConfiguration());

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

    }
}
