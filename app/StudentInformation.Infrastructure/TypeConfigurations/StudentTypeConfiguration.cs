using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentInformation.Domain.Abstractions.ValueObjects;
using StudentInformation.Domain.Students;

namespace StudentInformation.Infrastructure.TypeConfigurations;

public class StudentTypeConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("students");

        builder.HasKey(x => new { x.Id });

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, p => new StudentId(p))
            .IsRequired();

        builder.Property(x => x.Number)
            .HasConversion(x => x.Value, p => new StudentNumber(p))
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasConversion(item => item.Value, p => new FirstName(p))
            .IsRequired();
        
        builder.Property(x => x.FamilyName)
            .HasConversion(x => x.Value, p => new FamilyName(p))
            .IsRequired();

    }
}
