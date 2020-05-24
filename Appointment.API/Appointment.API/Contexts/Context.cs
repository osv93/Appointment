using Appointment.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Appointment.API.Contexts
{
    public class Context: DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<Entities.Patient> Appointments { get; set; } = null!;
        public DbSet<Entities.Appointment> Patients { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Entities.Appointment>()
            .Property(b => b.Active)
            .HasDefaultValue(1);

            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientID = "111", Name = "Patient 1", LastName = "LastName 1" },
                new Patient { PatientID = "222", Name = "Patient 2", LastName = "LastName 2" },
                new Patient { PatientID = "333", Name = "Patient 3", LastName = "LastName 3" },
                new Patient { PatientID = "444", Name = "Patient 4", LastName = "LastName 4" }
            );

            modelBuilder.Entity<Entities.Appointment>().HasData(
                new Entities.Appointment { AppointmentID = 1,Date = new DateTime(), PatientID = "111" }
            );
        }
    }
}
