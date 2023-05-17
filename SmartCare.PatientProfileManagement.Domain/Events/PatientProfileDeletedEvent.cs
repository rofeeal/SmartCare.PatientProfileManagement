using MediatR;
using SmartCare.PatientProfileManagement.Domain.Common;

namespace SmartCare.PatientProfileManagement.Domain.Events
{
    public class PatientProfileDeletedEvent : DomainEvent, INotification
    {
        public Guid PatientId { get; set; }

        public PatientProfileDeletedEvent(Guid patientId)
        {
            EventType = nameof(PatientProfileDeletedEvent);
            PatientId = patientId;
        }
    }
}
