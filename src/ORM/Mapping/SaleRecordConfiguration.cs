using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ORM.Mapping;

public class SaleRecordConfiguration : IEntityTypeConfiguration<SaleRecord>
{
    public void Configure(EntityTypeBuilder<SaleRecord> builder)
    {
        builder.ToTable("SaleRecords");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.SaleNumber).IsRequired();
        builder.Property(u => u.SaleDate);
        builder.Property(u => u.CustomerId).IsRequired();
        builder.Property(u => u.Branch);

        builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

    }
}
