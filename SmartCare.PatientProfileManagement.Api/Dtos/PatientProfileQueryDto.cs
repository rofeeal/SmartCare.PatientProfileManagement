using SmartCare.PatientProfileManagement.Shared.Models;

namespace SmartCare.PatientProfileManagement.Api.Dtos
{
    public class PatientProfileQueryDto
    {
        public Guid Id { get; private set; }
        public BasicInformation BasicInformation { get; private set; }
        public ContactInformation ContactInfo { get; private set; }
        public MedicalInformation MedicalInfo { get; private set; }
    }
}
