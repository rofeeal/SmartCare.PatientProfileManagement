using SmartCare.PatientProfileManagement.Domain.Entites;
using SmartCare.PatientProfileManagement.Shared.Result;

namespace SmartCare.PatientProfileManagement.Domain.Interfaces.Repository
{
    public interface IPatientProfileQueryRepository
    {
        Task<ResultWithData<PatientProfile>> GetPatientProfileAsync(Guid patientId);
        Task<ResultWithData<List<PatientProfile>>> GetAllPatientsProfilesAsync();
    }
}
