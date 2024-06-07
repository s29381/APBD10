namespace WebApplication1.Entities;

public class Prescription
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public Patient? Patient { get; set; }
    public Doctor? Doctor { get; set; }
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}