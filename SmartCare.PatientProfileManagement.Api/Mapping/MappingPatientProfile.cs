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
            CreateMap<PatientProfileCommandDto, CreatePatientProfileCommand>();
            CreateMap<PatientProfileCommandDto, UpdatePatientProfileCommand>();
            CreateMap<Guid, DeletePatientProfileCommand>();


            CreateMap<Guid, GetPatientProfileByIdQuery>();
            CreateMap<List<PatientProfile>, List<PatientProfileQueryDto>>();
            CreateMap<PatientProfile, PatientProfileQueryDto>();

        }
    }
}
