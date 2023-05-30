using CSVReader.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSVReader.Infrastructure.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("Users");

        PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
        
        builder.HasData(new List<AppUser>()
        {
            new AppUser()
            {
                Id = Guid.Parse("21789e0e-1737-4545-862d-fc3fbae3bc6d"),
                UserName = "john@example.com",
                NormalizedUserName = "JOHN@EXAMPLE.COM",
                Email = "john@example.com",
                NormalizedEmail = "JOHN@EXAMPLE.COM",
                EmailConfirmed = true,
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = true,
#pragma warning disable CS8625
                PasswordHash = passwordHasher.HashPassword(null, "admin"),
#pragma warning restore CS8625
                SecurityStamp = "YourSecurityStamp",
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            }
        });
    }
}