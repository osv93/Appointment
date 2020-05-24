using Appointment.API.Contexts;
using Appointment.API.Data.Contracts;

namespace Appointment.API.Data
{
    public class AppointmentRepository : RepositoryBase<Entities.Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(Context context) : base(context) 
        {
        }
    }
}
