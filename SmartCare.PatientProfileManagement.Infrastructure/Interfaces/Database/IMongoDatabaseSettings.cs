namespace SmartCare.PatientProfileManagement.Infrastructure.Interfaces.Database
{
    public interface IMongoDatabaseSettings
    {
        string PatientProfileEventsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
