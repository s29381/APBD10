using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities.Config;

namespace WebApplication1.Entities;

public class HospitalDbContext : DbContext
{
    public virtual DbSet<Doctor> Doctors { get; set; }
    
    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Medicament> Medicaments { get; set; }
    
    public DbSet<Prescription> Prescriptions { get; set; }
    
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    public HospitalDbContext()
    {
    }

    public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HospitalDbContext).Assembly);
    }
}