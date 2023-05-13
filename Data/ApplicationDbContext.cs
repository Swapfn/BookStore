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
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure Identity
            builder.Entity<ApplicationUser>().HasMany(ur => ur.UserRoles).WithOne(u => u.User).HasForeignKey(u => u.UserId).IsRequired();
            builder.Entity<ApplicationRole>().HasMany(ur => ur.UserRoles).WithOne(r => r.Role).HasForeignKey(r => r.RoleId).IsRequired();
            // Seed Data
            builder.ApplyConfiguration(new UsersConfiguration());
            builder.ApplyConfiguration(new RolesConfiguration());
            builder.ApplyConfiguration(new UsersRolesConfiguration());
        }
    }
}
