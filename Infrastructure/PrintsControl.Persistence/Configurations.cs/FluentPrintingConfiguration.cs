using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Persistence.Configurations.cs;

public class FluentPrintingConfiguration : IEntityTypeConfiguration<PrintJob>
{
    public void Configure(EntityTypeBuilder<PrintJob> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.HasOne(x => x.Student)
            .WithMany(s => s.PrintJob)
            .HasForeignKey(x => x.StudentId);

        builder.HasQueryFilter(x => x.DeletedAt == null);
    }
}