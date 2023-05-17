using SmartCare.PatientProfileManagement.Domain.Entites;
using SmartCare.PatientProfileManagement.Shared.Result;

namespace SmartCare.PatientProfileManagement.Domain.Interfaces.Repository
{
    public interface IPatientProfileCommandRepository
    {
        Task<ResultWithData<Guid>> AddAsync(PatientProfile patient);
        Task<ResultWithData<Guid>> UpdateAsync(PatientProfile patient);
        Task<Result> DeleteAsync(Guid patientId);
    }
}
