using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Config;

public class PrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(e => e.IdPrescription).HasName("Prescription_pk");
        builder.Property(e => e.IdPrescription).UseIdentityColumn();

        builder.Property(e => e.Date).IsRequired();

        builder.Property(e => e.DueDate).IsRequired();

        builder.HasOne(e => e.Patient)
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(e => e.Patient);

        builder.HasOne(e => e.Doctor)
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(e => e.Doctor);
    }
}