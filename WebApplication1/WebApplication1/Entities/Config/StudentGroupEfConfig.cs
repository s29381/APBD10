using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Config;

public class StudentGroupEfConfig : IEntityTypeConfiguration<StudentGroup>
{
    public void Configure(EntityTypeBuilder<StudentGroup> builder)
    {
        builder
            .HasKey(x = new { x.IdGroup, x.IdStudent })
            .HasName("StundetGroup_pk");

        builder
            .Property(x => x.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder
            .HasOne(x => x.Group)
            .WithMany(x => x.StudentGroup)
            .HasForeignKey(x => x.IdGroup)
            .HasConstraintName("StudentGroup_")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(x => x.Student)
            .WithMany(x => x.StudentsGroups)
            .HasForeignKey(x => x.IdStudent)
            .HasConstraintName("StudentGroup_")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Student_Group");
    }
}