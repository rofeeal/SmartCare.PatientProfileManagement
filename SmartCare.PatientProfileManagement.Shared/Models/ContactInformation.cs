using Microsoft.EntityFrameworkCore;
using SmartCare.PatientProfileManagement.Shared.ValueObjects;

namespace SmartCare.PatientProfileManagement.Shared.Models
{
    [Owned]
    public class ContactInformation
    {
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public Address Address { get; private set; }

        private ContactInformation() { }

        public ContactInformation(string email, string phone, Address address)
        {
            Email = email;
            Phone = phone;
            Address = address;
        }
    }
}
