using AutoMapper;
using SmartCare.PatientProfileManagement.Api.Dtos;
using SmartCare.PatientProfileManagement.Application.Commands;
using SmartCare.PatientProfileManagement.Application.Queries;
using SmartCare.PatientProfileManagement.Domain.Entites;

namespace SmartCare.PatientProfileManagement.Api.Mapping
{
    public class MappingPatientProfile : Profile
    {
        public MappingPatientProfile()
        {
            CreateMap<PatientProfileDto, CreatePatientProfileCommand>();
            CreateMap<PatientProfileDto, UpdatePatientProfileCommand>();
            CreateMap<Guid, DeletePatientProfileCommand>();


            CreateMap<Guid, GetPatientProfileByIdQuery>();
            CreateMap<IEnumerable<PatientProfile>, List<PatientProfileDto>>();

        }
    }
}
