using Microsoft.EntityFrameworkCore;
using SmartCare.PatientProfileManagement.Shared.Enums;

namespace SmartCare.PatientProfileManagement.Shared.Models
{
    [Owned]
    public class MedicalInformation
    {
        public BloodType BloodType { get; private set; }
        public string BloodPressure { get; private set; }
        public string BloodSugar { get; private set; }
        public string Cholesterol { get; private set; }

        private MedicalInformation() { }

        public MedicalInformation(BloodType bloodType, string bloodPressure, string bloodSugar, string cholesterol)
        {
            BloodType = bloodType;
            BloodPressure = bloodPressure;
            BloodSugar = bloodSugar;
            Cholesterol = cholesterol;
        }
    }
}
