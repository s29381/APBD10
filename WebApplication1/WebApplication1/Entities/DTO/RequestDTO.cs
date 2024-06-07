namespace WebApplication1.Entities.DTO;

public class RequestDTO
{
    public int IdPatient { get; set; }
    public string FirstNamePatient { get; set; }
    public string LastNamePatient { get; set; }
    public DateTime DateOfBirthPatient { get; set; }
    public List<int> IdMedicament { get; set; }
    public int IdDoctor { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}