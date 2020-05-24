using Appointment.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Appointment.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AppointmentController : ControllerBase
    {

        private List<AppointmentDto> DummyData() {
            List<AppointmentDto> appointments = new List<AppointmentDto>() {
                new AppointmentDto(){ AppointmentID = 1},
                new AppointmentDto(){ AppointmentID = 2},
                new AppointmentDto(){ AppointmentID = 3}
            };

            return appointments;
        }

        [HttpGet]
        public IActionResult GetAppointments() {
            return Ok(DummyData());
        }

        [HttpGet("{id}")]
        public IActionResult GetAppointmentById(int id)
        {
            AppointmentDto appointmentdto = DummyData().Find(appointment => appointment.AppointmentID == id);
            if (appointmentdto == null) {
                return NotFound();
            }

            return Ok(appointmentdto);          
        }
    }
}
