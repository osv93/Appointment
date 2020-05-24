using Appointment.API.Contexts;
using Appointment.API.Entities;
using Appointment.API.Data.Contracts;

namespace Appointment.API.Data
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(Context context) : base(context)
        {
        }
    }

}
