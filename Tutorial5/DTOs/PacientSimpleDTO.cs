using System.Collections;

namespace Tutorial5.DTOs;


public class PacientSimpleDTO
{
    required public  int IdPatient { get; set; }


    required public  string FirstName { get; set; }

    required public  string LastName { get; set; }
    required public  DateOnly date { get; set; }
    
}