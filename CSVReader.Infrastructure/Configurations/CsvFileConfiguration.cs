using CSVReader.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSVReader.Infrastructure.Configurations;

public class CsvFileConfiguration : IEntityTypeConfiguration<CsvFile>
{
    public void Configure(EntityTypeBuilder<CsvFile> builder)
    {
        builder.ToTable("Files");

        builder.HasMany(x => x.RowRecords)
            .WithOne(x => x.CsvFile)
            .HasForeignKey(x => x.CsvFileId);
    }
}