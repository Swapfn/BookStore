using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Data.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = 1,
                    UserName = "string",
                    NormalizedUserName = "STRING",
                    FirstName = "string",
                    LastName = "string",
                    Email = "string",
                    TenantId = "3E090B05-5C07-49E9-968B-83E73CFA2E0E",
                    TenantName = "string",
                    SecurityStamp = "74A23521-DE60-4063-BD50-74EF88A9C24F",
                    RegisterationDate = DateTime.UtcNow,
                    LastLogin  = DateTime.UtcNow,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "string"),
                },
                
            };
            builder.HasData(users);
        }
    }
}
