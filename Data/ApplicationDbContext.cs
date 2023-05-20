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
            _tenant = tenantService.TenantName;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure Identity
            builder.Entity<ApplicationUser>().HasMany(ur => ur.UserRoles).WithOne(u => u.User).HasForeignKey(u => u.UserId).IsRequired();
            builder.Entity<ApplicationRole>().HasMany(ur => ur.UserRoles).WithOne(r => r.Role).HasForeignKey(r => r.RoleId).IsRequired();
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

    }
}
