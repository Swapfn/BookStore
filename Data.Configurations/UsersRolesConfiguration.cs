using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Data.Configurations
{
    public class UsersRolesConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            var usersroles = new List<ApplicationUserRole>
            {
                new ApplicationUserRole
                {
                    UserId = 1,
                    RoleId = 1,
                }
            };
            builder.HasData(usersroles);
        }
    }
}
