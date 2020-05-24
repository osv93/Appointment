using AutoMapper;

namespace Appointment.API.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Entities.Appointment, Models.AppointmentDto>();
        }
    }
}
