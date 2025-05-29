using Microsoft.EntityFrameworkCore;
using Tutorial5.Models;

namespace Tutorial5.Data;

public class DatabaseContext : DbContext
{




    public DbSet<Pacient> Pacients { get; set; }
    public DbSet<Doctor> Doctors{ get; set; }

    public DbSet<Medicament> Medicaments{ get; set; }

    public DbSet<PrescriptinonMedicamet> PrescriptinonMedicamets{ get; set; }


    public DbSet<Prescription> Prescriptions{ get; set; }
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new Medicament(){IdMedicament = 1, Name = "aaa",Description = "aaa for you",Type = "huge pils"}



        });


        modelBuilder.Entity<Pacient>().HasData(new List<Pacient>(){
            new Pacient(){IdPacient = 1,FirstName = "aaa",LastName = "bbb",date = DateOnly.MaxValue}




        });


        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>(){
            new Doctor(){IdDoctor = 1,FirstName = "aaa",LastName = "bbb",email = "asdasd@gm.as"}




        });

        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>(){
            new Prescription(){
                IdPrescription = 1,
                IdDoctor = 1,
                IdPacient = 1
            }




        });

        modelBuilder.Entity<PrescriptinonMedicamet>().HasData(new List<PrescriptinonMedicamet>()
        {
            new PrescriptinonMedicamet(){
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 10,
                Details = "Hi "


            }
        });










        
    }
}