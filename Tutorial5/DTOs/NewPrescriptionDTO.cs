using System.Collections;

namespace Tutorial5.DTOs;


public class NewPrescriptionDTO
{
    required public PacientSimpleDTO patient { get; set; }


    required public List<MedicamentSimpleDTO> medicaments { get; set; }


    required public DateOnly Date { get; set; }


    required public DateOnly DueDate { get; set; }
    

    required public int Doctor { get; set; }
    








}