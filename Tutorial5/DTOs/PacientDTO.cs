using System.Collections;

namespace Tutorial5.DTOs;


public class PacientDTO
{
    public int IdPacient { get; set; }


    public string FirstName { get; set; }

    public string LastName { get; set; }
    public DateOnly date { get; set; }


    public List<PrescriptionDTO> prescriptions{ get; set; }
    
}