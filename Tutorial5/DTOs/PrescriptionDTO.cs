namespace Tutorial5.DTOs;


public class PrescriptionDTO
{
    public int IdPrescription { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly DueDate { get; set; }

    public DoctorDTO doctorDTO { get; set; }


    public List<MedicamentDTO> medicaments { get; set; }


}