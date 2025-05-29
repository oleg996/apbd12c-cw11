using Tutorial5.DTOs;
using Tutorial5.Models;

namespace Tutorial5.Services;

public interface IDbService
{
    Task<List<BookWithAuthorsDto>> GetBooks();


    Task<List<MedicamentDTO>> GetMedicaments();

    Task<PacientDTO> GetPacient(int id);

    Task<Boolean> DoesPacientExists(int id);

    Task AddPatient(PacientSimpleDTO pacient);

    Task<Boolean> DoesMedicamesExists(int id);

    Task<Boolean> DoesDoctorExists(int id);

    Task<Prescription> GetPrescription(NewPrescriptionDTO newPrescriptionDTO);

    Task AddPrescription(NewPrescriptionDTO newPrescriptionDTO);

    Task<int> CountPrescriptions(int id);

    Task AddPrescriptionMedication(PrescriptinonMedicamet pm);
}