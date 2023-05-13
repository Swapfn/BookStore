using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Data.Configurations
{
    public class RolesConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            var roles = new List<ApplicationRole>
            {
                new ApplicationRole
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                 new ApplicationRole
                {
                    Id = 2,
                    Name = "User",
                    NormalizedName = "USER",
                },
            };
            builder.HasData(roles);
        }
    }
}
