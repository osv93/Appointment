using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.API.Data.Contracts
{
    public interface IUnitOfWork
    {
        IPatientRepository PatientRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }
        Task Save();
    }
}
