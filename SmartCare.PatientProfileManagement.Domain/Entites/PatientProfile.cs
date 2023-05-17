using SmartCare.PatientProfileManagement.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace SmartCare.PatientProfileManagement.Domain.Entites
{
    public class PatientProfile
    {
        [Key]
        public Guid Id { get; private set; }
        public BasicInformation BasicInformation { get; private set; }
        public ContactInformation ContactInfo { get; private set; }
        public MedicalInformation MedicalInfo { get; private set; }
        private PatientProfile() { }

        public PatientProfile(BasicInformation basicInformation,
            ContactInformation contactInfo, MedicalInformation medicalInfo)
        {
            Id = Guid.NewGuid();
            BasicInformation = basicInformation;
            ContactInfo = contactInfo;
            MedicalInfo = medicalInfo;
        }

        public void UpdatePatientProfile(BasicInformation basicInformation,
            ContactInformation contactInfo, MedicalInformation medicalInfo)
        {
            BasicInformation = basicInformation;
            ContactInfo = contactInfo;
            MedicalInfo = medicalInfo;
        }
    }
}
