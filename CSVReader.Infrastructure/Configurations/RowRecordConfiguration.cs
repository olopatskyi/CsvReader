using CSVReader.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSVReader.Infrastructure.Configurations;

public class RowRecordConfiguration : IEntityTypeConfiguration<RowRecord>
{
    public void Configure(EntityTypeBuilder<RowRecord> builder)
    {
        builder.ToTable("Records");

        builder.Property(x => x.Salary)
            .HasPrecision(10, 5);
        
        builder.HasOne(x => x.CsvFile)
            .WithMany(x => x.RowRecords)
            .HasForeignKey(x => x.CsvFileId);
    }
}