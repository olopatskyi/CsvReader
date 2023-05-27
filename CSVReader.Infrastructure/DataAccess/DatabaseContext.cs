using CSVReader.Domain.Entities;
using CSVReader.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSVReader.Infrastructure.DataAccess;

public class DatabaseContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<CsvFile> CsvFiles { get; set; }

    public DbSet<RowRecord> RowRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CsvFileConfiguration());
        builder.ApplyConfiguration(new RowRecordConfiguration());
        builder.ApplyConfiguration(new AppUserConfiguration());
        builder.ApplyConfiguration(new AppRoleConfiguration());
        builder.ApplyConfiguration(new UserRoleConfiguration());
        
        base.OnModelCreating(builder);
    }
}