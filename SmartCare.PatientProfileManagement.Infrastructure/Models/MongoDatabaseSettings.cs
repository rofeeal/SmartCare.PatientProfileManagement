
using SmartCare.PatientProfileManagement.Infrastructure.Interfaces.Database;

namespace SmartCare.PatientProfileManagement.PatientProfileManagement.Infrastructure.Models
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {
        public string PatientProfileEventsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
