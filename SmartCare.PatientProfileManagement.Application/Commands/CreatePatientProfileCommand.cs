using MediatR;
using SmartCare.PatientProfileManagement.Shared.Result;
using SmartCare.PatientProfileManagement.Shared.Models;

namespace SmartCare.PatientProfileManagement.Application.Commands
{
    public class CreatePatientProfileCommand : IRequest<ResultWithData<Guid>>
    {
        public BasicInformation BasicInformation { get; set; }
        public ContactInformation ContactInfo { get; set; }
        public MedicalInformation MedicalInfo { get; set; }
    }
}
