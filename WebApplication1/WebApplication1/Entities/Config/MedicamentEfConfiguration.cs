using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Config;

public class MedicamentEfConfiguration : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.HasKey(e => e.IdMedicament).HasName("Madicament_pk");
        builder.Property(e => e.IdMedicament).UseIdentityColumn();

        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);

        builder.Property(e => e.Description).IsRequired().HasMaxLength(100);

        builder.Property(e => e.Type).IsRequired().HasMaxLength(100);

        builder.ToTable(nameof(Medicament));

        Medicament[] medicaments =
        {

        };

        builder.HasData(medicaments);
    }
}