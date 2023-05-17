using AutoMapper;
using SmartCare.PatientProfileManagement.Application.Commands;
using SmartCare.PatientProfileManagement.Domain.Entites;

namespace SmartCare.PatientProfileManagement.Application.Mapping
{
    public class MappingPatientProfile : Profile
    {
        public MappingPatientProfile()
        {
            CreateMap<CreatePatientProfileCommand, PatientProfile>();
        }
    }
}
