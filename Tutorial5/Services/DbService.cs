using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Tutorial5.Data;
using Tutorial5.DTOs;
using Tutorial5.Models;
namespace Tutorial5.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<BookWithAuthorsDto>> GetBooks()
    {

        return null;
    }

    public async Task<List<MedicamentDTO>> GetMedicaments()
    {
        var Medicaments = await _context.Medicaments.Select(e => new MedicamentDTO() { Name = e.Name, Description = e.Description, Type = e.Type }).ToListAsync();


        return Medicaments;
    }

    public async Task<PacientDTO> GetPacient(int id)
    {
        var Pacient = await _context.Pacients.Where(e => e.IdPacient == id).Select(e => new PacientDTO()
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            date = e.date,
            IdPacient = e.IdPacient,


            prescriptions = _context.Prescriptions.Where(p => p.IdPacient == e.IdPacient).Select(p => new PrescriptionDTO()
            {
                IdPrescription = p.IdPrescription,
                doctorDTO = _context.Doctors.Where(d => d.IdDoctor == p.IdDoctor).Select(d => new DoctorDTO()
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    email = d.email,
                    IdDoctor = d.IdDoctor

                }).First(),
                medicaments = _context.PrescriptinonMedicamets.Where(P => P.IdPrescription == p.IdPrescription).Join(_context.Medicaments, p => p.IdMedicament, m => m.IdMedicament, (p, m) => new MedicamentDTO() { Name = m.Name, IdMedicament = m.IdMedicament, Description = m.Description, Type = m.Type, Details = p.Details, Dose = p.Dose }).ToList()

            }
            ).ToList()



        }).ToListAsync();

        return Pacient[0];

    }

    public async Task<Boolean> DoesPacientExists(int id)
    {
        if (await _context.Pacients.Where(e => e.IdPacient == id).CountAsync() > 0)
        {
            return true;
        }
        return false;

    }
    public async Task AddPatient(PacientSimpleDTO pacient)
    {
        _context.Pacients.Add(new Pacient() { FirstName = pacient.FirstName, LastName = pacient.LastName, IdPacient = pacient.IdPatient, date = pacient.date });

        await _context.SaveChangesAsync();


    }

    public async Task<Boolean> DoesMedicamesExists(int id)
    {
        if (await _context.Medicaments.Where(e => e.IdMedicament == id).CountAsync() > 0)
        {
            return true;
        }
        return false;
    }

    public async Task<Boolean> DoesDoctorExists(int id)
    {
        if (await _context.Doctors.Where(e => e.IdDoctor == id).CountAsync() > 0)
        {
            return true;
        }
        return false;
    }

    public async Task<Prescription> GetPrescription(NewPrescriptionDTO newPrescriptionDTO)
    {

        var pr = _context.Prescriptions.Where(e => e.IdPacient == newPrescriptionDTO.patient.IdPatient && e.IdDoctor == newPrescriptionDTO.Doctor);


        if (await pr.CountAsync() == 0)
            return null;


        Prescription p = await pr.FirstAsync();

        return p;
    }


    public async Task AddPrescription(NewPrescriptionDTO newPrescriptionDTO)
    {



        await _context.Prescriptions.AddAsync(new Prescription() { IdPacient = newPrescriptionDTO.patient.IdPatient, IdDoctor = newPrescriptionDTO.Doctor, Date = newPrescriptionDTO.Date, DueDate = newPrescriptionDTO.DueDate });
        await _context.SaveChangesAsync();


    }

    public async Task<int> CountPrescriptions(int id)
    {

        return await _context.PrescriptinonMedicamets.Where(p => p.IdPrescription == id).CountAsync();


    }


    public async Task AddPrescriptionMedication(PrescriptinonMedicamet pm)
    {

        await _context.PrescriptinonMedicamets.AddAsync(pm);

        await _context.SaveChangesAsync();


    }

    public async Task<Boolean> DoesPrescriptionMedicationExists(PrescriptinonMedicamet pm)
    {

        if (await _context.PrescriptinonMedicamets.Where(p => p.IdMedicament == pm.IdMedicament && pm.IdPrescription == pm.IdPrescription).CountAsync() > 0)
        {
            return true;
        }
        return false;
    }
}