using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tutorial5.Models;


public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly DueDate { get; set; }

    [ForeignKey(nameof(Pacient))]
    public int IdPacient { get; set; }


    [ForeignKey(nameof(Doctor))]
    public int IdDoctor { get; set; }

    
    
}