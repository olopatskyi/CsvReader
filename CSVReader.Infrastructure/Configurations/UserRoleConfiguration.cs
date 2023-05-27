using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSVReader.Infrastructure.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.ToTable("UsersRoles");
        
        builder.HasData(new List<IdentityUserRole<Guid>>()
        {
            new()
            {
                RoleId = Guid.Parse("313f353f-2ac2-4e56-9904-8826767b9c6a"),
                UserId = Guid.Parse("21789e0e-1737-4545-862d-fc3fbae3bc6d"),
            }
        });
    }
}