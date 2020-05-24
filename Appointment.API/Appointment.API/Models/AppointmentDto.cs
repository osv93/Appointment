using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.API.Models
{
    public class AppointmentDto
    {
        public int AppointmentID { get; set; }

        public bool Active { get; set; }

        public DateTime Date { get; set; }

    }
}
