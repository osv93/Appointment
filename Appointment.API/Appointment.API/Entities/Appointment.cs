using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Appointment.API.Entities
{
    [Table("Appointment")]
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentID { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("PatientID")]
        public Patient Patient { get; set; }

        public string PatientID { get; set; }

    }
}
