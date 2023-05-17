using Microsoft.EntityFrameworkCore;
using SmartCare.PatientProfileManagement.Shared.Enums;

namespace SmartCare.PatientProfileManagement.Shared.Models
{
    [Owned]
    public class BasicInformation
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Gender Gender { get; private set; }
        private BasicInformation() { }

        public BasicInformation(string firstName, string lastName, DateTime dateOfBirth, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }
    }
}
