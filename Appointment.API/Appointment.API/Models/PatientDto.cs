using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.API.Models
{
    public class PatientDto
    {
        public string PatientID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<AppointmentDto> Appointments { get; set; }
               = new List<AppointmentDto>();
    }
}
