using MediatR;
using SmartCare.PatientProfileManagement.Domain.Common;
using SmartCare.PatientProfileManagement.Domain.Entites;
namespace SmartCare.PatientProfileManagement.Domain.Events
{
    public class PatientProfileCreatedEvent : DomainEvent, INotification
    {
        public PatientProfile PatientProfile { get; set; }

        public PatientProfileCreatedEvent(PatientProfile patientProfile)
        {
            EventType = nameof(PatientProfileCreatedEvent);
            PatientProfile = patientProfile;
        }
    }
}
