using MediatR;
using SmartCare.PatientProfileManagement.Domain.Common;
using SmartCare.PatientProfileManagement.Domain.Entites;

namespace SmartCare.PatientProfileManagement.Domain.Events
{
    public class PatientProfileUpdatedEvent : DomainEvent, INotification
    {
        public PatientProfile PatientProfile { get; set; }

        public PatientProfileUpdatedEvent(PatientProfile patientProfile)
        {
            EventType = nameof(PatientProfileUpdatedEvent);
            PatientProfile = patientProfile;
        }
    }
}
