using MongoDB.Bson;

namespace SmartCare.PatientProfileManagement.Infrastructure.EventStore
{
    public class EventDocument
    {
        public Guid EventId { get; set; }
        public string EventType { get; set; }
        public Guid EntityId { get; set; }
        public string EventData { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
