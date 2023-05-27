using CSVReader.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSVReader.Infrastructure.Configurations;

public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.ToTable("Roles");

        builder.HasData(new List<AppRole>()
        {
            new AppRole()
            {
                Id = Guid.Parse("313f353f-2ac2-4e56-9904-8826767b9c6a"),
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            
        });
    }
}