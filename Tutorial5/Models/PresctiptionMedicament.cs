using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tutorial5.Models;

[Table("Prescriptinon_Medicament")]


[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public class PrescriptinonMedicamet
{

    [ForeignKey(nameof(Medicament))]
    public int IdMedicament { get; set; }


    [ForeignKey(nameof(Prescription))]
    public int IdPrescription { get; set; }


    public int Dose { get; set; }

    [MaxLength(100)]
    public string Details { get; set; }




}