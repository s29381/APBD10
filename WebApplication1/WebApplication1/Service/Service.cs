using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using WebApplication1.Entities.DTO;

namespace WebApplication1.Service;

public interface IService
{
    Task<object?> PatientData(int idPatient);
    Task<object?> AddRecipe(RequestDTO request);
}

public class Service : IService
{
    private HospitalDbContext _context;

    public Service (HospitalDbContext context)
    {
        _context = context;
    }

    public async Task<object?> AddRecipe(RequestDTO request)
    {
        if (request.IdMedicament.Count > 10)
        {
            throw new Exception();
        }
        
        if (request.DueDate < request.Date)
        {
            throw new Exception();
        }

        if (await _context.FindAsync<Patient>(request.IdPatient) == null)
        {
            Patient p = new Patient
            {
                IdPatient = request.IdPatient,
                FirstName = request.FirstNamePatient,
                LastName = request.LastNamePatient,
                BirthDate = request.DateOfBirthPatient
            };
            _context.Add(p);
        }

        foreach (var m in request.IdMedicament)
        {
            if (await _context.FindAsync<Medicament>(m) == null)
            {
                throw new Exception();
            }
        }
        
        var recipe = new Prescription
        {
            Date = request.Date,
            DueDate = request.DueDate,
            Patient = await _context.FindAsync<Patient>(request.IdPatient),
            Doctor = await _context.FindAsync<Doctor>(request.IdDoctor)
        };
        _context.Prescriptions.Add(recipe);
        
        return await _context.SaveChangesAsync();
    }

    public async Task<object?> PatientData(int id)
    {
        var patient = await _context.Patients
            .Include(p => p.Prescriptions)!
            .ThenInclude(p => p.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .Include(p => p.Prescriptions)!
            .ThenInclude(p => p.Doctor)
            .Where(p => p.IdPatient == id)
            .FirstOrDefaultAsync();

        if (patient == null)
        {
            throw new ArgumentException($"Patient with Id {id} does not exist.");
        }

        Debug.Assert(patient.Prescriptions != null, "patient.Prescriptions != null");
        var response = new Patient
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.BirthDate,
            Prescriptions = patient.Prescriptions.Select(p => new Prescription
            {
                Date = p.Date,
                DueDate = p.DueDate,
                Doctor = p.Doctor
            }).OrderBy(p => p.DueDate).ToList()
        };

        return response;
    }
}