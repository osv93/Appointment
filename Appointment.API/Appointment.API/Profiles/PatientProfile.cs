using AutoMapper;

namespace Appointment.API.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile() 
        {
            CreateMap<Entities.Patient, Models.PatientDto>().ReverseMap();           
        }
    }
}
