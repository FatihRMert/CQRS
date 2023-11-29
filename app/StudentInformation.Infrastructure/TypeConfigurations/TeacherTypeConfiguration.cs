using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentInformation.Domain.Abstractions.ValueObjects;
using StudentInformation.Domain.Teachers;

namespace StudentInformation.Infrastructure.TypeConfigurations;

public class TeacherTypeConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("teachers");

        builder.HasKey(x => new { x.Id });

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, p => new TeacherId(p))
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasConversion(item => item.Value, p => new FirstName(p))
            .IsRequired();
        
        builder.Property(x => x.FamilyName)
            .HasConversion(x => x.Value, p => new FamilyName(p))
            .IsRequired();

        builder.HasData(
            new Teacher(Teacher.DefaultTeacherId, new FirstName("Fatih Rahman"), new FamilyName("Mert"))
        );
    }
}
