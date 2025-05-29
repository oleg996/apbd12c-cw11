using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tutorial5.Data;
using Tutorial5.Models;
using Tutorial5.Services;
using Tutorial5.DTOs;

namespace Tutorial5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public ReceptsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!await _dbService.DoesPacientExists(id))
                return NotFound();


            var Pacient = await _dbService.GetPacient(id);
            return Ok(Pacient);
        }


        [HttpPost]

        public async Task<IActionResult> Add(NewPrescriptionDTO newPrescriptionDTO)
        {

            if (newPrescriptionDTO.Date > newPrescriptionDTO.DueDate)
                return BadRequest("incorect date");



            if (!await _dbService.DoesPacientExists(newPrescriptionDTO.patient.IdPatient))
                    await _dbService.AddPatient(newPrescriptionDTO.patient);



            

            if (!await _dbService.DoesDoctorExists(newPrescriptionDTO.Doctor))
                return NotFound();


            if (await _dbService.GetPrescription(newPrescriptionDTO) == null)
                await _dbService.AddPrescription(newPrescriptionDTO);

            int pid = (await _dbService.GetPrescription(newPrescriptionDTO)).IdPrescription;


            if (await _dbService.CountPrescriptions(pid) > 10)
                return BadRequest("max of 10 prescriptions");


            foreach (MedicamentSimpleDTO medicament in newPrescriptionDTO.medicaments)
            {
                if (!await _dbService.DoesMedicamesExists(medicament.IdMedicament))
                    return NotFound("medicament with id " + medicament.IdMedicament + " does not exists");
                if(await _dbService.DoesPrescriptionMedicationExists(new PrescriptinonMedicamet() { IdMedicament = medicament.IdMedicament, IdPrescription = pid, Details = medicament.Description, Dose = medicament.Dose}))
                    return BadRequest("medicament with id " + medicament.IdMedicament + " is already in a prescription");
               await _dbService.AddPrescriptionMedication(new PrescriptinonMedicamet() { IdMedicament = medicament.IdMedicament, IdPrescription = pid, Details = medicament.Description, Dose = medicament.Dose});
            }


                return Ok(newPrescriptionDTO);
        }
    }
}
