using SmartCare.PatientProfileManagement.Shared.Models;

namespace SmartCare.PatientProfileManagement.Api.Dtos
{
    public class PatientProfileDto
    {
        public BasicInformation BasicInformation { get; set; }
        public ContactInformation ContactInfo { get; set; }
        public MedicalInformation MedicalInfo { get; set; }
    }
}
