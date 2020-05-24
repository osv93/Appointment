using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment.API.Entities
{
    [Table("Patient")]
    public class Patient
    {
        [Key]
        public string PatientID { get; set; }

        [MinLength(15), MaxLength(50), Required]
        public string Name { get; set; }

        [MinLength(15), MaxLength(50), Required]
        public string LastName { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
               = new List<Appointment>();
    }
}
