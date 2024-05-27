using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Config;

public class StudentEfConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder
            .Property(x => x.FristName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(x => x.IndexNumber)
            .IsRequired()
            .HasMaxLength(15);
    }
}