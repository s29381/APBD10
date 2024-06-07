using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Config;

public class DoctorEfConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(e => e.IdDoctor).HasName("Doctor_pk");
        builder.Property(e => e.IdDoctor).UseIdentityColumn();

        builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
        
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
        
        builder.Property(e => e.Email).IsRequired().HasMaxLength(100);

        builder.ToTable(nameof(Doctor));

        Doctor[] doctors =
        {
            
        };

        builder.HasData(doctors);
    }
}