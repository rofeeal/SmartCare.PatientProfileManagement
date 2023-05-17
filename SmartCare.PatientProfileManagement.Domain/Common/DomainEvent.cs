namespace SmartCare.PatientProfileManagement.Domain.Common
{
    public abstract class DomainEvent
    {
        public Guid Id { get; protected set; }
        public string EventType { get; set; }
        public DateTime OccurredOn { get; protected set; }

        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }
    }
}
