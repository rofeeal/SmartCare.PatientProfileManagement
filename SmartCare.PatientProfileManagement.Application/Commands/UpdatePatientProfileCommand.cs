using MediatR;
using SmartCare.PatientProfileManagement.Shared.Models;
using SmartCare.PatientProfileManagement.Shared.Result;

namespace SmartCare.PatientProfileManagement.Application.Commands
{
    public class UpdatePatientProfileCommand : IRequest<ResultWithData<Guid>>
    {
        public Guid Id { get; set; }
        public BasicInformation BasicInformation { get; set; }
        public ContactInformation ContactInfo { get; set; }
        public MedicalInformation MedicalInfo { get; set; }
    }
}
