using Appointment.API.Contexts;
using Appointment.API.Data.Contracts;
using System.Threading.Tasks;

namespace Appointment.API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private IPatientRepository _patientRepository;
        private IAppointmentRepository _appointmentRepository;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public IPatientRepository PatientRepository
        {
            get
            {
                if (_patientRepository == null)
                {
                    _patientRepository = new PatientRepository(_context);
                }

                return _patientRepository;
            }
        }

        public IAppointmentRepository AppointmentRepository
        {
            get
            {
                if (_appointmentRepository == null)
                {
                    _appointmentRepository = new AppointmentRepository(_context);
                }

                return _appointmentRepository;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
