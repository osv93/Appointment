using Appointment.API.Entities;
using Appointment.API.Models;
using Appointment.API.Data.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientController(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatientsAsync()
        {
            IEnumerable<Patient> patients = await _unitOfWork.PatientRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<PatientDto>>(patients));
        }

        [HttpGet("{patientID}", Name = "GetPatientById")]
        public async Task<IActionResult> GetPatientByIdAsync(string patientID)
        {
            Patient patient = await _unitOfWork.PatientRepository.GetByIdWithDetails(predicate:
                    x => x.PatientID == patientID,
                    include: source => source.Include(a => a.Appointments));

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PatientDto>(patient));
        }

        [HttpPost]
        public async Task<IActionResult> AddPatientAsync([FromBody]PatientDto patientDto)
        {
            bool entityExist = await _unitOfWork.PatientRepository.EntityExistById(predicate:
                x => x.PatientID == patientDto.PatientID);
            if (entityExist)
            {
                return StatusCode(403, $"User '{patientDto.PatientID}' already exists.");
            }
            await _unitOfWork.PatientRepository.Add(_mapper.Map<Patient>(patientDto));
            await _unitOfWork.Save();
            return CreatedAtRoute("GetPatientById", new { patientID = patientDto.PatientID }, patientDto);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdatePatientAsync([FromBody]PatientDto patientDto)
        {
            Patient patient = await _unitOfWork.PatientRepository.GetByIdWithDetails(predicate:
                    x => x.PatientID == patientDto.PatientID,
                    include: null);

            if (patient == null)
            {
                return NotFound();
            }
            patient.Name = patientDto.Name;
            patient.LastName = patientDto.LastName;
            _unitOfWork.PatientRepository.Update(patient);
            await _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{patientID}")]
        public async Task<IActionResult> DeletePatientAsync(string patientID)
        {
            Patient patient = await _unitOfWork.PatientRepository.GetByIdWithDetails(predicate:
                    x => x.PatientID == patientID,
                    include: null);

            if (patient == null)
            {
                return NotFound();
            }

            _unitOfWork.PatientRepository.Delete(patient);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
